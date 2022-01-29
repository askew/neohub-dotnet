using System;
using System.Text.Json.Serialization;

namespace Heatmiser.NeoHubSDK
{
    public class EngineerData
    {
        [JsonPropertyName("COOL_ENABLE")]
        public bool CoolEnable { get; set; }

        [JsonPropertyName("DEADBAND")]
        public int DeadBand { get; set; }

        [JsonPropertyName("DEVICE_ID")]
        public int DeviceId { get; set; }

        [JsonPropertyName("DEVICE_TYPE")]
        public int DeviceType { get; set; }

        [JsonPropertyName("DEW_POINT")]
        public bool DewPoint { get; set; }

        [JsonPropertyName("FLOOR_LIMIT")]
        public int FloorLimit { get; set; }

        [JsonPropertyName("FROST_TEMP")]
        public float FrostTemp { get; set; }

        [JsonPropertyName("MAX_PREHEAT")]
        public int MaxPreHeat { get; set; }

        [JsonPropertyName("OUTPUT_DELAY")]
        public int OutputDelay { get; set; }

        [JsonPropertyName("PUMP_DELAY")]
        public int PumpDelay { get; set; }

        [JsonPropertyName("RF_SENSOR_MODE")]
        public string? RFSensorMode { get; set; }

        [JsonPropertyName("SENSOR_MODE")]
        public string? SensorMode { get; set; }

        [JsonPropertyName("STAT_FAILSAFE")]
        public int StatFailsafe { get; set; }

        [JsonPropertyName("STAT_VERSION")]
        public int StatVersion { get; set; }

        [JsonPropertyName("SWITCHING DIFFERENTIAL")]
        public int SwitchingDifferential { get; set; }

        [JsonPropertyName("SWITCH_DELAY")]
        public int SwitchDelay { get; set; }

        [JsonPropertyName("SYSTEM_TYPE")]
        public int SystemType { get; set; }

        [JsonPropertyName("TIMESTAMP")]
        public DateTime TimeStamp { get; set; }

        [JsonPropertyName("ULTRA_VERSION")]
        public int UltraVersion { get; set; }

        [JsonPropertyName("USER_LIMIT")]
        public int UserLimit { get; set; }

        [JsonPropertyName("WINDOW_SWITCH_OPEN")]
        public bool WindowSwitchOpen { get; set; }
    }
}
