namespace Heatmiser.NeoHubSDK
{
    internal static class NeoCommands
    {
        internal const string AUTO_MODE_OFF = "AUTO_MODE_OFF";
        internal const string AWAY_OFF = "AWAY_OFF";
        internal const string AWAY_ON = "AWAY_ON";
        internal const string BOOST_OFF = "BOOST_OFF";
        internal const string BOOST_ON = "BOOST_ON";
        internal const string CANCEL_HGROUP = "CANCEL_HGROUP";
        internal const string CANCEL_HOLD_ALL = "CANCEL_HOLD_ALL";
        internal const string CANCEL_HOLIDAY = "CANCEL_HOLIDAY";
        internal const string CLEAR_CURRENT_PROFILE = "CLEAR_CURRENT_PROFILE";
        internal const string CLEAR_DEVICE_LIST = "CLEAR_DEVICE_LIST";
        internal const string CLEAR_PROFILE = "CLEAR_PROFILE";
        internal const string CLEAR_PROFILE_ID = "CLEAR_PROFILE_ID";
        internal const string CREATE_GROUP = "CREATE_GROUP";
        internal const string DELETE_GROUP = "DELETE_GROUP";
        internal const string DETACH_DEVICE = "DETACH_DEVICE";
        internal const string DEVICES_SN = "DEVICES_SN";
        internal const string DST_OFF = "DST_OFF";
        internal const string DST_ON = "DST_ON";
        internal const string ENGINEERS_DATA = "ENGINEERS_DATA";
        internal const string FAN = "FAN";
        internal const string FIRMWARE = "FIRMWARE";
        internal const string FROST_OFF = "FROST_OFF";
        internal const string FROST_ON = "FROST_ON";
        internal const string GET_DEVICE_LIST = "GET_DEVICE_LIST";
        internal const string GET_DEVICES = "GET_DEVICES";
        internal const string GET_ENGINEERS = "GET_ENGINEERS";
        internal const string GET_GROUPS = "GET_GROUPS";
        internal const string GET_HOLD = "GET_HOLD";
        internal const string GET_HOLIDAY = "GET_HOLIDAY";
        internal const string GET_HOURSRUN = "GET_HOURSRUN";
        internal const string GET_LIVE_DATA = "GET_LIVE_DATA";
        internal const string GET_PROFILE = "GET_PROFILE";
        internal const string GET_PROFILE_0 = "GET_PROFILE_0";
        internal const string GET_PROFILE_NAMES = "GET_PROFILE_NAMES";
        internal const string GET_PROFILE_TIMERS = "GET_PROFILE_TIMERS";
        internal const string GET_PROFILES = "GET_PROFILES";
        internal const string GET_SYSTEM = "GET_SYSTEM";
        internal const string GET_TEMPLOG = "GET_TEMPLOG";
        internal const string GET_TIMER_0 = "GET_TIMER_0";
        internal const string GET_ZONES = "GET_ZONES";
        internal const string GLOBAL_DEV_LIST = "GLOBAL_DEV_LIST";
        internal const string HOLD = "HOLD";
        internal const string HOLIDAY = "HOLIDAY";
        internal const string IDENTIFY = "IDENTIFY";
        internal const string IDENTIFY_DEVICE = "IDENTIFY_DEVICE";
        internal const string INFO = "INFO";
        internal const string LINK_DEVICE = "LINK_DEVICE";
        internal const string LOCK = "LOCK";
        internal const string MANUAL_DST = "MANUAL_DST";
        internal const string MANUAL_OFF = "MANUAL_OFF";
        internal const string MANUAL_ON = "MANUAL_ON";
        internal const string NTP_OFF = "NTP_OFF";
        internal const string NTP_ON = "NTP_ON";
        internal const string PERMIT_JOIN = "PERMIT_JOIN";
        internal const string PROFILE_TITLE = "PROFILE_TITLE";
        internal const string READ_COMFORT_LEVELS = "READ_COMFORT_LEVELS";
        internal const string READ_DCB = "READ_DCB";
        internal const string READ_TIMECLOCK = "READ_TIMECLOCK";
        internal const string REMOVE_REPEATER = "REMOVE_REPEATER";
        internal const string REMOVE_ZONE = "REMOVE_ZONE";
        internal const string RUN_PROFILE = "RUN_PROFILE";
        internal const string RUN_PROFILE_ID = "RUN_PROFILE_ID";
        internal const string SET_CHANNEL = "SET_CHANNEL";
        internal const string SET_CLOSE_DELAY = "SET_CLOSE_DELAY";
        internal const string SET_COMFORT_LEVELS = "SET_COMFORT_LEVELS";
        internal const string SET_COOL_TEMP = "SET_COOL_TEMP";
        internal const string SET_DATE = "SET_DATE";
        internal const string SET_DELAY = "SET_DELAY";
        internal const string SET_DIFF = "SET_DIFF";
        internal const string SET_FAILSAFE = "SET_FAILSAFE";
        internal const string SET_FLOOR = "SET_FLOOR";
        internal const string SET_FORMAT = "SET_FORMAT";
        internal const string SET_FROST = "SET_FROST";
        internal const string SET_LEVEL_4 = "SET_LEVEL_4";
        internal const string SET_LEVEL_6 = "SET_LEVEL_6";
        internal const string SET_OPEN_DELAY = "SET_OPEN_DELAY";
        internal const string SET_PREHEAT = "SET_PREHEAT";
        internal const string SET_RF_MODE = "SET_RF_MODE";
        internal const string SET_TEMP = "SET_TEMP";
        internal const string SET_TEMP_FORMAT = "SET_TEMP_FORMAT";
        internal const string SET_TIME = "SET_TIME";
        internal const string SET_TIMECLOCK = "SET_TIMECLOCK";
        internal const string STATISTICS = "STATISTICS";
        internal const string STORE_PROFILE = "STORE_PROFILE";
        internal const string STORE_PROFILE_0 = "STORE_PROFILE_0";
        internal const string STORE_PROFILE_TIMER_0 = "STORE_PROFILE_TIMER_0";
        internal const string SUMMER_OFF = "SUMMER_OFF";
        internal const string SUMMER_ON = "SUMMER_ON";
        internal const string TIME_ZONE = "TIME_ZONE";
        internal const string TIMER_HOLD_OFF = "TIMER_HOLD_OFF";
        internal const string TIMER_HOLD_ON = "TIMER_HOLD_ON";
        internal const string TIMER_OFF = "TIMER_OFF";
        internal const string TIMER_ON = "TIMER_ON";
        internal const string UNLOCK = "UNLOCK";
        internal const string USER_LIMIT = "USER_LIMIT";
        internal const string VIEW_ROC = "VIEW_ROC";
        internal const string ZONE_TITLE = "ZONE_TITLE";

