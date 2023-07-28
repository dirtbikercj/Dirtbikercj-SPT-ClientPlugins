using BepInEx.Configuration;
using MapTools.Core;
using UnityEngine;

namespace MapTools.Config
{
    public static class ConfigMapTools
    {

        public static ConfigEntry<KeyCode> logAllLoot;
        public static ConfigEntry<KeyCode> setSpawnPoint;
        public static ConfigEntry<KeyCode> dumpWorldLootJson;
        public static ConfigEntry<KeyCode> dumpBaseJson;
        public static ConfigEntry<KeyCode> undo;
        public static ConfigEntry<bool> enableLootSpheres;
        public static ConfigEntry<bool> enableSpawnSpheres; 
        public static ConfigEntry<Colors> lootColor;
    }
}
