using System.Linq;
using System.Reflection;
using Aki.Reflection.Patching;
using EFT.InventoryLogic;
using HarmonyLib;


namespace UseItemsFromAnywhere
{
    public class UseItemsFromAnywhere
    {
        public static readonly EquipmentSlot[] FastAccessSlots = new EquipmentSlot[]
        {
            EquipmentSlot.FirstPrimaryWeapon,
            EquipmentSlot.SecondPrimaryWeapon,
            EquipmentSlot.Holster,
            EquipmentSlot.Scabbard,
            EquipmentSlot.Pockets,
            EquipmentSlot.TacticalVest,
            EquipmentSlot.Backpack,
            EquipmentSlot.SecuredContainer
        };

        public static readonly EquipmentSlot[] BindAvailableSlotsExtended = new EquipmentSlot[]
        {
            EquipmentSlot.FirstPrimaryWeapon,
            EquipmentSlot.SecondPrimaryWeapon,
            EquipmentSlot.Holster,
            EquipmentSlot.Scabbard,
            EquipmentSlot.Pockets,
            EquipmentSlot.TacticalVest,
            EquipmentSlot.Backpack,
            EquipmentSlot.SecuredContainer
        };

        private sealed class SlotHelper
        {
            public required Slot parentSlot;

            internal bool GetParentSlot(Slot slot)
            {
                return slot == parentSlot;
            }
        }

        public class IsAtBindablePlace : ModulePatch
        {
            

            protected override MethodBase GetTargetMethod() =>
                typeof(InventoryControllerClass).GetMethod("IsAtBindablePlace", BindingFlags.Public | BindingFlags.Instance);

            [PatchPostfix]
            static void Postfix(InventoryControllerClass __instance, ref bool __result, ref Item item)
            {
                const string redFlare = "62178c4d4ecf221597654e3d";
                const string yellowFlare = "624c0b3340357b5f566e8766";
                const string greenFlare = "6217726288ed9f0845317459";
                const string whiteFlare = "62178be9d0050232da3485d9";

                InventoryClass inventory =
                    (InventoryClass)AccessTools.Property(typeof(InventoryControllerClass), "Inventory").GetValue(__instance);

                if (item.CurrentAddress != null && !(item.Parent is GClass2664) && item.CurrentAddress.Container.ParentItem is not StashClass)
                {
                    if (inventory.GetItemsInSlots(BindAvailableSlotsExtended).Contains(item)
                        && __instance.Examined(item)
                        && FastAccessSlots.Select(inventory.Equipment.GetSlot).Any(new SlotHelper().GetParentSlot)
                        && item is Weapon || item is GrenadeClass || item.GetItemComponent<KnifeComponent>() != null
                        || item is MedsClass || item is FoodClass || item is GClass2632 || item is GClass2631
                        || item is RecodableItemClass || item.TemplateId == greenFlare || item.TemplateId == redFlare 
                        || item.TemplateId == yellowFlare || item.TemplateId == whiteFlare)
                    {
                        __result = true;
                    }
                    else
                    {
                        __result = false;
                    }
                }
            }
        }

        public class IsAtReachablePlace : ModulePatch
        {
            
            protected override MethodBase GetTargetMethod() =>
                typeof(InventoryControllerClass).GetMethod("IsAtReachablePlace", BindingFlags.Public | BindingFlags.Instance);

            [PatchPostfix]
            static void Postfix(InventoryControllerClass __instance, ref bool __result, ref Item item)
            {
                const string redFlare = "62178c4d4ecf221597654e3d";
                const string yellowFlare = "624c0b3340357b5f566e8766";
                const string greenFlare = "6217726288ed9f0845317459";
                const string whiteFlare = "62178be9d0050232da3485d9";

                InventoryClass? inventory =
                    AccessTools.Property(typeof(InventoryControllerClass), "Inventory").GetValue(__instance) as InventoryClass;

                if (item.CurrentAddress == null)
                {
                    __result = false;
                }

                LootItemClass lootItemClass;

                if ((inventory.Stash == null || item.Parent.Container != inventory.Stash.Grid)
                    && ((lootItemClass = item as LootItemClass) == null || !lootItemClass.MissingVitalParts.Any())
                    && inventory.GetItemsInSlots(BindAvailableSlotsExtended).Contains(item) && __instance.Examined(item)
                    && item is Weapon || item is GrenadeClass || item.GetItemComponent<KnifeComponent>() != null
                    || item is MedsClass || item is FoodClass || item is GClass2632 || item is GClass2631 
                    || item is RecodableItemClass || item.TemplateId == greenFlare || item.TemplateId == redFlare 
                    || item.TemplateId == yellowFlare || item.TemplateId == whiteFlare)
                {
                    __result = true;
                }
                else
                {
                    __result = false;
                }
            }
        }
    }
}