using System;
using System.Text.Json.Serialization;

namespace Heatmiser.NeoHubSDK
{
    /// <summary>
    /// Represents the data returned from the Neo Hub by the GET_ENGINEERS command.
    /// </summary>
    public record DeviceInfo
    {
        [JsonConstructor]
        public DeviceInfo(int deadband, int deviceId, DeviceType deviceType, int floorLimit, float frostTemperature,
            int maxPreheat, int outputDelay, int pumpDelay, string? rFSensorMode, int thermostatFailsafe, int thermostatVersion, int switchingDifferential,
            int switchDelay, int systemType, DateTime timestamp, int userLimit, bool windowSwitchOpen) => (Deadband, DeviceId, DeviceType, FloorLimit, FrostTemperature,
            MaxPreheat, OutputDelay, PumpDelay, RFSensorMode, ThermostatFailsafe, ThermostatVersion, SwitchingDifferential,
            SwitchDelay, SystemType, Timestamp, UserLimit, WindowSwitchOpen) = (deadband, deviceId, deviceType, floorLimit, frostTemperature,
            maxPreheat, outputDelay, pumpDelay, rFSensorMode, thermostatFailsafe, thermostatVersion, switchingDifferential,
            switchDelay, systemType, timestamp, userLimit, windowSwitchOpen);

        [JsonIgnore]
        public string? Name { get; set; }

        [JsonPropertyName("DEADBAND")]
        public int Deadband { get; }

        [JsonPropertyName("DEVICE_ID")]
        public int DeviceId { get; }

        [JsonPropertyName("DEVICE_TYPE")]
        public DeviceType DeviceType { get; }

        [JsonPropertyName("FLOOR_LIMIT")]
        public int FloorLimit { get; }

        [JsonPropertyName("FROST_TEMP")]
        public float FrostTemperature { get; }

        [JsonPropertyName("MAX_PREHEAT")]
        public int MaxPreheat { get; }

        [JsonPropertyName("OUTPUT_DELAY")]
        public int OutputDelay { get; }

        [JsonPropertyName("PUMP_DELAY")]
        public int PumpDelay { get; }

        [JsonPropertyName("RF_SENSOR_MODE")]
        public string? RFSensorMode { get; }

        [JsonPropertyName("STAT_FAILSAFE")]
        public int ThermostatFailsafe { get; }

        [JsonPropertyName("STAT_VERSION")]
        public int ThermostatVersion { get; }

        [JsonPropertyName("SWITCHING DIFFERENTIAL")]
        public int SwitchingDifferential { get; }

        [JsonPropertyName("SWITCH_DELAY")]
        public int SwitchDelay { get; }

        [JsonPropertyName("SYSTEM_TYPE")]
        public int SystemType { get; }

        [JsonPropertyName("TIMESTAMP")]
        public DateTime Timestamp { get; }

        [JsonPropertyName("USER_LIMIT")]
        public int UserLimit { get; }

        [JsonPropertyName("WINDOW_SWITCH_OPEN")]
        public bool WindowSwitchOpen { get; }
    }
}
