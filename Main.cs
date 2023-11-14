using BoneLib.BoneMenu;
using BoneLib.BoneMenu.Elements;
using HarmonyLib;
using MelonLoader;
using UnityEngine;

namespace DoubleJump
{
    public class Main : MelonMod
    {
        internal const string Name = "Double Jump"; // Required
        internal const string Description = "Reenables the double jump feature in BONELAB."; // Required
        internal const string Author = "CarrionAndOn"; // Required
        internal const string Company = "Weather Electric"; // Set as null if blank
        internal const string Version = "1.0.0"; // Required
        internal const string DownloadLink = "null"; // Set as null if blank

        private static DoubleJump _doubleJump;
        public override void OnInitializeMelon()
        {
            _doubleJump = new DoubleJump();
            SetupBonemenu();
            Preferences.Setup();
            Enabled = Preferences.autoEnable;
        }
        [HarmonyPatch(typeof(Player_Health), "MakeVignette")]
        public static class VignettePatch
        {
            public static void Postfix(Player_Health __instance)
            {
                _doubleJump.AutoEnable();
            }
        }
        public static bool Enabled = false;
        private static void SetupBonemenu()
        {
            MenuCategory mainCat = MenuManager.CreateCategory("Weather Electric", "6FBDFF");
            MenuCategory menuCategory = mainCat.CreateCategory("Double Jump", Color.magenta);
            menuCategory.CreateFunctionElement("Enable", Color.green, _doubleJump.Enable);
            menuCategory.CreateFunctionElement("Disable", Color.red, _doubleJump.Disable);
            menuCategory.CreateBoolElement("Auto Enable", Color.yellow, Enabled, delegate(bool value)
            {
                Enabled = value;
                Preferences.autoEnable.entry.Value = value;
                Preferences.category.SaveToFile();
            });
        }
    }
}