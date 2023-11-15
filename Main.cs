using BoneLib;
using BoneLib.BoneMenu;
using BoneLib.BoneMenu.Elements;
using DoubleJump.Melon;
using HarmonyLib;
using MelonLoader;
using UnityEngine;

namespace DoubleJump
{
    public class Main : MelonMod
    {
        internal const string Name = "Double Jump";
        internal const string Description = "Reenables the double jump feature in BONELAB.";
        internal const string Author = "SoulWithMae";
        internal const string Company = "Weather Electric";
        internal const string Version = "1.0.2";
        internal const string DownloadLink = "https://bonelab.thunderstore.io/package/CarrionAndOn/DoubleJump/";
        
        public override void OnInitializeMelon()
        {
            SetupBonemenu();
            ModConsole.Setup(LoggerInstance);
            Preferences.Setup();
            _enabled = Preferences.AutoEnable;
        }
        [HarmonyPatch(typeof(Player_Health), "MakeVignette")]
        public static class VignettePatch
        {
            public static void Postfix(Player_Health __instance)
            {
                if (_enabled)
                {
                    ModConsole.Msg("Enabling double jump automatically", LoggingMode.DEBUG);
                    Player.remapRig.doubleJump = true;
                }
            }
        }

        private static bool _enabled;
        private static void SetupBonemenu()
        {
            MenuCategory mainCat = MenuManager.CreateCategory("Weather Electric", "#6FBDFF");
            MenuCategory menuCategory = mainCat.CreateCategory("Double Jump", "#fe9500");
            menuCategory.CreateFunctionElement("Enable", Color.green, Enable);
            menuCategory.CreateFunctionElement("Disable", Color.red, Disable);
            menuCategory.CreateBoolElement("Auto Enable", Color.yellow, _enabled, OnBoolChanged);
        }

        private static void OnBoolChanged(bool value)
        {
            _enabled = value;
            Preferences.AutoEnable.entry.Value = value;
            Preferences.OwnCategory.SaveToFile();
        }

        private static void Enable()
        {
            ModConsole.Msg("Enabling double jump", LoggingMode.DEBUG);
            Player.remapRig.doubleJump = true;
        }

        private static void Disable()
        {
            ModConsole.Msg("Disabling double jump", LoggingMode.DEBUG);
            Player.remapRig.doubleJump = false;
        }
    }
}