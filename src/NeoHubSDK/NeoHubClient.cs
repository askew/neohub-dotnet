using System.Text.Json;

namespace Heatmiser.NeoHubSDK
{
    public class NeoHubClient
    {
        private const string DefaultHostName = "neo-hub";

        private readonly INeoTcpClient tcpClient;

        private LiveData? _liveData;
        private IDictionary<string, DeviceInfo> engineersData = new Dictionary<string, DeviceInfo>(0);
        private DateTime engineersDataTimestamp;
        private readonly SemaphoreSlim dataLock = new(1, 1);

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

        private async Task<LiveData> GetLiveData()
        {
            if (_liveData == null)
            {
                try
                {
                    await dataLock.WaitAsync();
                    if (_liveData == null)
                    {
                        ReadOnlyMemory<byte> data = await tcpClient.InvokeCommandAsync(NeoCommands.GET_LIVE_DATA);

                        _liveData = JsonSerializer.Deserialize<LiveData>(data.Span, SerializerOptions);
                        if (_liveData is null)
                        {
                            throw new Exception("Unable to retrieve live data.");
                        }
                    }
                }
                finally
                {
                    dataLock.Release();
                }
            }
            return _liveData;
        }

        private async Task<IDictionary<string, DeviceInfo>> GetDeviceInfo()
        {
            LiveData liveData = await GetLiveData();
            if (engineersData == null || engineersDataTimestamp < liveData.EngineersTimestamp)
            {
                try
                {
                    await dataLock.WaitAsync();
                    if (engineersData == null || engineersDataTimestamp < liveData.EngineersTimestamp)
                    {
                        ReadOnlyMemory<byte> data = await tcpClient.InvokeCommandAsync(NeoCommands.GET_ENGINEERS);

                        var obj = JsonDocument.Parse(data);

                        var devices = obj.RootElement.EnumerateObject()
                        .Select(prop =>
                        {
                            DeviceInfo? device = prop.Value.Deserialize<DeviceInfo>(SerializerOptions);
                            if (device is null)
                            {
                                throw new InvalidOperationException($"The device {prop.Name} info could not be parsed.");
                            }
                            return (prop.Name, device);
                        })
                        .Select(d => new KeyValuePair<string, DeviceInfo>(d.Name, d.device));

                        engineersData = new Dictionary<string, DeviceInfo>(devices);
                        engineersDataTimestamp = liveData.EngineersTimestamp;
                    }
                }
                finally
                {
                    dataLock.Release();
                }
            }
            return engineersData;
        }

        public async Task<NeoHubInfo?> GetHubInfo()
        {
            ReadOnlyMemory<byte> data = await tcpClient.InvokeCommandAsync(NeoCommands.GET_SYSTEM);

            return JsonSerializer.Deserialize<NeoHubInfo>(data.Span, SerializerOptions);
        }

        public async Task<IDictionary<string, NeoPlug>> GetNeoPlugs()
        {
            var liveData = await GetLiveData();
            var devices = await GetDeviceInfo();

            var plugs = devices
            .Where(kv => kv.Value.DeviceType == DeviceType.NeoPlug)
            .Select(kv => new KeyValuePair<string, NeoPlug>(kv.Key, new(tcpClient, kv.Key, kv.Value, GetDeviceLiveData(liveData, kv.Value.DeviceId))));

            return new Dictionary<string, NeoPlug>(plugs);
        }

        public async Task<IDictionary<string, NeoStat>> GetNeoStats()
        {
            var liveData = await GetLiveData();
            var devices = await GetDeviceInfo();

            var stats = devices
            .Where(kv => kv.Value.DeviceType == DeviceType.NeoStatV1 || kv.Value.DeviceType == DeviceType.NeoStatV2)
            .Select(kv =>
            {
                return new KeyValuePair<string, NeoStat>(kv.Key, new(tcpClient, kv.Key, kv.Value, GetDeviceLiveData(liveData, kv.Value.DeviceId)));
            });

            return new Dictionary<string, NeoStat>(stats);
        }

        private static LiveDeviceData GetDeviceLiveData(LiveData data, int deviceId) => data.Devices.Where(d => d.DeviceId == deviceId).First();


        public async Task<IDictionary<int, string>> GetZones()
        {
            ReadOnlyMemory<byte> data = await tcpClient.InvokeCommandAsync(NeoCommands.GET_ZONES);
            var obj = JsonDocument.Parse(data);

            return new Dictionary<int, string>(obj.RootElement.EnumerateObject().Select(prop => new KeyValuePair<int, string>(prop.Value.GetInt32(), prop.Name)));
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