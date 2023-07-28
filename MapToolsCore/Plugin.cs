using BepInEx;
using MapTools.Core;
using Comfort.Common;
using EFT;
using UnityEngine;
using MapTools.Helpers;

namespace MapTools
{
    [BepInPlugin("com.dirtbikercj.maptools", "Map Tools", "1.0.0")]
    public class MapTools : BaseUnityPlugin
    {
        public static MapTools instance;
        public Render renderer;
        public WorldLoot worldLoot;
        public GameWorld gameWorldInstance;
        
        public BaseJsonBuilder baseJsonBuilder = new BaseJsonBuilder();
        public LooseLootJsonBuilder lootJsonBuilder = new LooseLootJsonBuilder();


        private const string MainConfig = "Main Settings";
        private const string LootConfig = "Loot Config";
        private const string BaseConfig = "Base.json";


        internal void Awake()
        {
            instance = this;
            DontDestroyOnLoad(this);

            #region Config
            #region MainSettings
            MapToolsConfig.logAllLoot = Config.Bind(
               MainConfig,
                "Log all spawned loot to console",
                KeyCode.KeypadMinus,
                "Key bind to list all loot");

            MapToolsConfig.setSpawnPoint = Config.Bind(
               MainConfig,
                "Select World Position",
                KeyCode.Mouse1,
                "Key bind to select the world position");

            MapToolsConfig.dumpWorldLootJson = Config.Bind(
               MainConfig,
                "Export looseloot.json",
                KeyCode.KeypadPlus,
                "Dumps all created loot positions to json");

            MapToolsConfig.dumpBaseJson = Config.Bind(
                MainConfig,
                "Export base.json",
                KeyCode.KeypadEnter,
                "Dumps all created loot positions to json");

            MapToolsConfig.undo = Config.Bind(
               MainConfig,
                "Undo Last Action",
                KeyCode.Keypad0,
                "Undoes last action");
            
            MapToolsConfig.enableLootSpheres = Config.Bind(
               MainConfig,
                "Draw Spheres on loot positions",
                true,
                "Draws Spheres on placed loot positons using the editor");

            MapToolsConfig.enableSpawnSpheres = Config.Bind(
                MainConfig,
                "Draw Spheres on loot positions",
                true,
                "Draws Spheres on placed loot positons using the editor");

            MapToolsConfig.lootColor = Config.Bind(
               MainConfig,
                "Set lootsphere color",
                Colors.Red,
                "Undoes last action");

            #endregion

            #region LootPointSettings

            MapToolsConfig.id = Config.Bind(
                LootConfig, "Item ID, LooseLoot.Json",
                "Loot_ammo",
                "Type of spawn point, Enter spawn type and a random hash will be generated");

             MapToolsConfig.probability = Config.Bind(
                 LootConfig,
                 "Probability",
                 0.05f,
                 "Probability this point will be spawned");

             MapToolsConfig.isStatic = Config.Bind(
                 LootConfig,
                 "IsStatic",
                 false,
                 "Is this a static spawn?");

             MapToolsConfig.useGravity = Config.Bind(
                 LootConfig,
                 "Use Gravity",
                 false,
                 "Does this spawn use gravity?");

             MapToolsConfig.randomRotation = Config.Bind(
                 LootConfig,
                 "Random Rotation",
                 false,
                 "Does this spawn use random rotation?");

             MapToolsConfig.isGroupPosition = Config.Bind(
                 LootConfig,
                 "IsGroupPosition",
                 false,
                 "Does this spawn use group positions?");

             MapToolsConfig.isAlwaysSpawn = Config.Bind(
                 LootConfig,
                 "Always Spawn",
                 false,
                 "Does this position always spawn?");
             #endregion

            #region Base.Json
             MapToolsConfig.area = Config.Bind(
                 BaseConfig,
                 "Area",
                 0.9f,
                 "Area");

             MapToolsConfig.averagePlayTime = Config.Bind(
                 BaseConfig,
                 "Average play time",
                 15,
                 "Match length");

             MapToolsConfig.averagePlayerLevel = Config.Bind(
                 BaseConfig,
                 "Average player level",
                 1,
                 "");

             #region Bosses
             MapToolsConfig.bossChance = Config.Bind(
                 BaseConfig,
                 "Boss spawn chance",
                 10,
                 "");

             MapToolsConfig.bossDifficulty = Config.Bind(
                 BaseConfig,
                 "Boss difficulty",
                 "normal",
                 "");

             MapToolsConfig.bossEscortAmount = Config.Bind(
                 BaseConfig,
                 "Boss Escort Amount",
                 "",
                 "");

             MapToolsConfig.bossEscortDifficult = Config.Bind(
                 BaseConfig,
                 "Boss Escort difficulty",
                 "normal",
                 "");

            MapToolsConfig.bossEscortType = Config.Bind(
                 BaseConfig,
                 "Boss escort type",
                 "",
                 "");

             MapToolsConfig.bossName = Config.Bind(
                 BaseConfig,
                 "Boss to spawn",
                 "",
                 "");

             MapToolsConfig.bossPlayer = Config.Bind(
                 BaseConfig,
                 "Boss player",
                 false,
                 "");

             MapToolsConfig.bossZone = Config.Bind(
                 BaseConfig,
                 "Boss Zone",
                 "",
                 "");

             MapToolsConfig.randomTimeSpawn = Config.Bind(
                 BaseConfig,
                 "Boss random spawn time",
                 false,
                 "");

             MapToolsConfig.bossTime = Config.Bind(
                 BaseConfig,
                 "Boss spawn chance",
                 -1,
                 "");

             MapToolsConfig.botAssault = Config.Bind(
                 BaseConfig,
                 "Assault bots",
                 0,
                 "");

             MapToolsConfig.botEasy = Config.Bind(
                 BaseConfig,
                 "Easy bots",
                 0,
                 "");

             MapToolsConfig.botHard = Config.Bind(
                 BaseConfig,
                 "Hard bots",
                 0,
                 "");

             MapToolsConfig.botImpossible = Config.Bind(
                 BaseConfig,
                 "Impossible bots",
                 0,
                 "");

             MapToolsConfig.accuracySpeed = Config.Bind(
                 BaseConfig,
                 "Accuracy Speed",
                 0,
                 "");

             MapToolsConfig.distToActivate = Config.Bind(
                 BaseConfig,
                 "Distance to activate",
                 0,
                 "");

             MapToolsConfig.distToPersueAxemanCoef = Config.Bind(
                 BaseConfig,
                 "Distance to Persue Axeman Coef",
                 0.0f,
                 "");

             MapToolsConfig.distToSleep = Config.Bind(
                 BaseConfig,
                 "Distance to sleep",
                 0,
                 "");

             MapToolsConfig.gainSight = Config.Bind(
                 BaseConfig,
                 "Gain sight",
                 0,
                 "");

             MapToolsConfig.khorovodChange = Config.Bind(
                 BaseConfig,
                 "khorovod Change",
                 -1,
                 "");

             MapToolsConfig.magnetPower = Config.Bind(
                 BaseConfig,
                 "Magnet Power",
                 0,
                 "");

             MapToolsConfig.marksmanAccuracyCoef = Config.Bind(
                 BaseConfig,
                 "Marksman Accuracy Coef",
                 0,
                 "");

             MapToolsConfig.scattering = Config.Bind(
                 BaseConfig,
                 "Scattering",
                 0,
                 "");

             MapToolsConfig.visibleDistance = Config.Bind(
                 BaseConfig,
                 "Visible Distance",
                 0,
                 "");

            MapToolsConfig.botMarksman = Config.Bind(
                 BaseConfig,
                 "Marksman bots",
                 0,
                 "");

             MapToolsConfig.botMax = Config.Bind(
                 BaseConfig,
                 "Max bots",
                 0,
                 "");

             MapToolsConfig.botMaxPlayer = Config.Bind(
                 BaseConfig,
                 "Bot max player",
                 0,
                 "");

             MapToolsConfig.botMaxTimePlayer = Config.Bind(
                 BaseConfig,
                 "Bot max time player",
                 0,
                 "");

             MapToolsConfig.botNormal = Config.Bind(
                 BaseConfig,
                 "Bot Normal",
                 0,
                 "");

            MapToolsConfig.botSpawnTimeOffMax = Config.Bind(
               BaseConfig,
               "Bot spawn time off max",
               0,
               "");

            MapToolsConfig.botSpawnTimeOffMin = Config.Bind(
                BaseConfig,
                "Bot spawn time off min",
                0,
                "");

            MapToolsConfig.botSpawnTimeOnMax = Config.Bind(
                BaseConfig,
                "Bot spawn time on max",
                0,
                "");

            MapToolsConfig.botSpawnTimeOnMin = Config.Bind(
                BaseConfig,
                "Bot spawn time on min",
                0,
                "");

            MapToolsConfig.botStart = Config.Bind(
                BaseConfig,
                "Bots start",
                0,
                "");

            MapToolsConfig.botStop = Config.Bind(
                BaseConfig,
                "Bots stop",
                0,
                "");

            MapToolsConfig.description = Config.Bind(
                BaseConfig,
                "Description",
                "",
                "");

            MapToolsConfig.disabledForScav = Config.Bind(
                BaseConfig,
                "Disabled for scavs",
                false,
                "");

            MapToolsConfig.disabledScavExits = Config.Bind(
                BaseConfig,
                "Disabled Scav exits",
                "",
                "follow this format: Cellers,Gate 0");

            MapToolsConfig.enabled = Config.Bind(
                BaseConfig,
                "Enable map",
                true,
                "");

            MapToolsConfig.enabledCoop = Config.Bind(
                BaseConfig,
                "Enabled for coop",
                true,
                ""); 
            
            MapToolsConfig.escapeTimeLimit = Config.Bind(
                BaseConfig,
                "Escape time in minutes",
                30,
                "");

            MapToolsConfig.escapeTimeLimitCoop = Config.Bind(
                BaseConfig,
                "Escape time in minutes - coop",
                30,
                "");

            MapToolsConfig.generateLocalLootCache = Config.Bind(
                BaseConfig,
                "Generate loot",
                true,
                "");

            MapToolsConfig.globalLootChanceModifier = Config.Bind(
                BaseConfig,
                "Loot chance modifier",
                0.2,
                "");

            MapToolsConfig.iconX = Config.Bind(
                BaseConfig,
                "Icon size X",
                318,
                "");

            MapToolsConfig.iconY = Config.Bind(
                BaseConfig,
                "Icon size Y",
                359,
                "");

            MapToolsConfig.idMap = Config.Bind(
                BaseConfig,
                "id",
                "",
                "Ex: factory4_day");

            MapToolsConfig.insurance = Config.Bind(
                BaseConfig,
                "Is insurance enabled",
                true,
                "");

            MapToolsConfig.isSecret = Config.Bind(
                BaseConfig,
                "Is secret",
                false,
                "");

            MapToolsConfig.locked = Config.Bind(
                BaseConfig,
                "is map locked",
                false,
                "");

            MapToolsConfig.loot = Config.Bind( //TODO: Fix this see config.cs
                BaseConfig,
                "loot",
                "",
                "");

            MapToolsConfig.maxBotPerZone = Config.Bind(
                BaseConfig,
                "Max bots per zone",
                4,
                "");

            MapToolsConfig.maxCoopGroup = Config.Bind(
                BaseConfig,
                "Max Coop group",
                6,
                "");

            MapToolsConfig.maxDistToFreePoint = Config.Bind(
                BaseConfig,
                "Max distance to free point",
                900,
                "");

            MapToolsConfig.maxPlayers = Config.Bind(
                BaseConfig,
                "Max players",
                12,
                "");

            MapToolsConfig.minDistToExitPoint = Config.Bind( //TODO: Fix this see config.cs
                BaseConfig,
                "minimum distance to exit point",
                30,
                "");

            MapToolsConfig.minDistToFreePoint = Config.Bind(
                BaseConfig,
                "Minimum distance to free point",
                10,
                "");

            MapToolsConfig.minMaxBots = Config.Bind(
                BaseConfig,
                "Max Coop group",
                6,
                "");

            MapToolsConfig.minPlayers = Config.Bind(
                BaseConfig,
                "Max distance to free point",
                4,
                "");

            MapToolsConfig.name = Config.Bind(
                BaseConfig,
                "Name of map",
                "Test Map",
                "");

            MapToolsConfig.newSpawn = Config.Bind( //TODO: Fix this see config.cs
                BaseConfig,
                "New spawn",
                false,
                "");

            MapToolsConfig.occulsionCullingEnabled = Config.Bind(
                BaseConfig,
                "Occulsion culling enabled",
                true,
                "");

            MapToolsConfig.oldSpawn = Config.Bind(
                BaseConfig,
                "Old spawns",
                true,
                "");

            MapToolsConfig.openZones = Config.Bind(
                BaseConfig,
                "Open zones",
                "",
                "Example: BotZone");

            MapToolsConfig.pmcMaxPlayersInGroup = Config.Bind(
                BaseConfig,
                "Max players in group",
                5,
                "");

            MapToolsConfig.previewPath = Config.Bind(
                BaseConfig,
                "Preview -> path",
                "",
                "Example: BotZone");

            MapToolsConfig.previewRcid = Config.Bind(
                BaseConfig,
                "Preview -> Rcid",
                "",
                "");

            MapToolsConfig.requiredLevelMin = Config.Bind(
                BaseConfig,
                "Required minimum level to enter",
                0,
                "Example: BotZone");

            MapToolsConfig.requiredLevelMax = Config.Bind(
                BaseConfig,
                "Required maximum level to enter",
                100,
                "");

            MapToolsConfig.rules = Config.Bind(
                BaseConfig,
                "rules",
                "AvoidOwnPmc",
                "");

            MapToolsConfig.safeLocation = Config.Bind(
                BaseConfig,
                "Is location safe",
                false,
                "Example: BotZone");

            MapToolsConfig.scavMaxPlayersInGroup = Config.Bind(
                BaseConfig,
                "Max scavs allowed in a group",
                4,
                "");

            MapToolsConfig.pmcMaxPlayersInGroup = Config.Bind(
                BaseConfig,
                "Max players in group",
                5,
                "");


            MapToolsConfig.scenePath = Config.Bind(
                BaseConfig,
                "Scene -> Path",
                "",
                "");

            MapToolsConfig.sceneRcid = Config.Bind(
                BaseConfig,
                "Scene -> Rcid",
                "",
                "");

            MapToolsConfig.exitAccessTime = Config.Bind(
                BaseConfig,
                "Exit Access Time",
                60,
                "");

            MapToolsConfig.exitCount = Config.Bind(
                BaseConfig,
                "Exit Count",
                3,
                "");

            MapToolsConfig.exitTime = Config.Bind(
                BaseConfig,
                "Exit Time",
                1,
                "Example: BotZone");

            MapToolsConfig.matchingMinSeconds = Config.Bind(
                BaseConfig,
                "Minimum matching time",
                45,
                "");

            MapToolsConfig.savSummonSeconds = Config.Bind(
                BaseConfig,
                "Scav Summon seconds",
                60,
                "");

            MapToolsConfig.tmpLocationFieldRemoveMe = Config.Bind(
                BaseConfig,
                "Temp location field remove me",
                0,
                "This is not used, leave 0");

            MapToolsConfig.usersGatherSeconds = Config.Bind(
                BaseConfig,
                "Users gather seconds",
                0,
                "");

            MapToolsConfig.usersSpawnSecondsN = Config.Bind(
                BaseConfig,
                "Users spawn seconds N",
                120,
                "");

            MapToolsConfig.usersSpawnSecondsN2 = Config.Bind(
                BaseConfig,
                "Users spawn seconds N2",
                180,
                "");

            MapToolsConfig.usersSummonSeconds = Config.Bind(
                BaseConfig,
                "users summon seconds",
                0,
                "");

            #endregion
            #endregion
            #endregion
        }

