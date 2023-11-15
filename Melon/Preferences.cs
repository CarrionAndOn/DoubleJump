using MelonLoader;

namespace DoubleJump.Melon
{
    internal static class Preferences
    {
        public static readonly MelonPreferences_Category GlobalCategory = MelonPreferences.CreateCategory("Global");
        public static readonly MelonPreferences_Category OwnCategory = MelonPreferences.CreateCategory("Double Jump");
        
        public static ModPref<LoggingMode> LoggingMode;

        public static ModPref<bool> AutoEnable;

        public static void Setup()
        {
            AutoEnable = new ModPref<bool>(OwnCategory, "AutoEnable", false);
            LoggingMode = new ModPref<LoggingMode>(GlobalCategory, "LoggingMode", global::LoggingMode.NORMAL, "Logging Mode", "The level of logging to use. DEBUG = Everything, NORMAL = Important Only");
            GlobalCategory.SetFilePath(MelonUtils.UserDataDirectory+"/WeatherElectric.cfg");
            GlobalCategory.SaveToFile(false);
            OwnCategory.SetFilePath(MelonUtils.UserDataDirectory+"/WeatherElectric.cfg");
            OwnCategory.SaveToFile(false);
            ModConsole.Msg("Finished preferences setup for DoubleJump", global::LoggingMode.DEBUG);
        }
    }
}