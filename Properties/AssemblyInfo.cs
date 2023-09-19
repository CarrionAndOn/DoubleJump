using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(DoubleJump.Main.Description)]
[assembly: AssemblyDescription(DoubleJump.Main.Description)]
[assembly: AssemblyCompany(DoubleJump.Main.Company)]
[assembly: AssemblyProduct(DoubleJump.Main.Name)]
[assembly: AssemblyCopyright("Developed by " + DoubleJump.Main.Author)]
[assembly: AssemblyTrademark(DoubleJump.Main.Company)]
[assembly: AssemblyVersion(DoubleJump.Main.Version)]
[assembly: AssemblyFileVersion(DoubleJump.Main.Version)]
[assembly:
    MelonInfo(typeof(DoubleJump.Main), DoubleJump.Main.Name, DoubleJump.Main.Version,
        DoubleJump.Main.Author, DoubleJump.Main.DownloadLink)]
[assembly: MelonColor(System.ConsoleColor.White)]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONELAB")]