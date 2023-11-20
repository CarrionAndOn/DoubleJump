namespace DoubleJump.Melon;

internal static class Preferences
{
    public static readonly MelonPreferences_Category GlobalCategory = MelonPreferences.CreateCategory("Global");
    public static readonly MelonPreferences_Category OwnCategory = MelonPreferences.CreateCategory("Double Jump");
        
    public static MelonPreferences_Entry<bool> AutoEnable { get; set;}
    public static MelonPreferences_Entry<int> LoggingMode { get; set; }

    public static void Setup()
    {
        AutoEnable = OwnCategory.CreateEntry("AutoEnable", true, "Auto Enable", "Automatically enables double jump when you load into a level");
        LoggingMode = GlobalCategory.GetEntry<int>("LoggingMode") ?? GlobalCategory.CreateEntry("LoggingMode", 0, "Logging Mode", "The level of logging to use. 0 = Important Only, 1 = All");
        GlobalCategory.SetFilePath(MelonUtils.UserDataDirectory+"/WeatherElectric.cfg");
        GlobalCategory.SaveToFile(false);
        OwnCategory.SetFilePath(MelonUtils.UserDataDirectory+"/WeatherElectric.cfg");
        OwnCategory.SaveToFile(false);
        ModConsole.Msg("Finished preferences setup for Double Jump", 1);
    }
}