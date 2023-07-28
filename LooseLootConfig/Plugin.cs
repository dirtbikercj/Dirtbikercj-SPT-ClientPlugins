using BepInEx;

namespace MapTools.Config
{
    [BepInPlugin("com.dirtbikercj.maptoolslooselootjsonconfig", "Map Tools: looseloot.Json", "1.0.0")]
    public class Plugin0125 : BaseUnityPlugin
    {
        public static Plugin0125 instance;
        private const string SpawnPointCount = "SpawnPointCount";
        private const string Template = "Template";
        private const string Items = "Items";

        internal void Awake()
        {
            instance = this;
            DontDestroyOnLoad(this);

            ConfigLooseLootJson.mean = Config.Bind(
                SpawnPointCount,
                "Spawn point count - mean",
                0.00f,
                "");

            ConfigLooseLootJson.std = Config.Bind(
                SpawnPointCount,
                "Spawn point count - std",
                0.00f,
                "");

            ConfigLooseLootJson.id = Config.Bind(
                Template, 
                "Item ID, LooseLoot.Json",
                "Loot_ammo",
                "Type of spawn point, Enter spawn type and a random identifier will be generated");

            ConfigLooseLootJson.isStatic = Config.Bind(
                Template,
                "IsStatic",
                false,
                "Is this a static spawn?");

            ConfigLooseLootJson.useGravity = Config.Bind(
                Template,
                "Use Gravity",
                false,
                "Does this spawn use gravity?");

            ConfigLooseLootJson.randomRotation = Config.Bind(
                Template,
                "Random Rotation",
                false,
                "Does this spawn use random rotation?");

            ConfigLooseLootJson.probability = Config.Bind(
                Template,
                "Probability",
                0.05f,
                "Probability this point will be spawned");

            ConfigLooseLootJson.isGroupPosition = Config.Bind(
                Template,
                "IsGroupPosition",
                false,
                "Does this spawn use group positions?");

            ConfigLooseLootJson.isAlwaysSpawn = Config.Bind(
                Template,
                "Always Spawn",
                false,
                "Does this position always spawn?");

            ConfigLooseLootJson.slotId = Config.Bind(
                Items,
                "SlotId",
                "",
                "");

            ConfigLooseLootJson.stackObjectsCount = Config.Bind(
                Items,
                "Stack Object Count",
                60,
                "");

            ConfigLooseLootJson.location = Config.Bind(
                Items,
                "location",
                1,
                "");

        }
    }
}