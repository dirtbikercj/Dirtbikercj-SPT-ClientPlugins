﻿using System.Collections.Generic;

namespace MapTools.Data.Base
{
    public class BaseJson
    {
        public List<object> AccessKeys { get; set; }
        public List<AirdropParameter> AirdropParameters { get; set; }
        public double Area { get; set; }
        public int AveragePlayTime { get; set; }
        public int AveragePlayerLevel { get; set; }
        public List<Banner> Banners { get; set; }
        public List<BossLocationSpawns> BossLocationSpawn = new List<BossLocationSpawns>();
        public int BotAssault { get; set; }
        public int BotEasy { get; set; }
        public int BotHard { get; set; }
        public int BotImpossible { get; set; }
        public BotLocationModifier BotLocationModifier = new BotLocationModifier();
        public int BotMarksman { get; set; }
        public int BotMax { get; set; }
        public int BotMaxPlayer { get; set; }
        public int BotMaxTimePlayer { get; set; }
        public int BotNormal { get; set; }
        public int BotSpawnTimeOffMax { get; set; }
        public int BotSpawnTimeOffMin { get; set; }
        public int BotSpawnTimeOnMax { get; set; }
        public int BotSpawnTimeOnMin { get; set; }
        public int BotStart { get; set; }
        public int BotStop { get; set; }
        public string Description { get; set; }
        public bool DisabledForScav { get; set; }
        public string DisabledScavExits { get; set; }
        public bool Enabled { get; set; }
        public bool EnabledCoop { get; set; }
        public int EscapeTimeLimit { get; set; }
        public int EscapeTimeLimitCoop { get; set; }
        public bool GenerateLocalLootCache { get; set; }
        public double GlobalLootChanceModifier { get; set; }
        public int IconX { get; set; }
        public int IconY { get; set; }
        public string Id { get; set; }
        public bool Insurance { get; set; }
        public bool IsSecret { get; set; }
        public bool Locked { get; set; }
        public List<object> Loot { get; set; }
        public int MaxBotPerZone { get; set; }
        public int MaxCoopGroup { get; set; }
        public int MaxDistToFreePoint { get; set; }
        public int MaxPlayers { get; set; }
        public int MinDistToExitPoint { get; set; }
        public int MinDistToFreePoint { get; set; }
        public List<MinMaxBot> MinMaxBots { get; set; }
        public int MinPlayers { get; set; }
        public string Name { get; set; }
        public bool NewSpawn { get; set; }
        public bool OcculsionCullingEnabled { get; set; }
        public bool OldSpawn { get; set; }
        public string OpenZones { get; set; }
        public int PmcMaxPlayersInGroup { get; set; }
        public Preview Preview { get; set; }
        public int RequiredPlayerLevelMin { get; set; }
        public int RequiredPlayerLevelMax { get; set; }
        public string Rules { get; set; }
        public bool SafeLocation { get; set; }
        public int ScavMaxPlayersInGroup { get; set; }
        public Scene Scene { get; set; }
        public List<SpawnPointParam> SpawnPointParams { get; set; }
        public long UnixDateTime { get; set; }
        public string _Id { get; set; }
        public List<object> doors { get; set; }
        public int exit_access_time { get; set; }
        public int exit_count { get; set; }
        public int exit_time { get; set; }
        public List<Exit> exits { get; set; }
        public List<object> filter_ex { get; set; }
        public List<object> limits { get; set; }
        public int matching_min_seconds { get; set; }
        public List<MaxItemCountInLocation> maxItemCountInLocation { get; set; }
        public int sav_summon_seconds { get; set; }
        public int tmp_location_field_remove_me { get; set; }
        public int users_gather_seconds { get; set; }
        public int users_spawn_seconds_n { get; set; }
        public int users_spawn_seconds_n2 { get; set; }
        public int users_summon_seconds { get; set; }
        public List<Wave> waves { get; set; }
    }

