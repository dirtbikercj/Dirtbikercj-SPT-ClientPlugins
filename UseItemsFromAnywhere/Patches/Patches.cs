using Aki.Reflection.Patching;
using EFT.InventoryLogic;
using HarmonyLib;
using System.Linq;
using System.Reflection;

namespace UseItemsFromAnywhere
{
    public class UseItemsFromAnywhere
    {
        private static readonly EquipmentSlot[] FastAccessSlots = new EquipmentSlot[]
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

        private static readonly EquipmentSlot[] BindAvailableSlotsExtended = new EquipmentSlot[]
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
            public Slot? parentSlot;

            internal bool GetParentSlot(Slot slot)
            {
                return slot == parentSlot;
            }
        }

        private static string[] items =
        {
            "62178c4d4ecf221597654e3d", // Red Flare
            "624c0b3340357b5f566e8766", // Yellow Flare
            "6217726288ed9f0845317459", // green Flare
            "62178be9d0050232da3485d9"  // white Flare
        };

        public class IsAtBindablePlace : ModulePatch
        {
            protected override MethodBase GetTargetMethod() =>
                typeof(InventoryControllerClass).GetMethod("IsAtBindablePlace", BindingFlags.Public | BindingFlags.Instance);

            [PatchPostfix]
            private static void Postfix(InventoryControllerClass __instance, ref bool __result, ref Item item)
            {
                Inventory inventory =
                    (Inventory)AccessTools.Property(typeof(InventoryControllerClass), "Inventory").GetValue(__instance);

                if (item.CurrentAddress != null && !(item.Parent is GClass2576) && item.CurrentAddress.Container.ParentItem is not StashClass)
                {
                    if (inventory.GetItemsInSlots(BindAvailableSlotsExtended).Contains(item)
                        && __instance.Examined(item)
                        && FastAccessSlots.Select(inventory.Equipment.GetSlot).Any(new SlotHelper().GetParentSlot)
                        && item is Weapon || item is GrenadeClass || item.GetItemComponent<KnifeComponent>() != null
                        || item is MedsClass || item is FoodClass || item is GClass2542 || item is GClass2543
                        || item is RecodableItemClass || items.Contains(item.TemplateId))
                    {
                        __result = true;
                        return;
                    }
                    else
                    {
                        __result = false;
                        return;
                    }
                }
            }
        }

        public class IsAtReachablePlace : ModulePatch
        {
            protected override MethodBase GetTargetMethod() =>
                typeof(InventoryControllerClass).GetMethod("IsAtReachablePlace", BindingFlags.Public | BindingFlags.Instance);

            [PatchPostfix]
            private static void Postfix(InventoryControllerClass __instance, ref bool __result, ref Item item)
            {
                Inventory inventory =
                    (Inventory)AccessTools.Property(typeof(InventoryControllerClass), "Inventory").GetValue(__instance);

                if (item.CurrentAddress is null || item.CurrentAddress.Container.ParentItem is StashClass)
                {
                    return;
                }

                LootItemClass? lootItemClass;

                if ((inventory.Stash == null || item.Parent.Container != inventory.Stash.Grid)
                    && ((lootItemClass = item as LootItemClass) == null || !lootItemClass.MissingVitalParts.Any())
                    && inventory.GetItemsInSlots(BindAvailableSlotsExtended).Contains(item) && __instance.Examined(item)
                    && item is Weapon || item is GrenadeClass || item.GetItemComponent<KnifeComponent>() != null
                    || item is MedsClass || item is FoodClass || item is GClass2542 || item is GClass2543
                    || item is RecodableItemClass || items.Contains(item.TemplateId))
                {
                    __result = true;
                    return;
                }
                else
                {
                    __result = false;
                    return;
                }
            }
        }
    }
}