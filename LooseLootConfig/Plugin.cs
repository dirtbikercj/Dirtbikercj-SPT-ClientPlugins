using BepInEx;

namespace MapTools.Config
{
    [BepInPlugin("com.dirtbikercj.maptoolslooselootjsonconfig", "Map Tools: looseloot.Json", "1.0.0")]
    public class Plugin0125 : BaseUnityPlugin
    {
        public static Plugin0125 instance;
        private const string LootConfig = "Loot Config";

        internal void Awake()
        {
            instance = this;
            DontDestroyOnLoad(this);

            ConfigLooseLootJson.id = Config.Bind(
                LootConfig, "Item ID, LooseLoot.Json",
                "Loot_ammo",
                "Type of spawn point, Enter spawn type and a random hash will be generated");

            ConfigLooseLootJson.probability = Config.Bind(
                LootConfig,
                "Probability",
                0.05f,
                "Probability this point will be spawned");

            ConfigLooseLootJson.isStatic = Config.Bind(
                LootConfig,
                "IsStatic",
                false,
                "Is this a static spawn?");

            ConfigLooseLootJson.useGravity = Config.Bind(
                LootConfig,
                "Use Gravity",
                false,
                "Does this spawn use gravity?");

            ConfigLooseLootJson.randomRotation = Config.Bind(
                LootConfig,
                "Random Rotation",
                false,
                "Does this spawn use random rotation?");

            ConfigLooseLootJson.isGroupPosition = Config.Bind(
                LootConfig,
                "IsGroupPosition",
                false,
                "Does this spawn use group positions?");

            ConfigLooseLootJson.isAlwaysSpawn = Config.Bind(
                LootConfig,
                "Always Spawn",
                false,
                "Does this position always spawn?");
        }
    }
}