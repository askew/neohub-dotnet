using System.Text.Json;

namespace Heatmiser.NeoHubSDK
{
    public class NeoHubClient
    {
        private const string DefaultHostName = "neo-hub";

        private readonly INeoTcpClient tcpClient;

        public NeoHubClient() : this(DefaultHostName)
        {
        }

        public NeoHubClient(string server)
        {
            tcpClient = new NeoTcpClient(server);

            SerializerOptions = new();
            SerializerOptions.Converters.Add(new JsonConverters.FloatingPointConverter());
            SerializerOptions.Converters.Add(new JsonConverters.TimestampConverter());
        }

        private JsonSerializerOptions SerializerOptions { get; }

        public async Task<NeoHubInfo?> GetHubInfo()
        {
            ReadOnlyMemory<byte> data = await tcpClient.InvokeCommandAsync(NeoCommands.GET_SYSTEM);

            return JsonSerializer.Deserialize<NeoHubInfo>(data.Span, SerializerOptions);
        }

        public async Task<LiveData?> GetLiveData()
        {
            ReadOnlyMemory<byte> data = await tcpClient.InvokeCommandAsync(NeoCommands.GET_LIVE_DATA);

            return JsonSerializer.Deserialize<LiveData>(data.Span, SerializerOptions);
        }

        public async Task<IEnumerable<DeviceInfo?>> GetDeviceInfo()
        {
            ReadOnlyMemory<byte> data = await tcpClient.InvokeCommandAsync(NeoCommands.GET_ENGINEERS);

            var obj = JsonDocument.Parse(data);

            return obj.RootElement.EnumerateObject().Select(prop => {
                DeviceInfo? device = prop.Value.Deserialize<DeviceInfo>(SerializerOptions);
                if (device != null)
                {
                    device.Name = prop.Name;
                }
                return device;
            });
        }

        public async Task<IDictionary<int, string>> GetZones()
        {
            ReadOnlyMemory<byte> data = await tcpClient.InvokeCommandAsync(NeoCommands.GET_ZONES);
            var obj = JsonDocument.Parse(data);

            return new Dictionary<int,string>(obj.RootElement.EnumerateObject().Select(prop => new KeyValuePair<int, string>(prop.Value.GetInt32(), prop.Name)));
        }

        public async Task<IDictionary<string, EngineerData?>> GetEngineersData()
        {
            ReadOnlyMemory<byte> data = await tcpClient.InvokeCommandAsync(NeoCommands.GET_ENGINEERS);

            var obj = JsonDocument.Parse(data);

            return new Dictionary<string, EngineerData?>(obj.RootElement.EnumerateObject().Select(prop => new KeyValuePair<string, EngineerData?>(prop.Name, prop.Value.Deserialize<EngineerData>(SerializerOptions))));
        }

        public async Task<int> GetFirmwareVersion()
        {
            ReadOnlyMemory<byte> data = await tcpClient.InvokeCommandAsync(NeoCommands.Hub.FIRMWARE);
            var obj = JsonDocument.Parse(data);

            string? fwProp = obj.RootElement.GetProperty("firmware version").GetString();

            if (int.TryParse(fwProp, out int fwver))
            {
                return fwver;
            }
            return 0;
        }

    }
}