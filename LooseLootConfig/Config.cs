using BepInEx.Configuration;

namespace MapTools.Config
{
    public static class ConfigLooseLootJson
    {
        // SpawnpointCount
        public static ConfigEntry<float> mean;
        public static ConfigEntry<float> std;
        
        // template
        public static ConfigEntry<string> id;
        public static ConfigEntry<bool> isStatic;
        public static ConfigEntry<bool> useGravity;
        public static ConfigEntry<bool> randomRotation;
        public static ConfigEntry<float> probability;
        public static ConfigEntry<bool> isGroupPosition;
        public static ConfigEntry<bool> isAlwaysSpawn;
        
        // Items
        public static ConfigEntry<string> slotId;
        public static ConfigEntry<int> stackObjectsCount;
        public static ConfigEntry<int> location;
    }
}
