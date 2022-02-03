using Heatmiser.NeoHubSDK.Models;
using System.Text.Json;

namespace Heatmiser.NeoHubSDK
{
    public class NeoPlug : NeoDevice
    {
        internal NeoPlug(INeoTcpClient client, string name, DeviceInfo deviceInfo, LiveDeviceData liveData) : base(client, name, deviceInfo, liveData)
        {
            if (deviceInfo.DeviceType != DeviceType.NeoPlug)
            {
                throw new ArgumentException("The specified device info does not represent a NeoPlug device.");
            }
        }

        public async Task<string?> TurnOn()
        {
            var data = await Hub.InvokeCommandAsync(NeoCommands.TIMER_ON, Name);
            var result = JsonSerializer.Deserialize<CommandResult>(data.Span);
            return result?.Result;
        }

        public async Task<string?> TurnOff()
        {
            var data = await Hub.InvokeCommandAsync(NeoCommands.TIMER_OFF, Name);
            var result = JsonSerializer.Deserialize<CommandResult>(data.Span);
            return result?.Result;
        }

        public bool IsOn
        {
            get
            {
                return LiveData.TimerOn;
            }
        }
    }
}