        internal void Start()
        {
            renderer = new Render();
            worldLoot = new WorldLoot();

            baseJsonBuilder.InitBaseJson();
        }

        internal void Update()
        {
            if (Singleton<GameWorld>.Instantiated)
            {
                gameWorldInstance = Singleton<GameWorld>.Instance;

                if (Input.GetKeyDown(MapToolsConfig.logAllLoot.Value))
                {
                    worldLoot.ListAllLoot(gameWorldInstance);
                }

                if (Input.GetKeyDown(MapToolsConfig.setSpawnPoint.Value))
                {
                    worldLoot.GetWorldPoint(lootJsonBuilder, renderer);
                }

                // Dump Looseloot.json
                if (Input.GetKeyDown(MapToolsConfig.dumpWorldLootJson.Value))
                {
                    lootJsonBuilder.ExportJson();
                }

                //Undo last action on looseloot.json
                if (Input.GetKeyDown(MapToolsConfig.undo.Value))
                {
                    //renderer.Undo();
                    //lootJsonBuilder.Undo();
                }

                // Dump Base.json
                if (Input.GetKeyDown(MapToolsConfig.dumpBaseJson.Value))
                {
                    baseJsonBuilder.ExportBaseJson();
                }
            }

            //Dump Looseloot.json
            if (Input.GetKeyDown(MapToolsConfig.dumpWorldLootJson.Value))
            {
                lootJsonBuilder.ExportJson();
            }

            // Dump Base.json
            if (Input.GetKeyDown(MapToolsConfig.dumpBaseJson.Value))
            {
                baseJsonBuilder.ExportBaseJson();
            }
        }
    }
}
