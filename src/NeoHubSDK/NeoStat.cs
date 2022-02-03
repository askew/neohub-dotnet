namespace Heatmiser.NeoHubSDK
{
    public class NeoStat : NeoDevice
    {
        internal NeoStat(INeoTcpClient client, string name, DeviceInfo deviceInfo, LiveDeviceData liveData) : base(client, name, deviceInfo, liveData)
        {
            if (deviceInfo.DeviceType != DeviceType.NeoStatV1 &&
                deviceInfo.DeviceType != DeviceType.NeoStatV2)
            {
                throw new ArgumentException("The specified device info does not represent a NetStat device.");
            }
        }

        public bool IsOn
        {
            get
            {
                return LiveData.Thermostat ? LiveData.HeatOn : LiveData.TimerOn;
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
