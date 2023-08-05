using System;
using System.IO;
using System.Reflection;
using Aki.Reflection.Patching;
using EFT.UI;
using HarmonyLib;


namespace GameSettings
{
  
    internal class GameSettingsPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod() =>
            typeof(SharedGameSettingsClass).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, binder: null, new Type[0], null);

        [PatchPrefix]
        static void GameSettingsPatchDynamic(SharedGameSettingsClass __instance)
        {
            string newSettingsPath = AppDomain.CurrentDomain.BaseDirectory + @"\BepInEx\plugins\GameSettings";
            var string_0 = AccessTools.Field(typeof(SharedGameSettingsClass), "string_0");
            var string_1 = AccessTools.Field(typeof(SharedGameSettingsClass), "string_1");

            string_0.SetValue(__instance, newSettingsPath);
            string_1.SetValue(__instance, newSettingsPath);
        }
    }


    internal class GameSettingsPatchStatic : ModulePatch
    {
        protected override MethodBase GetTargetMethod() =>
            typeof(SharedGameSettingsClass).GetConstructor(BindingFlags.Static | BindingFlags.NonPublic, binder: null, new Type[0], null);

        [PatchPrefix]
        static void GameSettingsStaticPatch()
        {
            string newSettingsPath = AppDomain.CurrentDomain.BaseDirectory + @"\BepInEx\plugins\GameSettings";
            if (!Directory.Exists(newSettingsPath))
            {
                Directory.CreateDirectory(newSettingsPath);
            }
        }
    }
}
