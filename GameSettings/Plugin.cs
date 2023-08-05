using BepInEx;
using HarmonyLib;

namespace GameSettings
{
    [BepInPlugin("com.dirtbikercj.gameSettings", "Game Settings patch", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        internal void Awake()
        {
            new GameSettingsPatch().Enable();
            new GameSettingsPatchStatic().Enable();
        }
    }
}