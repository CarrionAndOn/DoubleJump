using MelonLoader;

namespace DoubleJump.Melon
{
    internal static class Preferences
    {
        public static MelonPreferences_Category category = MelonPreferences.CreateCategory("Double Jump");

        public static ModPref<bool> autoEnable;

        public static void Setup()
        {
            autoEnable = new ModPref<bool>(category, "AutoEnable", false);

            category.SaveToFile(false);
        }
    }
}