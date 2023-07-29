using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace MapTools.Data.Loot
{
    internal class ItemsJsonData
    {
        public class Root
        {
            public string _id { get; set; }
            public bool? _mergeSlotWithChildren { get; set; }

            // Name of Item
            public string _name { get; set; }

            // Parent ID of item
            public string _parent { get; set; }

            // Properties
            //public Props _props { get; set; }

            // Type of container, by ID
            public string _proto { get; set; }

            public bool? _required { get; set; }
        }

        public class AppliedHeadRotation
        {
            public int? x { get; set; }
            public int? y { get; set; }
            public int? z { get; set; }
        }

        public class AppliedTrunkRotation
        {
            public int? x { get; set; }
            public int? y { get; set; }
            public int? z { get; set; }
        }

        public class ArmorDistanceDistanceDamage
        {
            public int? x { get; set; }
            public int? y { get; set; }
            public int? z { get; set; }
        }

        public class Blindness
        {
            public int? x { get; set; }
            public int? y { get; set; }
            public int? z { get; set; }
        }

        public class Cartridge
        {
            public string _id { get; set; }
            public int? _max_count { get; set; }
            public string _name { get; set; }
            public string _parent { get; set; }
            public Props _props { get; set; }
            public string _proto { get; set; }
        }

        public class Chamber
        {
            public string _id { get; set; }
            public bool? _mergeSlotWithChildren { get; set; }
            public string _name { get; set; }
            public string _parent { get; set; }
            public Props _props { get; set; }
            public string _proto { get; set; }
            public bool? _required { get; set; }
        }

        public class ColliderScaleMultiplier
        {
            public int? x { get; set; }
            public int? y { get; set; }
            public int? z { get; set; }
        }

        public class Contusion
        {
            public double? x { get; set; }
            public int? y { get; set; }
            public int? z { get; set; }
        }

        public class Filters
        {
            public List<string> Filter { get; set; }
            public int? Shift { get; set; }
            public int? AnimationIndex { get; set; }
        }

        public class Prefab
        {
            public string path { get; set; }
            public string rcid { get; set; }
        }

        public class Props
        {
            public int? AnimationVariantsNumber { get; set; }
            public string BackgroundColor { get; set; }
            public bool? CanRequireOnRagfair { get; set; }
            public bool? CanSellOnRagfair { get; set; }
            public List<object> ConflictingItems { get; set; }
            public string Description { get; set; }
            public int? DiscardLimit { get; set; }
            public bool? DiscardingBlock { get; set; }
            public string DropSoundType { get; set; }
            public int? ExamineExperience { get; set; }
            public int? ExamineTime { get; set; }
            public bool? ExaminedByDefault { get; set; }
            public int? ExtraSizeDown { get; set; }
            public bool? ExtraSizeForceAdd { get; set; }
            public int? ExtraSizeLeft { get; set; }
            public int? ExtraSizeRight { get; set; }
            public int? ExtraSizeUp { get; set; }
            public int? Height { get; set; }
            public bool? HideEntrails { get; set; }
            public bool? InsuranceDisabled { get; set; }
            public bool? IsAlwaysAvailableForInsurance { get; set; }
            public bool? IsLockedafterEquip { get; set; }
            public bool? IsSpecialSlotOnly { get; set; }
            public bool? IsUnbuyable { get; set; }
            public bool? IsUndiscardable { get; set; }
            public bool? IsUngivable { get; set; }
            public bool? IsUnremovable { get; set; }
            public bool? IsUnsaleable { get; set; }
            public string ItemSound { get; set; }
            public int? LootExperience { get; set; }
            public bool? MergesWithChildren { get; set; }
            public string Name { get; set; }
            public bool? NotShownInSlot { get; set; }
            public Prefab Prefab { get; set; }
            public bool? QuestItem { get; set; }
            public int? QuestStashMaxCount { get; set; }
            public int? RagFairCommissionModifier { get; set; }
            public int? RepairCost { get; set; }
            public int? RepairSpeed { get; set; }
            public string ShortName { get; set; }
            public int? StackMaxSize { get; set; }
            public int? StackObjectsCount { get; set; }
            public bool? Unlootable { get; set; }
            public List<object> UnlootableFromSide { get; set; }
            public string UnlootableFromSlot { get; set; }
            public UsePrefab UsePrefab { get; set; }
            public int? Weight { get; set; }
            public int? Width { get; set; }
            public bool? AdjustCollimatorsToTrajectory { get; set; }
            public double? AimPlane { get; set; }
            public double? AimSensitivity { get; set; }
            public bool? AllowFeed { get; set; }
            public bool? AllowJam { get; set; }
            public bool? AllowMisfire { get; set; }
            public bool? AllowOverheat { get; set; }
            public bool? AllowSlide { get; set; }
            public double? BaseMalfunctionChance { get; set; }
            public bool? BoltAction { get; set; }
            public int? BurstShotsCount { get; set; }
            public double? CameraRecoil { get; set; }
            public double? CameraSnap { get; set; }
            public bool? CanPutIntoDuringTheRaid { get; set; }
            public bool? CanQueueSecondShot { get; set; }
            public List<object> CantRemoveFromSlotsDuringRaid { get; set; }
            public double? CenterOfImpact { get; set; }
            public List<Chamber> Chambers { get; set; }
            public bool? CompactHandling { get; set; }
            public double? Convergence { get; set; }
            public double? CoolFactorGun { get; set; }
            public int? CoolFactorGunMods { get; set; }
            public double? DeviationCurve { get; set; }
            public int? DeviationMax { get; set; }
            public double? DoubleActionAccuracyPenalty { get; set; }
            public int? Durability { get; set; }
            public double? DurabilityBurnRatio { get; set; }
            public int? Ergonomics { get; set; }
            public bool? Foldable { get; set; }
            public string FoldedSlot { get; set; }
            public List<object> Grids { get; set; }
            public double? HeatFactorByShot { get; set; }
            public int? HeatFactorGun { get; set; }
            public double? HipAccuracyRestorationDelay { get; set; }
            public int? HipAccuracyRestorationSpeed { get; set; }
            public double? HipInnaccuracyGain { get; set; }
            public int? IronSightRange { get; set; }
            public bool? IsFlareGun { get; set; }
            public bool? IsGrenadeLauncher { get; set; }
            public bool? IsOneoff { get; set; }
            public bool? ManualBoltCatch { get; set; }
            public int? MaxDurability { get; set; }
            public double? MaxRepairDegradation { get; set; }
            public double? MaxRepairKitDegradation { get; set; }
            public int? MinRepairDegradation { get; set; }
            public int? MinRepairKitDegradation { get; set; }
            public bool? MustBoltBeOpennedForExternalReload { get; set; }
            public bool? MustBoltBeOpennedForInternalReload { get; set; }
            public bool? NoFiremodeOnBoltcatch { get; set; }
            public int? OperatingResource { get; set; }
            public int? RecoilAngle { get; set; }
            public RecoilCenter RecoilCenter { get; set; }
            public int? RecoilForceBack { get; set; }
            public int? RecoilForceUp { get; set; }
            public int? RecoilPosZMult { get; set; }
            public int? RecolDispersion { get; set; }
            public string ReloadMode { get; set; }
            public int? RepairComplexity { get; set; }
            public bool? Retractable { get; set; }
            public RotationCenter RotationCenter { get; set; }
            public RotationCenterNoStock RotationCenterNoStock { get; set; }
            public int? SightingRange { get; set; }
            public int? SingleFireRate { get; set; }
            public int? SizeReduceRight { get; set; }
            public List<Slot> Slots { get; set; }
            public double? TacticalReloadFixation { get; set; }
            public TacticalReloadStiffnes TacticalReloadStiffnes { get; set; }
            public int? Velocity { get; set; }
            public string ammoCaliber { get; set; }
            public int? bEffDist { get; set; }
            public int? bFirerate { get; set; }
            public int? bHearDist { get; set; }
            public int? chamberAmmoCount { get; set; }
            public string defAmmo { get; set; }
            public string defMagType { get; set; }
            public int? durabSpawnMax { get; set; }
            public int? durabSpawnMin { get; set; }
            public bool? isBoltCatch { get; set; }
            public bool? isChamberLoad { get; set; }
            public bool? isFastReload { get; set; }
            public int? shotgunDispersion { get; set; }
            public string weapClass { get; set; }
            public List<string> weapFireType { get; set; }
            public string weapUseType { get; set; }
            public List<Filters> filters { get; set; }
            public int? StackMaxRandom { get; set; }
            public int? StackMinRandom { get; set; }
            public List<StackSlot> StackSlots { get; set; }
            public int? ShotgunDispersion { get; set; }
            public int? apResource { get; set; }
            public int? krResource { get; set; }
            public int? AdditionalAnimationLayer { get; set; }
            public AppliedHeadRotation AppliedHeadRotation { get; set; }
            public AppliedTrunkRotation AppliedTrunkRotation { get; set; }
            public ColliderScaleMultiplier ColliderScaleMultiplier { get; set; }
            public int? DeflectionConsumption { get; set; }
            public bool? DisplayOnModel { get; set; }
            public int? MaxResource { get; set; }
            public int? PrimaryConsumption { get; set; }
            public int? PrimaryDistance { get; set; }
            public int? SecondryConsumption { get; set; }
            public int? SecondryDistance { get; set; }
            public int? SlashPenetration { get; set; }
            public int? StabPenetration { get; set; }
            public int? StaminaBurnRate { get; set; }
            public string StimulatorBuffs { get; set; }
            public int? knifeDurab { get; set; }
            public int? knifeHitDelay { get; set; }
            public int? knifeHitRadius { get; set; }
            public int? knifeHitSlashDam { get; set; }
            public int? knifeHitSlashRate { get; set; }
            public int? knifeHitStabDam { get; set; }
            public int? knifeHitStabRate { get; set; }
            public int? MaximumNumberOfUsage { get; set; }
            public bool? CanAdmin { get; set; }
            public bool? CanFast { get; set; }
            public bool? CanHit { get; set; }
            public List<Cartridge> Cartridges { get; set; }
            public int? CheckOverride { get; set; }
            public int? CheckTimeModifier { get; set; }
            public int? LoadUnloadModifier { get; set; }
            public int? MalfunctionChance { get; set; }
            public string ReloadMagType { get; set; }
            public int? TagColor { get; set; }
            public string TagName { get; set; }
            public string VisibleAmmoRangesString { get; set; }
            public int? magAnimationIndex { get; set; }
            public int? MaxHpResource { get; set; }
            public int? hpResourceRate { get; set; }
            public string medEffectType { get; set; }
            public int? medUseTime { get; set; }
            public ArmorDistanceDistanceDamage ArmorDistanceDistanceDamage { get; set; }
            public Blindness Blindness { get; set; }
            public bool? CanBeHiddenDuringThrow { get; set; }
            public Contusion Contusion { get; set; }
            public int? ContusionDistance { get; set; }
            public int? EmitTime { get; set; }
            public int? ExplDelay { get; set; }
            public string ExplosionEffectType { get; set; }
            public string FragmentType { get; set; }
            public int? FragmentsCount { get; set; }
            public int? MaxExplosionDistance { get; set; }
            public int? MinExplosionDistance { get; set; }
            public int? MinTimeToContactExplode { get; set; }
            public int? Strength { get; set; }
            public string ThrowType { get; set; }
            public double? explDelay { get; set; }
            public int? throwDamMax { get; set; }
            public List<object> containType { get; set; }
            public bool? isSecured { get; set; }
            public List<object> lootFilter { get; set; }
            public int? maxCountSpawn { get; set; }
            public int? minCountSpawn { get; set; }
            public List<object> openedByKeyID { get; set; }
            public int? sizeHeight { get; set; }
            public int? sizeWidth { get; set; }
            public string spawnRarity { get; set; }
            public string spawnTypes { get; set; }
            public int? Accuracy { get; set; }
            public bool? BlocksCollapsible { get; set; }
            public bool? BlocksFolding { get; set; }
            public int? DoubleActionAccuracyPenaltyMult { get; set; }
            public int? EffectiveDistance { get; set; }
            public bool? HasShoulderContact { get; set; }
            public bool? IsAnimated { get; set; }
            public int? Loudness { get; set; }
            public bool? RaidModdable { get; set; }
            public int? Recoil { get; set; }
            public bool? ToolModdable { get; set; }
            public string ArmorMaterial { get; set; }
            public string ArmorType { get; set; }
            public int? BluntThroughput { get; set; }
            public string RigLayoutName { get; set; }
            public int? armorClass { get; set; }
            public List<object> armorZone { get; set; }
            public int? mousePenalty { get; set; }
            public int? speedPenaltyPercent { get; set; }
            public int? weaponErgonomicPenalty { get; set; }
            public string GridLayoutName { get; set; }
            public int? Resource { get; set; }
            public int? eqMax { get; set; }
            public int? eqMin { get; set; }
            public int? rate { get; set; }
            public string type { get; set; }
            public bool? BlocksEarpiece { get; set; }
            public bool? BlocksEyewear { get; set; }
            public bool? BlocksFaceCover { get; set; }
            public bool? BlocksHeadwear { get; set; }
            public string foodEffectType { get; set; }
            public int? foodUseTime { get; set; }
        }

        public class RecoilCenter
        {
            public int? x { get; set; }
            public int? y { get; set; }
            public int? z { get; set; }
        }

        public class RotationCenter
        {
            public int? x { get; set; }
            public int? y { get; set; }
            public int? z { get; set; }
        }

        public class RotationCenterNoStock
        {
            public int? x { get; set; }
            public int? y { get; set; }
            public int? z { get; set; }
        }

        public class Slot
        {
            public string _id { get; set; }
            public bool _mergeSlotWithChildren { get; set; }
            public string _name { get; set; }
            public string _parent { get; set; }
            public Props _props { get; set; }
            public string _proto { get; set; }
            public bool _required { get; set; }
        }

        public class StackSlot
        {
            public string _id { get; set; }
            public int? _max_count { get; set; }
            public string _name { get; set; }
            public string _parent { get; set; }
            public Props _props { get; set; }
            public string _proto { get; set; }
        }

        public class TacticalReloadStiffnes
        {
            public double? x { get; set; }
            public double? y { get; set; }
            public double? z { get; set; }
        }

        public class UsePrefab
        {
            public string path { get; set; }
            public string rcid { get; set; }
        }
    }
}
