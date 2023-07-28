using EFT.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MapTools.Helpers;
using MapTools.Data.Base;

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
            DateTime datetime = DateTime.Now;
            long unixTime = ((DateTimeOffset)datetime).ToUnixTimeSeconds();

            //Root
            _baseJson.AccessKeys = new List<object>();
            _baseJson.AirdropParameters = new List<AirdropParameter>();
            _baseJson.Area = MapToolsConfig.area.Value;
            _baseJson.AveragePlayTime = MapToolsConfig.averagePlayTime.Value;
            _baseJson.AveragePlayerLevel = MapToolsConfig.averagePlayerLevel.Value;
            _baseJson.Banners = new List<Banner>();
            //BossLocationSpawn
            bossLocationSpawn.BossChance = MapToolsConfig.bossChance.Value;
            bossLocationSpawn.BossDifficult = MapToolsConfig.bossDifficulty.Value;
            bossLocationSpawn.BossEscortAmount = MapToolsConfig.bossEscortAmount.Value;
            bossLocationSpawn.BossEscortDifficult = MapToolsConfig.bossEscortDifficult.Value;
            bossLocationSpawn.BossEscortType = MapToolsConfig.bossEscortType.Value;
            bossLocationSpawn.BossName = MapToolsConfig.bossName.Value;
            bossLocationSpawn.BossPlayer = MapToolsConfig.bossPlayer.Value;
            bossLocationSpawn.RandomTimeSpawns = MapToolsConfig.randomTimeSpawn.Value;
            bossLocationSpawn.BossZone = MapToolsConfig.bossZone.Value;
            bossLocationSpawn.Supports = new List<Support>();
            bossLocationSpawn.Time = MapToolsConfig.bossTime.Value;
            _baseJson.BossLocationSpawn.Add(bossLocationSpawn);
            //Root
            _baseJson.BotAssault = MapToolsConfig.botAssault.Value;
            _baseJson.BotEasy = MapToolsConfig.botEasy.Value;
            _baseJson.BotHard = MapToolsConfig.botHard.Value;
            _baseJson.BotImpossible = MapToolsConfig.botImpossible.Value;
            //BotLoactionModifier
            _baseJson.BotLocationModifier.AccuracySpeed = MapToolsConfig.accuracySpeed.Value;
            _baseJson.BotLocationModifier.DistToActivate = MapToolsConfig.distToActivate.Value;
            _baseJson.BotLocationModifier.DistToPersueAxemanCoef = MapToolsConfig.distToPersueAxemanCoef.Value;
            _baseJson.BotLocationModifier.DistToSleep = MapToolsConfig.distToSleep.Value;
            _baseJson.BotLocationModifier.GainSight = MapToolsConfig.gainSight.Value;
            _baseJson.BotLocationModifier.KhorovodChance = MapToolsConfig.khorovodChange.Value;
            _baseJson.BotLocationModifier.MagnetPower = MapToolsConfig.magnetPower.Value;
            _baseJson.BotLocationModifier.MarksmanAccuratyCoef = MapToolsConfig.marksmanAccuracyCoef.Value;
            _baseJson.BotLocationModifier.Scattering = MapToolsConfig.scattering.Value;
            _baseJson.BotLocationModifier.VisibleDistance = MapToolsConfig.visibleDistance.Value;
            //Root
            _baseJson.BotMarksman = MapToolsConfig.botMarksman.Value;
            _baseJson.BotMax = MapToolsConfig.botMax.Value;
            _baseJson.BotMaxPlayer = MapToolsConfig.botMaxPlayer.Value;
            _baseJson.BotMaxTimePlayer = MapToolsConfig.botMaxTimePlayer.Value;
            _baseJson.BotNormal = MapToolsConfig.botNormal.Value;
            _baseJson.BotSpawnTimeOffMax = MapToolsConfig.botSpawnTimeOffMax.Value;
            _baseJson.BotSpawnTimeOffMin = MapToolsConfig.botSpawnTimeOffMin.Value;
            _baseJson.BotSpawnTimeOnMax = MapToolsConfig.botSpawnTimeOnMax.Value;
            _baseJson.BotSpawnTimeOnMin = MapToolsConfig.botSpawnTimeOnMin.Value;
            _baseJson.BotStart = MapToolsConfig.botStart.Value;
            _baseJson.BotStop = MapToolsConfig.botStop.Value;
            _baseJson.Description = MapToolsConfig.description.Value;
            _baseJson.DisabledForScav = MapToolsConfig.disabledForScav.Value;
            _baseJson.DisabledScavExits = MapToolsConfig.disabledScavExits.Value;
            _baseJson.Enabled = MapToolsConfig.enabled.Value;
            _baseJson.EnabledCoop = MapToolsConfig.enabledCoop.Value;
            _baseJson.EscapeTimeLimit = MapToolsConfig.escapeTimeLimit.Value;
            _baseJson.EscapeTimeLimitCoop = MapToolsConfig.escapeTimeLimitCoop.Value;
            _baseJson.GenerateLocalLootCache = MapToolsConfig.generateLocalLootCache.Value;
            _baseJson.GlobalLootChanceModifier = MapToolsConfig.globalLootChanceModifier.Value;
            _baseJson.IconX = MapToolsConfig.iconX.Value;
            _baseJson.IconY = MapToolsConfig.iconY.Value;
            _baseJson.Id = MapToolsConfig.idMap.Value;
            _baseJson.Insurance = MapToolsConfig.insurance.Value;
            _baseJson.IsSecret = MapToolsConfig.isSecret.Value;
            _baseJson.Locked = MapToolsConfig.locked.Value;
            _baseJson.Loot = new List<object>();
            _baseJson.MaxBotPerZone = MapToolsConfig.maxBotPerZone.Value;
            _baseJson.MaxCoopGroup = MapToolsConfig.maxCoopGroup.Value;
            _baseJson.MaxDistToFreePoint = MapToolsConfig.maxDistToFreePoint.Value;
            _baseJson.MaxPlayers = MapToolsConfig.maxPlayers.Value;
            _baseJson.MinDistToExitPoint = MapToolsConfig.minDistToExitPoint.Value;
            _baseJson.MinDistToFreePoint = MapToolsConfig.minDistToFreePoint.Value;
            _baseJson.MinMaxBots = new List<MinMaxBot>();
            _baseJson.MinPlayers = MapToolsConfig.minPlayers.Value;
            _baseJson.Name = MapToolsConfig.name.Value;
            _baseJson.NewSpawn = MapToolsConfig.newSpawn.Value;
            _baseJson.OcculsionCullingEnabled = MapToolsConfig.occulsionCullingEnabled.Value;
            _baseJson.OldSpawn = MapToolsConfig.oldSpawn.Value;
            _baseJson.OpenZones = MapToolsConfig.openZones.Value;
            _baseJson.PmcMaxPlayersInGroup = MapToolsConfig.pmcMaxPlayersInGroup.Value;
            //Preview
            preview.path = MapToolsConfig.previewPath.Value;
            preview.rcid = MapToolsConfig.previewRcid.Value;
            _baseJson.Preview = preview;
            //Root
            _baseJson.RequiredPlayerLevelMin = MapToolsConfig.requiredLevelMin.Value;
            _baseJson.RequiredPlayerLevelMax = MapToolsConfig.requiredLevelMax.Value;
            _baseJson.Rules = MapToolsConfig.rules.Value;
            _baseJson.SafeLocation = MapToolsConfig.safeLocation.Value;
            _baseJson.ScavMaxPlayersInGroup = MapToolsConfig.scavMaxPlayersInGroup.Value;
            //Scene
            scene.path = MapToolsConfig.scenePath.Value;
            scene.rcid = MapToolsConfig.sceneRcid.Value;
            _baseJson.Scene = scene;
            //Root
            _baseJson.SpawnPointParams = new List<SpawnPointParam>();
            _baseJson.UnixDateTime = unixTime;
            _baseJson._Id = CreateIdString();
            _baseJson.doors = new List<object>();
            _baseJson.exit_access_time = MapToolsConfig.exitAccessTime.Value;
            _baseJson.exit_count = MapToolsConfig.exitCount.Value;
            _baseJson.exit_time = MapToolsConfig.exitTime.Value;
            _baseJson.exits = new List<Exit>();
            _baseJson.filter_ex = new List<object>();
            _baseJson.limits = new List<object>();
            _baseJson.matching_min_seconds = MapToolsConfig.matchingMinSeconds.Value;
            _baseJson.maxItemCountInLocation = new List<MaxItemCountInLocation>();
            _baseJson.sav_summon_seconds = MapToolsConfig.savSummonSeconds.Value;
            _baseJson.tmp_location_field_remove_me = MapToolsConfig.tmpLocationFieldRemoveMe.Value;
            _baseJson.users_gather_seconds = MapToolsConfig.usersGatherSeconds.Value;
            _baseJson.users_spawn_seconds_n = MapToolsConfig.usersSpawnSecondsN.Value;
            _baseJson.users_spawn_seconds_n2 = MapToolsConfig.usersSpawnSecondsN2.Value;
            _baseJson.users_summon_seconds = MapToolsConfig.usersSummonSeconds.Value;
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
                .Select(s => s[_random.Next(s.Length)]).ToArray());
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