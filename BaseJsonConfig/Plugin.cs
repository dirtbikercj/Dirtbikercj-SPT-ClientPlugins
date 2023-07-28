using BepInEx;

namespace MapTools.Config
{
    [BepInPlugin("com.dirtbikercj.maptoolsbasejsonconfig", "Map Tools - Base.Json config", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance;
        private const string BaseConfig = "Base.json";

        internal void Awake()
        {
            instance = this;
            DontDestroyOnLoad(this);

            ConfigBaseJson.area = Config.Bind(
                 BaseConfig,
                 "Area",
                 0.9f,
                 "Area");

            ConfigBaseJson.averagePlayTime = Config.Bind(
                BaseConfig,
                "Average play time",
                15,
                "Match length");

            ConfigBaseJson.averagePlayerLevel = Config.Bind(
                BaseConfig,
                "Average player level",
                1,
                "");

            ConfigBaseJson.bossChance = Config.Bind(
                BaseConfig,
                "Boss spawn chance",
                10,
                "");

            ConfigBaseJson.bossDifficulty = Config.Bind(
                BaseConfig,
                "Boss difficulty",
                "normal",
                "");

            ConfigBaseJson.bossEscortAmount = Config.Bind(
                BaseConfig,
                "Boss Escort Amount",
                "",
                "");

            ConfigBaseJson.bossEscortDifficult = Config.Bind(
                BaseConfig,
                "Boss Escort difficulty",
                "normal",
                "");

            ConfigBaseJson.bossEscortType = Config.Bind(
                 BaseConfig,
                 "Boss escort type",
                 "",
                 "");

            ConfigBaseJson.bossName = Config.Bind(
                BaseConfig,
                "Boss to spawn",
                "",
                "");

            ConfigBaseJson.bossPlayer = Config.Bind(
                BaseConfig,
                "Boss player",
                false,
                "");

            ConfigBaseJson.bossZone = Config.Bind(
                BaseConfig,
                "Boss Zone",
                "",
                "");

            ConfigBaseJson.randomTimeSpawn = Config.Bind(
                BaseConfig,
                "Boss random spawn time",
                false,
                "");

            ConfigBaseJson.bossTime = Config.Bind(
                BaseConfig,
                "Boss spawn chance",
                -1,
                "");

            ConfigBaseJson.botAssault = Config.Bind(
                BaseConfig,
                "Assault bots",
                0,
                "");

            ConfigBaseJson.botEasy = Config.Bind(
                BaseConfig,
                "Easy bots",
                0,
                "");

            ConfigBaseJson.botHard = Config.Bind(
                BaseConfig,
                "Hard bots",
                0,
                "");

            ConfigBaseJson.botImpossible = Config.Bind(
                BaseConfig,
                "Impossible bots",
                0,
                "");

            ConfigBaseJson.accuracySpeed = Config.Bind(
                BaseConfig,
                "Accuracy Speed",
                0,
                "");

            ConfigBaseJson.distToActivate = Config.Bind(
                BaseConfig,
                "Distance to activate",
                0,
                "");

            ConfigBaseJson.distToPersueAxemanCoef = Config.Bind(
                BaseConfig,
                "Distance to Persue Axeman Coef",
                0.0f,
                "");

            ConfigBaseJson.distToSleep = Config.Bind(
                BaseConfig,
                "Distance to sleep",
                0,
                "");

            ConfigBaseJson.gainSight = Config.Bind(
                BaseConfig,
                "Gain sight",
                0,
                "");

            ConfigBaseJson.khorovodChange = Config.Bind(
                BaseConfig,
                "khorovod Change",
                -1,
                "");

            ConfigBaseJson.magnetPower = Config.Bind(
                BaseConfig,
                "Magnet Power",
                0,
                "");

            ConfigBaseJson.marksmanAccuracyCoef = Config.Bind(
                BaseConfig,
                "Marksman Accuracy Coef",
                0,
                "");

            ConfigBaseJson.scattering = Config.Bind(
                BaseConfig,
                "Scattering",
                0,
                "");

            ConfigBaseJson.visibleDistance = Config.Bind(
                BaseConfig,
                "Visible Distance",
                0,
                "");

            ConfigBaseJson.botMarksman = Config.Bind(
                 BaseConfig,
                 "Marksman bots",
                 0,
                 "");

            ConfigBaseJson.botMax = Config.Bind(
                BaseConfig,
                "Max bots",
                0,
                "");

            ConfigBaseJson.botMaxPlayer = Config.Bind(
                BaseConfig,
                "Bot max player",
                0,
                "");

            ConfigBaseJson.botMaxTimePlayer = Config.Bind(
                BaseConfig,
                "Bot max time player",
                0,
                "");

            ConfigBaseJson.botNormal = Config.Bind(
                BaseConfig,
                "Bot Normal",
                0,
                "");

            ConfigBaseJson.botSpawnTimeOffMax = Config.Bind(
               BaseConfig,
               "Bot spawn time off max",
               0,
               "");

            ConfigBaseJson.botSpawnTimeOffMin = Config.Bind(
                BaseConfig,
                "Bot spawn time off min",
                0,
                "");

            ConfigBaseJson.botSpawnTimeOnMax = Config.Bind(
                BaseConfig,
                "Bot spawn time on max",
                0,
                "");

            ConfigBaseJson.botSpawnTimeOnMin = Config.Bind(
                BaseConfig,
                "Bot spawn time on min",
                0,
                "");

            ConfigBaseJson.botStart = Config.Bind(
                BaseConfig,
                "Bots start",
                0,
                "");

            ConfigBaseJson.botStop = Config.Bind(
                BaseConfig,
                "Bots stop",
                0,
                "");

            ConfigBaseJson.description = Config.Bind(
                BaseConfig,
                "Description",
                "",
                "");

            ConfigBaseJson.disabledForScav = Config.Bind(
                BaseConfig,
                "Disabled for scavs",
                false,
                "");

            ConfigBaseJson.disabledScavExits = Config.Bind(
                BaseConfig,
                "Disabled Scav exits",
                "",
                "follow this format: Cellers,Gate 0");

            ConfigBaseJson.enabled = Config.Bind(
                BaseConfig,
                "Enable map",
                true,
                "");

            ConfigBaseJson.enabledCoop = Config.Bind(
                BaseConfig,
                "Enabled for coop",
                true,
                "");

            ConfigBaseJson.escapeTimeLimit = Config.Bind(
                BaseConfig,
                "Escape time in minutes",
                30,
                "");

            ConfigBaseJson.escapeTimeLimitCoop = Config.Bind(
                BaseConfig,
                "Escape time in minutes - coop",
                30,
                "");

            ConfigBaseJson.generateLocalLootCache = Config.Bind(
                BaseConfig,
                "Generate loot",
                true,
                "");

            ConfigBaseJson.globalLootChanceModifier = Config.Bind(
                BaseConfig,
                "Loot chance modifier",
                0.2,
                "");

            ConfigBaseJson.iconX = Config.Bind(
                BaseConfig,
                "Icon size X",
                318,
                "");

            ConfigBaseJson.iconY = Config.Bind(
                BaseConfig,
                "Icon size Y",
                359,
                "");

            ConfigBaseJson.idMap = Config.Bind(
                BaseConfig,
                "id",
                "",
                "Ex: factory4_day");

            ConfigBaseJson.insurance = Config.Bind(
                BaseConfig,
                "Is insurance enabled",
                true,
                "");

            ConfigBaseJson.isSecret = Config.Bind(
                BaseConfig,
                "Is secret",
                false,
                "");

            ConfigBaseJson.locked = Config.Bind(
                BaseConfig,
                "is map locked",
                false,
                "");

            ConfigBaseJson.loot = Config.Bind( //TODO: Fix this see config.cs
                BaseConfig,
                "loot",
                "",
                "");

            ConfigBaseJson.maxBotPerZone = Config.Bind(
                BaseConfig,
                "Max bots per zone",
                4,
                "");

            ConfigBaseJson.maxCoopGroup = Config.Bind(
                BaseConfig,
                "Max Coop group",
                6,
                "");

            ConfigBaseJson.maxDistToFreePoint = Config.Bind(
                BaseConfig,
                "Max distance to free point",
                900,
                "");

            ConfigBaseJson.maxPlayers = Config.Bind(
                BaseConfig,
                "Max players",
                12,
                "");

            ConfigBaseJson.minDistToExitPoint = Config.Bind( //TODO: Fix this see config.cs
                BaseConfig,
                "minimum distance to exit point",
                30,
                "");

            ConfigBaseJson.minDistToFreePoint = Config.Bind(
                BaseConfig,
                "Minimum distance to free point",
                10,
                "");

            ConfigBaseJson.minMaxBots = Config.Bind(
                BaseConfig,
                "Max Coop group",
                6,
                "");

            ConfigBaseJson.minPlayers = Config.Bind(
                BaseConfig,
                "Max distance to free point",
                4,
                "");

            ConfigBaseJson.name = Config.Bind(
                BaseConfig,
                "Name of map",
                "Test Map",
                "");

            ConfigBaseJson.newSpawn = Config.Bind( //TODO: Fix this see config.cs
                BaseConfig,
                "New spawn",
                false,
                "");

            ConfigBaseJson.occulsionCullingEnabled = Config.Bind(
                BaseConfig,
                "Occulsion culling enabled",
                true,
                "");

            ConfigBaseJson.oldSpawn = Config.Bind(
                BaseConfig,
                "Old spawns",
                true,
                "");

            ConfigBaseJson.openZones = Config.Bind(
                BaseConfig,
                "Open zones",
                "",
                "Example: BotZone");

            ConfigBaseJson.pmcMaxPlayersInGroup = Config.Bind(
                BaseConfig,
                "Max players in group",
                5,
                "");

            ConfigBaseJson.previewPath = Config.Bind(
                BaseConfig,
                "Preview -> path",
                "",
                "Example: BotZone");

            ConfigBaseJson.previewRcid = Config.Bind(
                BaseConfig,
                "Preview -> Rcid",
                "",
                "");

            ConfigBaseJson.requiredLevelMin = Config.Bind(
                BaseConfig,
                "Required minimum level to enter",
                0,
                "Example: BotZone");

            ConfigBaseJson.requiredLevelMax = Config.Bind(
                BaseConfig,
                "Required maximum level to enter",
                100,
                "");

            ConfigBaseJson.rules = Config.Bind(
                BaseConfig,
                "rules",
                "AvoidOwnPmc",
                "");

            ConfigBaseJson.safeLocation = Config.Bind(
                BaseConfig,
                "Is location safe",
                false,
                "Example: BotZone");

            ConfigBaseJson.scavMaxPlayersInGroup = Config.Bind(
                BaseConfig,
                "Max scavs allowed in a group",
                4,
                "");

            ConfigBaseJson.pmcMaxPlayersInGroup = Config.Bind(
                BaseConfig,
                "Max players in group",
                5,
                "");


            ConfigBaseJson.scenePath = Config.Bind(
                BaseConfig,
                "Scene -> Path",
                "",
                "");

            ConfigBaseJson.sceneRcid = Config.Bind(
                BaseConfig,
                "Scene -> Rcid",
                "",
                "");

            ConfigBaseJson.exitAccessTime = Config.Bind(
                BaseConfig,
                "Exit Access Time",
                60,
                "");

            ConfigBaseJson.exitCount = Config.Bind(
                BaseConfig,
                "Exit Count",
                3,
                "");

            ConfigBaseJson.exitTime = Config.Bind(
                BaseConfig,
                "Exit Time",
                1,
                "Example: BotZone");

            ConfigBaseJson.matchingMinSeconds = Config.Bind(
                BaseConfig,
                "Minimum matching time",
                45,
                "");

            ConfigBaseJson.savSummonSeconds = Config.Bind(
                BaseConfig,
                "Scav Summon seconds",
                60,
                "");

            ConfigBaseJson.tmpLocationFieldRemoveMe = Config.Bind(
                BaseConfig,
                "Temp location field remove me",
                0,
                "This is not used, leave 0");

            ConfigBaseJson.usersGatherSeconds = Config.Bind(
                BaseConfig,
                "Users gather seconds",
                0,
                "");

            ConfigBaseJson.usersSpawnSecondsN = Config.Bind(
                BaseConfig,
                "Users spawn seconds N",
                120,
                "");

            ConfigBaseJson.usersSpawnSecondsN2 = Config.Bind(
                BaseConfig,
                "Users spawn seconds N2",
                180,
                "");

            ConfigBaseJson.usersSummonSeconds = Config.Bind(
                BaseConfig,
                "users summon seconds",
                0,
                "");

        }
    }
}