using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MapTools.Data.Base;
using MapTools.Config;

namespace MapTools.Core
{
    internal class BaseJsonConstants
    {
        #region base.json
        public Dictionary<string, string> Banners = new Dictionary<string, string>()
            {
                { "5464e0404bdc2d2a708b4567", "CONTENT/banners/banner_usec.jpg"},       // usec
                { "5464e0454bdc2d06708b4567", "CONTENT/banners/banner_bear.jpg"},       // bear
                { "5803a58524597710ca36fcb2", "CONTENT/banners/banner_terragroup.jpg"}, // terragroup
                { "5807bfe124597742a92e0a4c", "CONTENT/banners/norvinskzone.jpg"},      // norvinskzone
                { "5807c3f124597746bf2db2ce", "CONTENT/banners/banner_scav.jpg"},       // scav
                { "5807be8924597742c603fa19", "CONTENT/banners/banner_tarkov.jpg"},     // tarkov
                { "5805f617245977100b2c1f41", "CONTENT/banners/tglabs.jpg"},            // tglabs
                { "5c1b857086f77465f465faa4", "CONTENT/banners/banner_scavraider.jpg"}, // scavraider
            };

        #endregion
    }

    public class BaseJsonBuilder
    {
        private static Random _random = new Random();
        private static BaseJsonConstants __baseJsonConstants = new BaseJsonConstants();
        private BaseJson _baseJson = new BaseJson();
        private string _mapJsonExport;
        static BossLocationSpawns bossLocationSpawn = new BossLocationSpawns();
        static Preview preview = new Preview();
        static Scene scene = new Scene();

