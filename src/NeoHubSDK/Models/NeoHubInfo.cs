using System.Text.Json.Serialization;

namespace Heatmiser.NeoHubSDK
{
    /// <summary>
    /// Represents information and system settings for a NeoHub device.
    /// </summary>
    public class NeoHubInfo
    {
        [JsonPropertyName("ALT_TIMER_FORMAT")]
        public string? AlternativeTimerFormat { get; set; }

        [JsonPropertyName("CORF")]
        public string? Corf { get; set; }

        [JsonPropertyName("DEVICE_ID")]
        public string? DeviceId { get; set; }

        [JsonPropertyName("DST_AUTO")]
        public bool DaylightSavingTimeAuto { get; set; }

        [JsonPropertyName("DST_ON")]
        public bool DaylightSavingTimeOn { get; set; }

        [JsonPropertyName("FORMAT")]
        public int Format { get; set; }

        [JsonPropertyName("HEATING_LEVELS")]
        public int HeatingLevels { get; set; }

        [JsonPropertyName("HEATORCOOL")]
        public string? HeatOrCool { get; set; }

        [JsonPropertyName("HUB_TYPE")]
        public int HubType { get; set; }

        [JsonPropertyName("HUB_VERSION")]
        public int HubVersion { get; set; }

        [JsonPropertyName("NTP_ON")]
        public string? NtpOn { get; set; }

        [JsonPropertyName("PARTITION")]
        public string? Partition { get; set; }

        [JsonPropertyName("TIMESTAMP")]
        public int Timestamp { get; set; }

        [JsonPropertyName("TIME_ZONE")]
        public float TimeZone { get; set; }

        [JsonPropertyName("TIMEZONESTR")]
        public string? TimeZoneString { get; set; }

        [JsonPropertyName("UTC")]
        public int Utc { get; set; }
    }
}