        internal static class Stat
        {
            internal const string AWAY_OFF = "AWAY_OFF";
            internal const string AWAY_ON = "AWAY_ON";
            internal const string BOOST_OFF = "BOOST_OFF";
            internal const string BOOST_ON = "BOOST_ON";
            internal const string COOL = "COOL";
            internal const string COOL_DEFAULT = "COOL_DEFAULT";
            internal const string FROST_OFF = "FROST_OFF";
            internal const string FROST_ON = "FROST_ON";
            internal const string HEAT = "HEAT";
            internal const string LOCK = "LOCK";
            internal const string UNLOCK = "UNLOCK";
            internal const string SET_COOL_TEMP = "SET_COOL_TEMP";
            internal const string SET_DELAY = "SET_DELAY";
            internal const string SET_DIFF = "SET_DIFF";
            internal const string SET_FLOOR = "SET_FLOOR";
            internal const string SET_FROST = "SET_FROST";
            internal const string SET_PREHEAT = "SET_PREHEAT";
            internal const string SET_TEMP = "SET_TEMP";
            internal const string READ_COMFORT_LEVELS = "READ_COMFORT_LEVELS";
            internal const string SET_COMFORT_LEVELS = "SET_COMFORT_LEVELS";
            internal const string READ_TIMECLOCK = "READ_TIMECLOCK";
            internal const string SET_TIMECLOCK = "SET_TIMECLOCK";
            internal const string SUMMER_OFF = "SUMMER_OFF";
            internal const string SUMMER_ON = "SUMMER_ON";
            internal const string USER_LIMIT = "USER_LIMIT";
            internal const string VIEW_ROC = "VIEW_ROC";
            internal const string TIMER_ON = "TIMER_ON";
            internal const string TIMER_OFF = "TIMER_OFF";
            internal const string TIMER_HOLD_ON = "TIMER_HOLD_ON";
            internal const string TIMER_HOLD_OFF = "TIMER_HOLD_OFF";
        }

        internal static class Hub
        {
            internal const string HOLD = "HOLD";
            internal const string CANCEL_HGROUP = "CANCEL_HGROUP";
            internal const string CANCEL_HOLD_ALL = "CANCEL_HOLD_ALL";
            internal const string GET_HOLD = "GET_HOLD";
            internal const string HOLIDAY = "HOLIDAY";
            internal const string CANCEL_HOLIDAY = "CANCEL_HOLIDAY";
            internal const string GET_HOLIDAY = "GET_HOLIDAY";
            internal const string STORE_PROFILE = "STORE_PROFILE";
            internal const string CLEAR_PROFILE = "CLEAR_PROFILE";
            internal const string GET_PROFILE = "GET_PROFILE";
            internal const string GET_PROFILES = "GET_PROFILES";
            internal const string RUN_PROFILE = "RUN_PROFILE";
            internal const string CREATE_GROUP = "CREATE_GROUP";
            internal const string DELETE_GROUP = "DELETE_GROUP";
            internal const string GET_GROUPS = "GET_GROUPS";
            internal const string ZONE_TITLE = "ZONE_TITLE";
            internal const string GET_ZONES = "GET_ZONES";
            internal const string PERMIT_JOIN = "PERMIT_JOIN";
            internal const string REMOVE_ZONE = "REMOVE_ZONE";
            internal const string REMOVE_REPEATER = "REMOVE_REPEATER";
            internal const string ENGINEERS_DATA = "ENGINEERS_DATA";
            internal const string FIRMWARE = "FIRMWARE";
            internal const string GET_HOURSRUN = "GET_HOURSRUN";
            internal const string INFO = "INFO";
            internal const string GET_TEMPLOG = "GET_TEMPLOG";
            internal const string STATISTICS = "STATISTICS";
            internal const string SET_FORMAT = "SET_FORMAT";
            internal const string SET_TEMP_FORMAT = "SET_TEMP_FORMAT";
            internal const string SET_DATE = "SET_DATE";
            internal const string SET_TIME = "SET_TIME";
            internal const string TIME_ZONE = "TIME_ZONE";
            internal const string DST_ON = "DST_ON";
            internal const string DST_OFF = "DST_OFF";
            internal const string MANUAL_DST = "MANUAL_DST";
            internal const string NTP_ON = "NTP_ON";
            internal const string NTP_OFF = "NTP_OFF";
            internal const string READ_DCB = "READ_DCB";
        }

        internal static class Plug
        {
            internal const string MANUAL_ON = "MANUAL_ON";
            internal const string MANUAL_OFF = "MANUAL_OFF";
        }
    }
}
