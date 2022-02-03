using System;
using System.Text.Json.Serialization;

namespace Heatmiser.NeoHubSDK
{
    /// <summary>
    /// Represents the data returned from the Neo Hub by the GET_ENGINEERS command.
    /// </summary>
    public record DeviceInfo
    {
        [JsonPropertyName("DEADBAND")]
        public int Deadband { get; init; }

        [JsonPropertyName("DEVICE_ID")]
        public int DeviceId { get; init; }

        [JsonPropertyName("DEVICE_TYPE")]
        public DeviceType DeviceType { get; init; }

        [JsonPropertyName("FLOOR_LIMIT")]
        public int FloorLimit { get; init; }

        [JsonPropertyName("FROST_TEMP")]
        public float FrostTemperature { get; init; }

        [JsonPropertyName("MAX_PREHEAT")]
        public int MaxPreheat { get; init; }

        [JsonPropertyName("OUTPUT_DELAY")]
        public int OutputDelay { get; init; }

        [JsonPropertyName("PUMP_DELAY")]
        public int PumpDelay { get; init; }

        [JsonPropertyName("RF_SENSOR_MODE")]
        public string? RFSensorMode { get; init; }

        [JsonPropertyName("STAT_FAILSAFE")]
        public int ThermostatFailsafe { get; init; }

        [JsonPropertyName("STAT_VERSION")]
        public int ThermostatVersion { get; init; }

        [JsonPropertyName("SWITCHING DIFFERENTIAL")]
        public int SwitchingDifferential { get; init; }

        [JsonPropertyName("SWITCH_DELAY")]
        public int SwitchDelay { get; init; }

        [JsonPropertyName("SYSTEM_TYPE")]
        public int SystemType { get; init; }

        [JsonPropertyName("TIMESTAMP")]
        public DateTime Timestamp { get; init; }

        [JsonPropertyName("USER_LIMIT")]
        public int UserLimit { get; init; }

        [JsonPropertyName("WINDOW_SWITCH_OPEN")]
        public bool WindowSwitchOpen { get; init; }
    }
}
