using System;
using System.Text.Json.Serialization;

namespace Heatmiser.NeoHubSDK
{
    public class LiveData
    {
        [JsonPropertyName("CLOSE_DELAY")]
        public int CloseDelay { get; set; }

        [JsonPropertyName("COOL_INPUT")]
        public bool CoolInput { get; set; }

        [JsonPropertyName("HOLIDAY_END")]
        public int HolidayEnd { get; set; }

        [JsonPropertyName("HUB_AWAY")]
        public bool HubAway { get; set; }

        [JsonPropertyName("HUB_HOLIDAY")]
        public bool HubHoliday { get; set; }

        [JsonPropertyName("HUB_TIME")]
        public int HubTime { get; set; }

        [JsonPropertyName("OPEN_DELAY")]
        public int OpenDelay { get; set; }

        [JsonPropertyName("TIMESTAMP_DEVICE_LISTS")]
        public DateTime DeviceListTimestamp { get; set; }

        [JsonPropertyName("TIMESTAMP_ENGINEERS")]
        public DateTime EngineersTimestamp { get; set; }

        [JsonPropertyName("TIMESTAMP_PROFILE_0")]
        public DateTime Profile0Timestamp { get; set; }

        [JsonPropertyName("TIMESTAMP_PROFILE_COMFORT_LEVELS")]
        public DateTime ProfileComfortLevelsTimestamp { get; set; }

        [JsonPropertyName("TIMESTAMP_PROFILE_TIMERS")]
        public DateTime TimerProfilesTimestamp { get; set; }

        [JsonPropertyName("TIMESTAMP_PROFILE_TIMERS_0")]
        public DateTime Timer0ProfileTimestamp { get; set; }

        [JsonPropertyName("TIMESTAMP_RECIPES")]
        public DateTime RecipesTimestamp { get; set; }

        [JsonPropertyName("TIMESTAMP_SYSTEM")]
        public DateTime SystemTimestamp { get; set; }

        [JsonPropertyName("devices")]
        public LiveDeviceData[]? Devices { get; set; }
    }
}
