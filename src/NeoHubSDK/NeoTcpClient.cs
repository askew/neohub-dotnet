using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Heatmiser.NeoHubSDK
{
    public interface INeoTcpClient
    {
        /// <summary>
        /// Invokes a command on the Neo Hub, returning the response as a <see cref="JsonDocument"/> object.
        /// </summary>
        /// <param name="command">The command to send to the Neo Hub</param>
        /// <param name="parameters">The parameters for the command.</param>
        /// <returns>A <see cref="JsonDocument"/> object with the response from the Neo Hub.</returns>
        Task<ReadOnlyMemory<byte>> InvokeCommandAsync(string command, params object[] parameters);
    }

    /// <summary>
    /// A class that implements the <see cref="INeoTcpClient"/> interface.
    /// </summary>
    internal class NeoTcpClient : INeoTcpClient
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="NeoTcpClient"/> class.
        /// </summary>
        /// <param name="server">The hostname of the Neo Hub, typically <c>neo-hub</c>.</param>
        public NeoTcpClient(string server)
        {
            Host = Dns.GetHostEntry(server);
            EndPoint = new IPEndPoint(Host.AddressList[0], 4242);
        }

        /// <summary>
        /// Gets the IP address of the NeoHub.
        /// </summary>
        private IPHostEntry Host { get; }

        private IPEndPoint EndPoint { get; }

        private class UserTokenData
        {
            private readonly MemoryStream _stream = new();
            private readonly TaskCompletionSource<ReadOnlyMemory<byte>> _tcs = new(TaskCreationOptions.RunContinuationsAsynchronously);

            public UserTokenData(Socket socket)
            {
                Socket = socket;
            }

            public Socket Socket { get; }

            public Task<ReadOnlyMemory<byte>> GetResult()
            {
                return _tcs.Task;
            }

            public bool AddData(ReadOnlySpan<byte> data)
            {
                bool moreDataNeeded = true;

                if (_stream == null || !_stream.CanWrite)
                {
                    throw new InvalidOperationException("Data cannot be added once the stream has been closed.");
                }

                _stream.Write(data);

                if (data[^1] == '\0')
                {
                    try
                    {
                        moreDataNeeded = false;

                        _stream.SetLength(_stream.Length - 1);

                        _tcs.SetResult(new(_stream.ToArray()));
                    }
                    finally
                    {
                        Socket.Close();
                    }
                }

                return moreDataNeeded;
            }
        }

        /// <summary>
        /// Gets the JSON payload for a command to the Neo Hub with the specified parameters.
        /// </summary>
        /// <param name="command">The name of the command to send.</param>
        /// <param name="parameters">The parameters to add to the payload.</param>
        /// <returns>The JSON representation ready to send to the NeoHub.</returns>
        private static Memory<byte> GetCommand(string command, params object[] parameters)
        {
            JsonWriterOptions options = new()
            {
                Indented = false
            };

            using MemoryStream stream = new();
            using (Utf8JsonWriter writer = new(stream, options))
            {
                writer.WriteStartObject();

                if (parameters == null || parameters.Length == 0)
                {
                    writer.WriteNumber(command, 0);
                }
                else if (parameters.Length == 1)
                {
                    if (parameters[0] is int pint)
                    {
                        writer.WriteNumber(command, pint);
                    }
                    else
                    if (parameters[0] is double pdbl)
                    {
                        writer.WriteNumber(command, pdbl);
                    }
                    else
                    if (parameters[0] is string pstr)
                    {
                        writer.WriteString(command, pstr);
                    }
                    else
                    {
                        writer.WriteStartObject(command);
                        JsonSerializer.Serialize(writer, parameters[0], parameters[0].GetType());
                        writer.WriteEndObject();
                    }
                }
                else
                {
                    writer.WriteStartArray();
                    foreach (object p in parameters)
                    {
                        JsonSerializer.Serialize(writer, p, p.GetType());
                    }
                    writer.WriteEndArray();
                }

                writer.WriteEndObject();
            }

            // Add the NULL terminator.
            stream.WriteByte(0);

            return stream.ToArray();
        }

        async Task<ReadOnlyMemory<byte>> INeoTcpClient.InvokeCommandAsync(string command, params object[] parameters)
        {
            Memory<byte> bytesToSend = GetCommand(command, parameters);

            Socket? socket = await Connect(EndPoint);
            if (socket == null)
            {
                return null;
            }

            UserTokenData userToken = new(socket);
            SocketAsyncEventArgs evtArgs = new()
            {
                UserToken = userToken
            };
            evtArgs.Completed += AsyncSendCompleted;
            evtArgs.SetBuffer(bytesToSend);

            if (!socket.SendAsync(evtArgs))
            {
                // I/O operation completed synchronously.
                AsyncSendCompleted(null, evtArgs);
            }

            return await userToken.GetResult();
        }

        private async Task<Socket?> Connect(EndPoint endPoint)
        {
            var tcs = new TaskCompletionSource<Socket?>(TaskCreationOptions.RunContinuationsAsynchronously);

            var connectEvtArgs = new SocketAsyncEventArgs()
            {
                UserToken = tcs,
                RemoteEndPoint = endPoint
            };
            connectEvtArgs.Completed += AsyncConnectCompleted;

            bool ioPending = Socket.ConnectAsync(SocketType.Stream, ProtocolType.Tcp, connectEvtArgs);

            if (!ioPending)
            {
                tcs.SetResult(connectEvtArgs.ConnectSocket);
            }

            return await tcs.Task;
        }

        private void AsyncConnectCompleted(object? sender, SocketAsyncEventArgs e)
        {
            if (e.UserToken is TaskCompletionSource<Socket> tcs && e.ConnectSocket != null)
            {
                tcs.SetResult(e.ConnectSocket);
            }
        }

        private void AsyncSendCompleted(object? sender, SocketAsyncEventArgs e)
        {
            if (e.UserToken is UserTokenData userToken)
            {
                var evtArgs = new SocketAsyncEventArgs
                {
                    UserToken = e.UserToken
                };
                evtArgs.Completed += AsyncReceiveCompleted;
                evtArgs.SetBuffer(new byte[Environment.SystemPageSize], 0, Environment.SystemPageSize);

                bool ioPending = userToken.Socket.ReceiveAsync(evtArgs);
                if (!ioPending)
                {
                    ProcessReceive(evtArgs);
                }
            }
        }

        private void AsyncReceiveCompleted(object? sender, SocketAsyncEventArgs e)
        {
            ProcessReceive(e);
        }

        private void ProcessReceive(SocketAsyncEventArgs e)
        {
            if (e.UserToken is UserTokenData userToken)
            {
                if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
                {
                    if (userToken.AddData(new ReadOnlySpan<byte>(e.Buffer, e.Offset, e.BytesTransferred)))
                    {
                        // Probably need more data ...
                        e.SetBuffer(0, Environment.SystemPageSize);
                        bool ioPending = userToken.Socket.ReceiveAsync(e);
                        if (!ioPending)
                        {
                            ProcessReceive(e);
                        }
                    }
                }
                else
                {
                    userToken.Socket.Close();
                }
            }
        }
    }
}
