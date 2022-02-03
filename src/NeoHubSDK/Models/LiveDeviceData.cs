using System.Text.Json.Serialization;

namespace Heatmiser.NeoHubSDK
{
    public record LiveDeviceData
    {
        [JsonPropertyName("ACTIVE_LEVEL")]
        public int ActiveLevel { get; init; }

        [JsonPropertyName("ACTIVE_PROFILE")]
        public int ActiveProfile { get; init; }

        [JsonPropertyName("ACTUAL_TEMP")]
        public float ActualTemp { get; init; }

        [JsonPropertyName("AVAILABLE_MODES")]
        public string[] AvailableModes { get; init; } = Array.Empty<string>();

        [JsonPropertyName("AWAY")]
        public bool Away { get; init; }

        [JsonPropertyName("COOL_MODE")]
        public bool CoolMode { get; init; }

        [JsonPropertyName("COOL_ON")]
        public bool CoolOn { get; init; }

        [JsonPropertyName("COOL_TEMP")]
        public float CoolTemp { get; init; }

        [JsonPropertyName("CURRENT_FLOOR_TEMPERATURE")]
        public float CurrentFloorTemperature { get; init; }

        [JsonPropertyName("DATE")]
        public string? Day { get; init; }

        [JsonPropertyName("DEVICE_ID")]
        public int DeviceId { get; init; }

        [JsonPropertyName("FAN_CONTROL")]
        public string? FanControl { get; init; }

        [JsonPropertyName("FAN_SPEED")]
        public string? FanSpeed { get; init; }

        [JsonPropertyName("FLOOR_LIMIT")]
        public bool FloorLimit { get; init; }

        [JsonPropertyName("HC_MODE")]
        public string? HCMode { get; init; }

        [JsonPropertyName("HEAT_MODE")]
        public bool HeatMode { get; init; }

        [JsonPropertyName("HEAT_ON")]
        public bool HeatOn { get; init; }

        [JsonPropertyName("HOLD_COOL")]
        public int HoldCool { get; init; }

        [JsonPropertyName("HOLD_OFF")]
        public bool HoldOff { get; init; }

        [JsonPropertyName("HOLD_ON")]
        public bool HoldOn { get; init; }

        [JsonPropertyName("HOLD_TEMP")]
        public float HoldTemperature { get; init; }

        [JsonPropertyName("HOLD_TIME")]
        public string? HoldTime { get; init; } //"0:00",

        [JsonPropertyName("HOLIDAY")]
        public bool Holiday { get; init; }

        [JsonPropertyName("LOCK")]
        public bool Locked { get; init; }

        [JsonPropertyName("LOW_BATTERY")]
        public bool LowBattery { get; init; }

        [JsonPropertyName("MANUAL_OFF")]
        public bool ManualOff { get; init; }

        [JsonPropertyName("MODELOCK")]
        public bool ModeLock { get; init; }

        [JsonPropertyName("MODULATION_LEVEL")]
        public int ModulationLevel { get; init; }

        [JsonPropertyName("OFFLINE")]
        public bool Offline { get; init; }

        [JsonPropertyName("PIN_NUMBER")]
        public string? PinNumber { get; init; }

        [JsonPropertyName("PREHEAT_ACTIVE")]
        public bool PreheatActive { get; init; }

        [JsonPropertyName("PRG_TEMP")]
        public float ProgramTemperature { get; init; }

        [JsonPropertyName("PRG_TIMER")]
        public bool ProgramTimer { get; init; }

        [JsonPropertyName("RECENT_TEMPS")]
        public float[] RecentTemperatures { get; init; } = Array.Empty<float>();

        [JsonPropertyName("SET_TEMP")]
        public float SetTemperature { get; init; }

        [JsonPropertyName("STANDBY")]
        public bool Standby { get; init; }

        [JsonPropertyName("SWITCH_DELAY_LEFT")]
        public string? SwitchDelayLeft { get; init; }

        [JsonPropertyName("TEMPORARY_SET_FLAG")]
        public bool TemporarySetFlag { get; init; }

        [JsonPropertyName("THERMOSTAT")]
        public bool Thermostat { get; init; }

        [JsonPropertyName("TIME")]
        public string? Time { get; init; } //"17:32",

        [JsonPropertyName("TIMER_ON")]
        public bool TimerOn { get; init; }

        [JsonPropertyName("WINDOW_OPEN")]
        public bool WindowOpen { get; init; }

        [JsonPropertyName("WRITE_COUNT")]
        public int WriteCount { get; init; }

        [JsonPropertyName("ZONE_NAME")]
        public string ZoneName { get; init; } = String.Empty;
    }
}