        public void InitBaseJson()
        {
            // Convert DateTime to UnixTime
            DateTime datetime = DateTime.Now;
            long unixTime = ((DateTimeOffset)datetime).ToUnixTimeSeconds();

            //Root
            _baseJson.AccessKeys = new List<object>();
            _baseJson.AirdropParameters = new List<AirdropParameter>();
            _baseJson.Area = ConfigBaseJson.area.Value;
            _baseJson.AveragePlayTime = ConfigBaseJson.averagePlayTime.Value;
            _baseJson.AveragePlayerLevel = ConfigBaseJson.averagePlayerLevel.Value;
            _baseJson.Banners = new List<Banner>();
            //BossLocationSpawn
            bossLocationSpawn.BossChance = ConfigBaseJson.bossChance.Value;
            bossLocationSpawn.BossDifficult = ConfigBaseJson.bossDifficulty.Value;
            bossLocationSpawn.BossEscortAmount = ConfigBaseJson.bossEscortAmount.Value;
            bossLocationSpawn.BossEscortDifficult = ConfigBaseJson.bossEscortDifficult.Value;
            bossLocationSpawn.BossEscortType = ConfigBaseJson.bossEscortType.Value;
            bossLocationSpawn.BossName = ConfigBaseJson.bossName.Value;
            bossLocationSpawn.BossPlayer = ConfigBaseJson.bossPlayer.Value;
            bossLocationSpawn.RandomTimeSpawns = ConfigBaseJson.randomTimeSpawn.Value;
            bossLocationSpawn.BossZone = ConfigBaseJson.bossZone.Value;
            bossLocationSpawn.Supports = new List<Support>();
            bossLocationSpawn.Time = ConfigBaseJson.bossTime.Value;
            _baseJson.BossLocationSpawn.Add(bossLocationSpawn);
            //Root
            _baseJson.BotAssault = ConfigBaseJson.botAssault.Value;
            _baseJson.BotEasy = ConfigBaseJson.botEasy.Value;
            _baseJson.BotHard = ConfigBaseJson.botHard.Value;
            _baseJson.BotImpossible = ConfigBaseJson.botImpossible.Value;
            //BotLoactionModifier
            _baseJson.BotLocationModifier.AccuracySpeed = ConfigBaseJson.accuracySpeed.Value;
            _baseJson.BotLocationModifier.DistToActivate = ConfigBaseJson.distToActivate.Value;
            _baseJson.BotLocationModifier.DistToPersueAxemanCoef = ConfigBaseJson.distToPersueAxemanCoef.Value;
            _baseJson.BotLocationModifier.DistToSleep = ConfigBaseJson.distToSleep.Value;
            _baseJson.BotLocationModifier.GainSight = ConfigBaseJson.gainSight.Value;
            _baseJson.BotLocationModifier.KhorovodChance = ConfigBaseJson.khorovodChange.Value;
            _baseJson.BotLocationModifier.MagnetPower = ConfigBaseJson.magnetPower.Value;
            _baseJson.BotLocationModifier.MarksmanAccuratyCoef = ConfigBaseJson.marksmanAccuracyCoef.Value;
            _baseJson.BotLocationModifier.Scattering = ConfigBaseJson.scattering.Value;
            _baseJson.BotLocationModifier.VisibleDistance = ConfigBaseJson.visibleDistance.Value;
            //Root
            _baseJson.BotMarksman = ConfigBaseJson.botMarksman.Value;
            _baseJson.BotMax = ConfigBaseJson.botMax.Value;
            _baseJson.BotMaxPlayer = ConfigBaseJson.botMaxPlayer.Value;
            _baseJson.BotMaxTimePlayer = ConfigBaseJson.botMaxTimePlayer.Value;
            _baseJson.BotNormal = ConfigBaseJson.botNormal.Value;
            _baseJson.BotSpawnTimeOffMax = ConfigBaseJson.botSpawnTimeOffMax.Value;
            _baseJson.BotSpawnTimeOffMin = ConfigBaseJson.botSpawnTimeOffMin.Value;
            _baseJson.BotSpawnTimeOnMax = ConfigBaseJson.botSpawnTimeOnMax.Value;
            _baseJson.BotSpawnTimeOnMin = ConfigBaseJson.botSpawnTimeOnMin.Value;
            _baseJson.BotStart = ConfigBaseJson.botStart.Value;
            _baseJson.BotStop = ConfigBaseJson.botStop.Value;
            _baseJson.Description = ConfigBaseJson.description.Value;
            _baseJson.DisabledForScav = ConfigBaseJson.disabledForScav.Value;
            _baseJson.DisabledScavExits = ConfigBaseJson.disabledScavExits.Value;
            _baseJson.Enabled = ConfigBaseJson.enabled.Value;
            _baseJson.EnabledCoop = ConfigBaseJson.enabledCoop.Value;
            _baseJson.EscapeTimeLimit = ConfigBaseJson.escapeTimeLimit.Value;
            _baseJson.EscapeTimeLimitCoop = ConfigBaseJson.escapeTimeLimitCoop.Value;
            _baseJson.GenerateLocalLootCache = ConfigBaseJson.generateLocalLootCache.Value;
            _baseJson.GlobalLootChanceModifier = ConfigBaseJson.globalLootChanceModifier.Value;
            _baseJson.IconX = ConfigBaseJson.iconX.Value;
            _baseJson.IconY = ConfigBaseJson.iconY.Value;
            _baseJson.Id = ConfigBaseJson.idMap.Value;
            _baseJson.Insurance = ConfigBaseJson.insurance.Value;
            _baseJson.IsSecret = ConfigBaseJson.isSecret.Value;
            _baseJson.Locked = ConfigBaseJson.locked.Value;
            _baseJson.Loot = new List<object>();
            _baseJson.MaxBotPerZone = ConfigBaseJson.maxBotPerZone.Value;
            _baseJson.MaxCoopGroup = ConfigBaseJson.maxCoopGroup.Value;
            _baseJson.MaxDistToFreePoint = ConfigBaseJson.maxDistToFreePoint.Value;
            _baseJson.MaxPlayers = ConfigBaseJson.maxPlayers.Value;
            _baseJson.MinDistToExitPoint = ConfigBaseJson.minDistToExitPoint.Value;
            _baseJson.MinDistToFreePoint = ConfigBaseJson.minDistToFreePoint.Value;
            _baseJson.MinMaxBots = new List<MinMaxBot>();
            _baseJson.MinPlayers = ConfigBaseJson.minPlayers.Value;
            _baseJson.Name = ConfigBaseJson.name.Value;
            _baseJson.NewSpawn = ConfigBaseJson.newSpawn.Value;
            _baseJson.OcculsionCullingEnabled = ConfigBaseJson.occulsionCullingEnabled.Value;
            _baseJson.OldSpawn = ConfigBaseJson.oldSpawn.Value;
            _baseJson.OpenZones = ConfigBaseJson.openZones.Value;
            _baseJson.PmcMaxPlayersInGroup = ConfigBaseJson.pmcMaxPlayersInGroup.Value;
            //Preview
            preview.path = ConfigBaseJson.previewPath.Value;
            preview.rcid = ConfigBaseJson.previewRcid.Value;
            _baseJson.Preview = preview;
            //Root
            _baseJson.RequiredPlayerLevelMin = ConfigBaseJson.requiredLevelMin.Value;
            _baseJson.RequiredPlayerLevelMax = ConfigBaseJson.requiredLevelMax.Value;
            _baseJson.Rules = ConfigBaseJson.rules.Value;
            _baseJson.SafeLocation = ConfigBaseJson.safeLocation.Value;
            _baseJson.ScavMaxPlayersInGroup = ConfigBaseJson.scavMaxPlayersInGroup.Value;
            //Scene
            scene.path = ConfigBaseJson.scenePath.Value;
            scene.rcid = ConfigBaseJson.sceneRcid.Value;
            _baseJson.Scene = scene;
            //Root
            _baseJson.SpawnPointParams = new List<SpawnPointParam>();
            _baseJson.UnixDateTime = unixTime;
            _baseJson._Id = CreateIdString();
            _baseJson.doors = new List<object>();
            _baseJson.exit_access_time = ConfigBaseJson.exitAccessTime.Value;
            _baseJson.exit_count = ConfigBaseJson.exitCount.Value;
            _baseJson.exit_time = ConfigBaseJson.exitTime.Value;
            _baseJson.exits = new List<Exit>();
            _baseJson.filter_ex = new List<object>();
            _baseJson.limits = new List<object>();
            _baseJson.matching_min_seconds = ConfigBaseJson.matchingMinSeconds.Value;
            _baseJson.maxItemCountInLocation = new List<MaxItemCountInLocation>();
            _baseJson.sav_summon_seconds = ConfigBaseJson.savSummonSeconds.Value;
            _baseJson.tmp_location_field_remove_me = ConfigBaseJson.tmpLocationFieldRemoveMe.Value;
            _baseJson.users_gather_seconds = ConfigBaseJson.usersGatherSeconds.Value;
            _baseJson.users_spawn_seconds_n = ConfigBaseJson.usersSpawnSecondsN.Value;
            _baseJson.users_spawn_seconds_n2 = ConfigBaseJson.usersSpawnSecondsN2.Value;
            _baseJson.users_summon_seconds = ConfigBaseJson.usersSummonSeconds.Value;
            _baseJson.waves = new List<Wave>();

            BuildBannerJson();
            BuildBaseJson();
        }

        public void BuildBannerJson()
        {
            foreach (var kvp in __baseJsonConstants.Banners)
            {
                Banner banner = new Banner();
                Pic pic = new Pic();

                banner.id = kvp.Key;
                pic.path = kvp.Value;
                pic.rcid = "";
                banner.pic = pic;

                _baseJson.Banners.Add(banner);
            }
        }

        public void BuildBaseJson()
        {
            _mapJsonExport = JsonConvert.SerializeObject(_baseJson, Formatting.Indented);
        }

        //Creates a random alphanumeric string 24 characters long
        private string CreateIdString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, 24)
                .Select(s => s[_random.Next(s.Length)]).ToArray()).ToLower();
        }
        
        public void ExportBaseJson()
        {
            using (StreamWriter file = File.CreateText(AppDomain.CurrentDomain.BaseDirectory + @"\base.json"))
            using (JsonWriter writer = new JsonTextWriter(file))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteRaw(_mapJsonExport);
                writer.Close();
            }
        }
    }
}