namespace DoubleJump.Melon;

internal static class BoneMenu
{
    public static void Setup()
    {
        MenuCategory mainCat = MenuManager.CreateCategory("Weather Electric", "#6FBDFF");
        MenuCategory menuCategory = mainCat.CreateCategory("Double Jump", "#fe9500");
        menuCategory.CreateFunctionElement("Enable", Color.green, Enable);
        menuCategory.CreateFunctionElement("Disable", Color.red, Disable);
        SubPanelElement subPanelElement = menuCategory.CreateSubPanel("Settings", Color.white);
        subPanelElement.CreateBoolPreference("Auto Enable", Color.white, Preferences.AutoEnable, Preferences.OwnCategory);
    }
    
    private static void Enable()
    {
        ModConsole.Msg("Enabling double jump", 1);
        Player.remapRig.doubleJump = true;
    }

    private static void Disable()
    {
        ModConsole.Msg("Disabling double jump", 1);
        Player.remapRig.doubleJump = false;
    }
}