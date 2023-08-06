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
            public Slot parentSlot;

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
                InventoryClass inventory =
                    AccessTools.Property(typeof(InventoryControllerClass), "Inventory").GetValue(__instance) as InventoryClass;

                if (item.CurrentAddress != null && !(item.Parent is GClass2664))
                {
                    if (inventory.GetItemsInSlots(BindAvailableSlotsExtended).Contains(item)
                        && __instance.Examined(item)
                        && FastAccessSlots.Select(inventory.Equipment.GetSlot).Any(new SlotHelper().GetParentSlot)
                        && item is Weapon || item is GrenadeClass || item.GetItemComponent<KnifeComponent>() != null
                        || item is MedsClass || item is FoodClass || item is GClass2632 || item is GClass2631
                        || item is RecodableItemClass)
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
                    || item is RecodableItemClass)
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