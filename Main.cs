namespace DoubleJump;

public class Main : MelonMod
{
    internal const string Name = "Double Jump";
    internal const string Description = "Reenables the double jump feature in BONELAB.";
    internal const string Author = "SoulWithMae";
    internal const string Company = "Weather Electric";
    internal const string Version = "1.1.0";
    internal const string DownloadLink = "https://bonelab.thunderstore.io/package/SoulWithMae/DoubleJump/";
        
    public override void OnInitializeMelon()
    {
        ModConsole.Setup(LoggerInstance);
        Preferences.Setup();
        BoneMenu.Setup();
    }
    [HarmonyPatch(typeof(Player_Health), "MakeVignette")]
    public static class VignettePatch
    {
        public static void Postfix(Player_Health __instance)
        {
            if (Preferences.AutoEnable.Value)
            {
                ModConsole.Msg("Enabling double jump automatically", 1);
                Player.remapRig.doubleJump = true;
            }
        }
    }
}