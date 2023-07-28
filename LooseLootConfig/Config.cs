using BepInEx.Configuration;

namespace MapTools.Config
{
    public static class ConfigLooseLootJson
    {
        public static ConfigEntry<string> id;
        public static ConfigEntry<float> probability;
        public static ConfigEntry<bool> isStatic;
        public static ConfigEntry<bool> useGravity;
        public static ConfigEntry<bool> randomRotation;
        public static ConfigEntry<bool> isGroupPosition;
        public static ConfigEntry<bool> isAlwaysSpawn;
    }
}
