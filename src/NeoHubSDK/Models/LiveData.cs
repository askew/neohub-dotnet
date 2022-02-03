using System;
using System.Text.Json.Serialization;

namespace Heatmiser.NeoHubSDK
{
    public record LiveData
    {
        [JsonPropertyName("CLOSE_DELAY")]
        public int CloseDelay { get; init; }

        [JsonPropertyName("COOL_INPUT")]
        public bool CoolInput { get; init; }

        [JsonPropertyName("HOLIDAY_END")]
        public int HolidayEnd { get; init; }

        [JsonPropertyName("HUB_AWAY")]
        public bool HubAway { get; init; }

        [JsonPropertyName("HUB_HOLIDAY")]
        public bool HubHoliday { get; init; }

        [JsonPropertyName("HUB_TIME")]
        public int HubTime { get; init; }

        [JsonPropertyName("OPEN_DELAY")]
        public int OpenDelay { get; init; }

        [JsonPropertyName("TIMESTAMP_DEVICE_LISTS")]
        public DateTime DeviceListTimestamp { get; init; }

        [JsonPropertyName("TIMESTAMP_ENGINEERS")]
        public DateTime EngineersTimestamp { get; init; }

        [JsonPropertyName("TIMESTAMP_PROFILE_0")]
        public DateTime Profile0Timestamp { get; init; }

        [JsonPropertyName("TIMESTAMP_PROFILE_COMFORT_LEVELS")]
        public DateTime ProfileComfortLevelsTimestamp { get; init; }

        [JsonPropertyName("TIMESTAMP_PROFILE_TIMERS")]
        public DateTime TimerProfilesTimestamp { get; init; }

        [JsonPropertyName("TIMESTAMP_PROFILE_TIMERS_0")]
        public DateTime Timer0ProfileTimestamp { get; init; }

        [JsonPropertyName("TIMESTAMP_RECIPES")]
        public DateTime RecipesTimestamp { get; init; }

        [JsonPropertyName("TIMESTAMP_SYSTEM")]
        public DateTime SystemTimestamp { get; init; }

        [JsonPropertyName("devices")]
        public LiveDeviceData[] Devices { get; init; } = Array.Empty<LiveDeviceData>();
    }
}
