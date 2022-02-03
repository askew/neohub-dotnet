using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heatmiser.NeoHubSDK
{
    public class NeoDevice
    {
        internal NeoDevice(INeoTcpClient client, string name, DeviceInfo deviceInfo, LiveDeviceData liveData)
        {
            Hub = client;
            Name = name;
            DeviceId = deviceInfo.DeviceId;
            LiveData = liveData;
        }

        protected INeoTcpClient Hub { get; }

        protected LiveDeviceData LiveData { get; }

        public string Name { get; }

        public int DeviceId { get; }
    }
}
