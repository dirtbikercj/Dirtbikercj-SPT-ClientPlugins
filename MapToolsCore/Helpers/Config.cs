using BepInEx.Configuration;
using MapTools.Core;
using UnityEngine;

namespace MapTools.Helpers
{
    public static class MapToolsConfig
    {

        #region MainSettings
        public static ConfigEntry<KeyCode> logAllLoot;
        public static ConfigEntry<KeyCode> setSpawnPoint;
        public static ConfigEntry<KeyCode> dumpWorldLootJson;
        public static ConfigEntry<KeyCode> dumpBaseJson;
        public static ConfigEntry<KeyCode> undo;
        public static ConfigEntry<bool> enableLootSpheres;
        public static ConfigEntry<bool> enableSpawnSpheres; 
        public static ConfigEntry<Colors> lootColor;
        #endregion

        #region LootSettings
        public static ConfigEntry<string> id;
        public static ConfigEntry<float> probability;
        public static ConfigEntry<bool> isStatic;
        public static ConfigEntry<bool> useGravity;
        public static ConfigEntry<bool> randomRotation;
        public static ConfigEntry<bool> isGroupPosition;
        public static ConfigEntry<bool> isAlwaysSpawn;
        #endregion

        #region Base.Json
        public static ConfigEntry<float> area;
        public static ConfigEntry<int> averagePlayTime;
        public static ConfigEntry<int> averagePlayerLevel;

        // BossLocationSpawn
        public static ConfigEntry<int> bossChance;
        public static ConfigEntry<string> bossDifficulty;
        public static ConfigEntry<string> bossEscortAmount;
        public static ConfigEntry<string> bossEscortDifficult;
        public static ConfigEntry<string> bossEscortType;
        public static ConfigEntry<string> bossName;
        public static ConfigEntry<bool> bossPlayer;
        public static ConfigEntry<string> bossZone;
        public static ConfigEntry<bool> randomTimeSpawn;
        public static ConfigEntry<int> bossTime;

        public static ConfigEntry<int> botAssault;
        public static ConfigEntry<int> botEasy;
        public static ConfigEntry<int> botHard;
        public static ConfigEntry<int> botImpossible;

        // BossLocationModifier
        public static ConfigEntry<int> accuracySpeed;
        public static ConfigEntry<int> distToActivate;
        public static ConfigEntry<float> distToPersueAxemanCoef;
        public static ConfigEntry<int> distToSleep;
        public static ConfigEntry<int> gainSight;
        public static ConfigEntry<int> khorovodChange;
        public static ConfigEntry<int> magnetPower;
        public static ConfigEntry<int> marksmanAccuracyCoef;
        public static ConfigEntry<int> scattering;
        public static ConfigEntry<int> visibleDistance;
        public static ConfigEntry<int> botMarksman;
        public static ConfigEntry<int> botMax;
        public static ConfigEntry<int> botMaxPlayer;
        public static ConfigEntry<int> botMaxTimePlayer;
        public static ConfigEntry<int> botNormal;
        public static ConfigEntry<int> botSpawnTimeOffMax;
        public static ConfigEntry<int> botSpawnTimeOffMin;
        public static ConfigEntry<int> botSpawnTimeOnMax;
        public static ConfigEntry<int> botSpawnTimeOnMin;
        public static ConfigEntry<int> botStart;
        public static ConfigEntry<int> botStop;
        public static ConfigEntry<string> description;
        public static ConfigEntry<bool> disabledForScav;
        public static ConfigEntry<string> disabledScavExits;
        public static ConfigEntry<bool> enabled;
        public static ConfigEntry<bool> enabledCoop;
        public static ConfigEntry<int> escapeTimeLimit;
        public static ConfigEntry<int> escapeTimeLimitCoop;
        public static ConfigEntry<bool> generateLocalLootCache;
        public static ConfigEntry<double> globalLootChanceModifier;
        public static ConfigEntry<int> iconX;
        public static ConfigEntry<int> iconY;
        public static ConfigEntry<string> idMap;
        public static ConfigEntry<bool> insurance;
        public static ConfigEntry<bool> isSecret;
        public static ConfigEntry<bool> locked;
        public static ConfigEntry<string> loot; //TODO: Fix this needs to be a string array
        public static ConfigEntry<int> maxBotPerZone;
        public static ConfigEntry<int> maxCoopGroup;
        public static ConfigEntry<int> maxDistToFreePoint;
        public static ConfigEntry<int> maxPlayers;
        public static ConfigEntry<int> minDistToExitPoint;
        public static ConfigEntry<int> minDistToFreePoint;
        public static ConfigEntry<int> minMaxBots;
        public static ConfigEntry<int> minPlayers;
        public static ConfigEntry<string> name;
        public static ConfigEntry<bool> newSpawn;
        public static ConfigEntry<bool> occulsionCullingEnabled;
        public static ConfigEntry<bool> oldSpawn;
        public static ConfigEntry<string> openZones;
        public static ConfigEntry<int> scavMaxPlayersInGroup;
        public static ConfigEntry<int> pmcMaxPlayersInGroup;
        public static ConfigEntry<string> previewPath;
        public static ConfigEntry<string> previewRcid;
        public static ConfigEntry<int> requiredLevelMin;
        public static ConfigEntry<int> requiredLevelMax;
        public static ConfigEntry<string> rules;
        public static ConfigEntry<bool> safeLocation;
        public static ConfigEntry<string> scenePath;
        public static ConfigEntry<string> sceneRcid;
        // SAODASD
        public static ConfigEntry<int> exitAccessTime;
        public static ConfigEntry<int> exitCount;
        public static ConfigEntry<int> exitTime;
        public static ConfigEntry<int> matchingMinSeconds;
        public static ConfigEntry<int> savSummonSeconds;
        public static ConfigEntry<int> tmpLocationFieldRemoveMe;
        public static ConfigEntry<int> usersGatherSeconds;
        public static ConfigEntry<int> usersSpawnSecondsN;
        public static ConfigEntry<int> usersSpawnSecondsN2;
        public static ConfigEntry<int> usersSummonSeconds;

        #endregion
    }
}
