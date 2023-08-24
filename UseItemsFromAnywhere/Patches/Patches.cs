using Aki.Reflection.Patching;
using EFT.InventoryLogic;
using System.Linq;
using System.Reflection;

namespace UseItemsFromAnywhere
{
    public class IsAtBindablePlace : ModulePatch
    {
        protected override MethodBase GetTargetMethod() =>
            typeof(InventoryControllerClass).GetMethod("IsAtBindablePlace", BindingFlags.Public | BindingFlags.Instance);

        [PatchPostfix]
        private static void Postfix(InventoryControllerClass __instance, ref bool __result, ref Item item)
        {
            /*
            const string redFlare = "62178c4d4ecf221597654e3d";
            const string yellowFlare = "624c0b3340357b5f566e8766";
            const string greenFlare = "6217726288ed9f0845317459";
            const string whiteFlare = "62178be9d0050232da3485d9";
            */

            if (item.CurrentAddress != null && !(item.Parent is GClass2664) && item.CurrentAddress.Container.ParentItem is not StashClass)
            {
                Slot parentSlot = item.Parent.Container.ParentItem.CurrentAddress?.Container as Slot;
                LootItemClass lootItemClass = item as LootItemClass;
                if (InventoryClass.FastAccessSlots.Select((EquipmentSlot slotType) => __instance.Inventory.Equipment.GetSlot(slotType)).Any((Slot slot) => slot == parentSlot) && (lootItemClass == null || !lootItemClass.MissingVitalParts.Any()) && __instance.Examined(item))
                {
                    if (!(item is Weapon) && !(item is GrenadeClass) && item.GetItemComponent<KnifeComponent>() == null && !(item is MedsClass) && !(item is FoodClass) && !(item is GClass2632) && !(item is GClass2631))
                    {
                        __result = false;
                    }
                    __result = true;
                }
                __result = false;
            }
            __result = false;
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
        const string redFlare = "62178c4d4ecf221597654e3d";
        const string yellowFlare = "624c0b3340357b5f566e8766";
        const string greenFlare = "6217726288ed9f0845317459";
        const string whiteFlare = "62178be9d0050232da3485d9";

        if (item.CurrentAddress == null)
        {
            __result = false;
        }

        IContainer container = item.Parent.Container;
        if ((__instance.Inventory.Stash == null || container != __instance.Inventory.Stash.Grid) && (!(item is LootItemClass lootItemClass) || !lootItemClass.MissingVitalParts.Any()) && __instance.Inventory.GetItemsInSlots(InventoryClass.BindAvailableSlotsExtended).Contains(item) && __instance.Examined(item))
        {
            if (!(item is Weapon) && !(item is GrenadeClass) && item.GetItemComponent<KnifeComponent>() == null && !(item is MedsClass) && !(item is FoodClass) && !(item is GClass2632) && !(item is GClass2631))
            {
                __result = false;
            }
            __result = true;
        }
        __result = false;
    }
}