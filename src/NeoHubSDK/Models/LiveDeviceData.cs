using System.Text.Json.Serialization;

namespace Heatmiser.NeoHubSDK
{
    public record LiveDeviceData
    {
        [JsonConstructor]
        public LiveDeviceData(int activeLevel, int activeProfile, float actualTemp, string[]? availableModes, 
            bool away, bool coolMode, bool coolOn, float coolTemp, float currentFloorTemperature, 
            string? day, int deviceId, string? fanControl, string? fanSpeed, bool floorLimit, string? hCMode, 
            bool heatMode, bool heatOn, int holdCool, bool holdOff, bool holdOn, float holdTemperature, 
            string? holdTime, bool holiday, bool locked, bool lowBattery, bool manualOff, bool modeLock, 
            int modulationLevel, bool offline, string? pinNumber, bool preheatActive, 
            float programTemperature, bool programTimer, float[]? recentTemperatures, float setTemperature, 
            bool standby, string? switchDelayLeft, bool temporarySetFlag, bool thermostat, string? time, 
            bool timerOn, bool windowOpen, int writeCount, string? zoneName ) => (ActiveLevel, ActiveProfile, 
            ActualTemp, AvailableModes, Away, CoolMode, CoolOn, CoolTemp, CurrentFloorTemperature, Day, 
            DeviceId, FanControl, FanSpeed, FloorLimit, HCMode, HeatMode, HeatOn, HoldCool, HoldOff, HoldOn, 
            HoldTemperature, HoldTime, Holiday, Locked, LowBattery, ManualOff, ModeLock, ModulationLevel, 
            Offline, PinNumber, PreheatActive, ProgramTemperature, ProgramTimer, RecentTemperatures, 
            SetTemperature, Standby, SwitchDelayLeft, TemporarySetFlag, Thermostat, Time, TimerOn, 
            WindowOpen, WriteCount, ZoneName) = (activeLevel, activeProfile, actualTemp, availableModes,
            away, coolMode, coolOn, coolTemp, currentFloorTemperature, day, deviceId, fanControl, fanSpeed, 
            floorLimit, hCMode, heatMode, heatOn, holdCool, holdOff, holdOn, holdTemperature, holdTime, 
            holiday, locked, lowBattery, manualOff, modeLock, modulationLevel, offline, pinNumber, 
            preheatActive, programTemperature, programTimer, recentTemperatures, setTemperature, standby, 
            switchDelayLeft, temporarySetFlag, thermostat, time, timerOn, windowOpen, writeCount, zoneName);

        [JsonPropertyName("ACTIVE_LEVEL")]
        public int ActiveLevel { get; }

        [JsonPropertyName("ACTIVE_PROFILE")]
        public int ActiveProfile { get; }

        [JsonPropertyName("ACTUAL_TEMP")]
        public float ActualTemp { get; }

        [JsonPropertyName("AVAILABLE_MODES")]
        public string[]? AvailableModes { get; }

        [JsonPropertyName("AWAY")]
        public bool Away { get; }

        [JsonPropertyName("COOL_MODE")]
        public bool CoolMode { get; }

        [JsonPropertyName("COOL_ON")]
        public bool CoolOn { get; }

        [JsonPropertyName("COOL_TEMP")]
        public float CoolTemp { get; }

        [JsonPropertyName("CURRENT_FLOOR_TEMPERATURE")]
        public float CurrentFloorTemperature { get; }

        [JsonPropertyName("DATE")]
        public string? Day { get; }

        [JsonPropertyName("DEVICE_ID")]
        public int DeviceId { get; }

        [JsonPropertyName("FAN_CONTROL")]
        public string? FanControl { get; }

        [JsonPropertyName("FAN_SPEED")]
        public string? FanSpeed { get; }

        [JsonPropertyName("FLOOR_LIMIT")]
        public bool FloorLimit { get; }

        [JsonPropertyName("HC_MODE")]
        public string? HCMode { get; }

        [JsonPropertyName("HEAT_MODE")]
        public bool HeatMode { get; }

        [JsonPropertyName("HEAT_ON")]
        public bool HeatOn { get; }

        [JsonPropertyName("HOLD_COOL")]
        public int HoldCool { get; }

        [JsonPropertyName("HOLD_OFF")]
        public bool HoldOff { get; }

        [JsonPropertyName("HOLD_ON")]
        public bool HoldOn { get; }

        [JsonPropertyName("HOLD_TEMP")]
        public float HoldTemperature { get; }

        [JsonPropertyName("HOLD_TIME")]
        public string? HoldTime { get; } //"0:00",

        [JsonPropertyName("HOLIDAY")]
        public bool Holiday { get; }

        [JsonPropertyName("LOCK")]
        public bool Locked { get; }

        [JsonPropertyName("LOW_BATTERY")]
        public bool LowBattery { get; }

        [JsonPropertyName("MANUAL_OFF")]
        public bool ManualOff { get; }

        [JsonPropertyName("MODELOCK")]
        public bool ModeLock { get; }

        [JsonPropertyName("MODULATION_LEVEL")]
        public int ModulationLevel { get; }

        [JsonPropertyName("OFFLINE")]
        public bool Offline { get; }

        [JsonPropertyName("PIN_NUMBER")]
        public string? PinNumber { get; }

        [JsonPropertyName("PREHEAT_ACTIVE")]
        public bool PreheatActive { get; }

        [JsonPropertyName("PRG_TEMP")]
        public float ProgramTemperature { get; }

        [JsonPropertyName("PRG_TIMER")]
        public bool ProgramTimer { get; }

        [JsonPropertyName("RECENT_TEMPS")]
        public float[]? RecentTemperatures { get; }

        [JsonPropertyName("SET_TEMP")]
        public float SetTemperature { get; }

        [JsonPropertyName("STANDBY")]
        public bool Standby { get; }

        [JsonPropertyName("SWITCH_DELAY_LEFT")]
        public string? SwitchDelayLeft { get; }

        [JsonPropertyName("TEMPORARY_SET_FLAG")]
        public bool TemporarySetFlag { get; }

        [JsonPropertyName("THERMOSTAT")]
        public bool Thermostat { get; }

        [JsonPropertyName("TIME")]
        public string? Time { get; } //"17:32",

        [JsonPropertyName("TIMER_ON")]
        public bool TimerOn { get; }

        [JsonPropertyName("WINDOW_OPEN")]
        public bool WindowOpen { get; }

        [JsonPropertyName("WRITE_COUNT")]
        public int WriteCount { get; }

        [JsonPropertyName("ZONE_NAME")]
        public string? ZoneName { get; }
    }
}