    public class AirdropParameter
    {
        public int AirdropPointDeactivateDistance { get; set; }
        public int MinPlayersCountToSpawnAirdrop { get; set; }
        public double PlaneAirdropChance { get; set; }
        public int PlaneAirdropCooldownMax { get; set; }
        public int PlaneAirdropCooldownMin { get; set; }
        public int PlaneAirdropEnd { get; set; }
        public int PlaneAirdropMax { get; set; }
        public int PlaneAirdropStartMax { get; set; }
        public int PlaneAirdropStartMin { get; set; }
        public int UnsuccessfulTryPenalty { get; set; }
    }

    public class Banner
    {
        public string id { get; set; }
        public Pic pic { get; set; }
    }
    public class BossLocationSpawns
    {
        public int BossChance { get; set; }
        public string BossDifficult { get; set; }
        public string BossEscortAmount { get; set; }
        public string BossEscortDifficult { get; set; }
        public string BossEscortType { get; set; }
        public string BossName { get; set; }
        public bool BossPlayer { get; set; }
        public string BossZone { get; set; }
        public bool RandomTimeSpawns { get; set; }
        public List<Support> Supports { get; set; }
        public int Time { get; set; }
    }

    public class BotLocationModifier
    {
        public int AccuracySpeed { get; set; }
        public int DistToActivate { get; set; }
        public double DistToPersueAxemanCoef { get; set; }
        public int DistToSleep { get; set; }
        public int GainSight { get; set; }
        public int KhorovodChance { get; set; }
        public int MagnetPower { get; set; }
        public int MarksmanAccuratyCoef { get; set; }
        public int Scattering { get; set; }
        public int VisibleDistance { get; set; }
    }

    public class Center
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
    }

    public class ColliderParams
    {
        public string _parent { get; set; }
        public Props _props { get; set; }
    }

    public class Exit
    {
        public int Chance { get; set; }
        public int Count { get; set; }
        public string EntryPoints { get; set; }
        public int ExfiltrationTime { get; set; }
        public string ExfiltrationType { get; set; }
        public string Id { get; set; }
        public int MaxTime { get; set; }
        public int MinTime { get; set; }
        public string Name { get; set; }
        public string PassageRequirement { get; set; }
        public int PlayersCount { get; set; }
        public string RequirementTip { get; set; }
    }

    public class MaxItemCountInLocation
    {
        public string TemplateId { get; set; }
        public int Value { get; set; }
    }

    public class MinMaxBot
    {
        public string WildSpawnType { get; set; }
        public int max { get; set; }
        public int min { get; set; }
    }

    public class Pic
    {
        public string path { get; set; }
        public string rcid { get; set; }
    }

    public class Position
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
    }

    public class Preview
    {
        public string path { get; set; }
        public string rcid { get; set; }
    }

    public class Props
    {
        public Center Center { get; set; }
        public double Radius { get; set; }
        public Size Size { get; set; }
    }

    public class Scene
    {
        public string path { get; set; }
        public string rcid { get; set; }
    }

    public class Size
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
    }

    public class SpawnPointParam
    {
        public string BotZoneName { get; set; }
        public List<string> Categories { get; set; }
        public ColliderParams ColliderParams { get; set; }
        public int DelayToCanSpawnSec { get; set; }
        public string Id { get; set; }
        public string Infiltration { get; set; }
        public Position Position { get; set; }
        public double Rotation { get; set; }
        public List<string> Sides { get; set; }
    }
    public class Support
    {
        public string BossEscortAmount { get; set; }
        public List<string> BossEscortDifficult { get; set; }
        public string BossEscortType { get; set; }
    }

    public class Wave
    {
        public string BotPreset { get; set; }
        public string BotSide { get; set; }
        public string SpawnPoints { get; set; }
        public string WildSpawnType { get; set; }
        public bool isPlayers { get; set; }
        public int number { get; set; }
        public int slots_max { get; set; }
        public int slots_min { get; set; }
        public int time_max { get; set; }
        public int time_min { get; set; }
    }
}
