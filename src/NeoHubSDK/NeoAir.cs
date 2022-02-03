namespace Heatmiser.NeoHubSDK
{
    public class NeoAir : NeoDevice
    {
        internal NeoAir(INeoTcpClient client, string name, DeviceInfo deviceInfo, LiveDeviceData liveData) : base(client, name, deviceInfo, liveData)
        {
            if (deviceInfo.DeviceType != DeviceType.NeoAir &&
                deviceInfo.DeviceType != DeviceType.NeoAirV2 &&
                deviceInfo.DeviceType != DeviceType.NeoAirV2Combined)
            {
                throw new ArgumentException("The specified device info does not represent a NetStat device.");
            }
        }

        public bool IsHeatOn
        {
            get
            {
                return LiveData.HeatOn;
            }
        }

        public bool IsTimerOn
        {
            get
            {
                return LiveData.TimerOn;
            }
        }

        public float SetTemperature
        {
            get
            {
                return LiveData.SetTemperature;
            }
        }

        public bool IsThermostat
        {
            get
            {
                return LiveData.Thermostat;
            }
        }

        public bool IsTimerSwitch
        {
            get
            {
                return !LiveData.Thermostat;
            }
        }

        public float Temperature
        {
            get
            {
                return LiveData.ActualTemp;
            }
        }
    }
}
