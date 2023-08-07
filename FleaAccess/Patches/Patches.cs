using System;
using System.Collections.Generic;
using System.Reflection;
using Aki.Reflection.Patching;
using Comfort.Common;
using EFT;
using EFT.UI;
using EFT.UI.Ragfair;
using EFT.UI.Screens;
using HarmonyLib;
using UnityEngine;


namespace FleaAccess.Patches
{
    public class FleaTraderScreenPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod() =>
            typeof(TradingScreen).GetMethod("method_5", BindingFlags.NonPublic | BindingFlags.Instance);

        [PatchPostfix]
        static void Postfix()
        {
            TradingScreen _menuTaskBarInstance = MonoBehaviourSingleton<MenuUI>.Instance.TradingScreen;
            UIAnimatedToggleSpawner _ragfairToggle = (UIAnimatedToggleSpawner)AccessTools.Field(typeof(TradingScreen), "_ragfairToggle").GetValue(_menuTaskBarInstance);


            _ragfairToggle.SetActive(false);

        }
    }

    public class MenuTaskBarPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod() => 
            typeof(MenuTaskBar).GetMethod("SetButtonsAvailable", BindingFlags.Public | BindingFlags.Instance);

        [PatchPostfix]
        static void PostFix(ref bool available)
        {
            MenuTaskBar _menuTaskBarInstance = MonoBehaviourSingleton<PreloaderUI>.Instance.MenuTaskBar;
            Dictionary<EMenuType, HoverTooltipArea> _hoverToolTipAreas = (Dictionary<EMenuType, HoverTooltipArea>)AccessTools.Field(typeof(MenuTaskBar), "_hoverTooltipAreas").GetValue(_menuTaskBarInstance);

            bool bool_0 = (bool)AccessTools.Field(typeof(MenuTaskBar), "bool_0").GetValue(_menuTaskBarInstance);

            AccessTools.Field(typeof(MenuTaskBar), "bool_1").SetValue(_menuTaskBarInstance, false);

            if (true)
            {
                foreach (KeyValuePair<EMenuType, HoverTooltipArea> keyValuePair in _hoverToolTipAreas)
                {
                    keyValuePair.Deconstruct(out EMenuType emenuType, out HoverTooltipArea hoverTooltipArea);
                    int num = (int)emenuType;

                    if (num == 13)
                    {
                        hoverTooltipArea.SetUnlockStatus(false);
                        hoverTooltipArea.SetMessageText("Requires a flea access card", false);
                    }
                    else if (num != 6 && (num != 10 || bool_0))
                    {
                        hoverTooltipArea.SetUnlockStatus(available);
                        hoverTooltipArea.SetMessageText(available ? string.Empty : "Not available in raid", false);
                    }
                }
            }
            else
            {
                foreach (KeyValuePair<EMenuType, HoverTooltipArea> keyValuePair in _hoverToolTipAreas)
                {
                    keyValuePair.Deconstruct(out EMenuType emenuType, out HoverTooltipArea hoverTooltipArea);
                    int num = (int)emenuType;

                    ; if (num != 6 && (num != 10 || bool_0))
                    {
                        hoverTooltipArea.SetUnlockStatus(available);
                        hoverTooltipArea.SetMessageText(available ? string.Empty : "Not available in raid", false);
                    }
                }
            }
        }
    }

    public class OfferViewPatch : ModulePatch
    {
        public static object call(object o, string methodName, params object[] args)
        {
            try
            {
                var mi = o.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
                if (mi != null)
                {
                    return mi.Invoke(o, args);
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.ToString());
                return null;
            }
        }

        protected override MethodBase GetTargetMethod() =>
            typeof(OfferView).GetMethod("method_0", BindingFlags.Instance | BindingFlags.NonPublic);

        [PatchPrefix]
        static void Prefix(OfferView __instance)
        {
            //Fields
            Offer offer_0 = (Offer)AccessTools.Field(typeof(OfferView), "Offer_0").GetValue(__instance);
            GameObject checkboxPanel = (GameObject)AccessTools.Field(typeof(OfferView), "Offer_0").GetValue(__instance);
            bool boolean_2 = (bool)AccessTools.Field(typeof(OfferView), "Boolean_2").GetValue(__instance);
            GameObject exchangeOffer = (GameObject)AccessTools.Field(typeof(OfferView), "_exchangeOffer").GetValue(__instance);


            call(__instance, "method_5", new object[] { offer_0.Id, true });
            call(__instance, "method_7");
            checkboxPanel.SetActive(boolean_2);
            if (offer_0.NotAvailable)
            {
                exchangeOffer.SetActive(false);
            }
            else
            {
                exchangeOffer.SetActive(!offer_0.OnlyMoney);
            }

            call(__instance, "method_6");
            call(__instance, "method_8");
        }
    }

    public class OnScreenChangedPatch : ModulePatch
    {

        protected override MethodBase GetTargetMethod() => 
            typeof(MenuTaskBar).GetMethod("OnScreenChanged", BindingFlags.Public | BindingFlags.Instance);

        [PatchPostfix]
        static void PostFix(ref EEftScreenType eftScreenType)
        {
            MenuTaskBar _menuTaskBarInstance = MonoBehaviourSingleton<PreloaderUI>.Instance.MenuTaskBar;
            Dictionary<EEftScreenType, EMenuType> _screenType = (Dictionary<EEftScreenType, EMenuType>)AccessTools.Field(typeof(MenuTaskBar), "dictionary_0").GetValue(_menuTaskBarInstance);
            Dictionary<EMenuType, HoverTooltipArea> _hoverToolTipAreas = (Dictionary<EMenuType, HoverTooltipArea>)AccessTools.Field(typeof(MenuTaskBar), "_hoverTooltipAreas").GetValue(_menuTaskBarInstance);
            bool bool_0 = (bool)AccessTools.Field(typeof(MenuTaskBar), "bool_0").GetValue(_menuTaskBarInstance);

            if (_screenType.TryGetValue(eftScreenType, out EMenuType _emenuType) && Singleton<GameWorld>.Instantiated)
            {
                if (_emenuType != EMenuType.Handbook)
                {
                    return;
                }
                foreach (KeyValuePair<EMenuType, HoverTooltipArea> keyValuePair in _hoverToolTipAreas)
                {
                    keyValuePair.Deconstruct(out EMenuType emenuType, out HoverTooltipArea hoverTooltipArea);
                    int num = (int)emenuType;

                    if (num == 13)
                    {
                        hoverTooltipArea.SetUnlockStatus(false);
                        hoverTooltipArea.SetMessageText("Requires a flea access card", false);
                    }
                    else if (num != 6 && (num != 10 || bool_0))
                    {
                        hoverTooltipArea.SetUnlockStatus(false);
                        hoverTooltipArea.SetMessageText("Not available in raid", false);
                    }
                }
            }
        }
    }
}
