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
        internal const string Name = "Double Jump"; // Required
        internal const string Description = "Reenables the double jump feature in BONELAB."; // Required
        internal const string Author = "SoulWithMae"; // Required
        internal const string Company = "Weather Electric"; // Set as null if blank
        internal const string Version = "1.0.2"; // Required
        internal const string DownloadLink = "https://bonelab.thunderstore.io/package/CarrionAndOn/DoubleJump/"; // Set as null if blank
        
        public override void OnInitializeMelon()
        {
            SetupBonemenu();
            Preferences.Setup();
            _enabled = Preferences.autoEnable;
        }
        [HarmonyPatch(typeof(Player_Health), "MakeVignette")]
        public static class VignettePatch
        {
            public static void Postfix(Player_Health __instance)
            {
                if (_enabled)
                {
                    Player.remapRig.doubleJump = true;
                }
            }
        }

        private static bool _enabled = false;
        private static void SetupBonemenu()
        {
            MenuCategory mainCat = MenuManager.CreateCategory("Weather Electric", "#6FBDFF");
            MenuCategory menuCategory = mainCat.CreateCategory("Double Jump", "#fe9500");
            menuCategory.CreateFunctionElement("Enable", Color.green, Enable);
            menuCategory.CreateFunctionElement("Disable", Color.red, Disable);
            menuCategory.CreateBoolElement("Auto Enable", Color.yellow, _enabled, delegate(bool value)
            {
                _enabled = value;
                Preferences.autoEnable.entry.Value = value;
                Preferences.category.SaveToFile();
            });
        }

        private static void Enable()
        {
            Player.remapRig.doubleJump = true;
        }

        private static void Disable()
        {
            Player.remapRig.doubleJump = false;
        }
    }
}