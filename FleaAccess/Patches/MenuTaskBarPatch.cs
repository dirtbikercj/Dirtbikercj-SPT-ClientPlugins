using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Aki.Reflection.Patching;
using Comfort.Common;
using EFT;
using EFT.UI;
using EFT.UI.Screens;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UIElements;
using static RagFairClass;

namespace FleaAccess.Patches
{
    public class MenuTaskBarPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod() => typeof(MenuTaskBar).GetMethod("SetButtonsAvailable", BindingFlags.Public | BindingFlags.Instance);

        [PatchPostfix]
        static void PostFix(ref bool available)
        {
            MenuTaskBar _menuTaskBarInstance = MonoBehaviourSingleton<PreloaderUI>.Instance.MenuTaskBar;
            Dictionary<EMenuType, HoverTooltipArea> _hoverToolTipAreas = AccessTools.Field(typeof(MenuTaskBar), "_hoverTooltipAreas").GetValue(_menuTaskBarInstance) as Dictionary<EMenuType, HoverTooltipArea>;

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

    public class OnScreenChangedPatch : ModulePatch
    {

        protected override MethodBase GetTargetMethod() => typeof(MenuTaskBar).GetMethod("OnScreenChanged", BindingFlags.Public | BindingFlags.Instance);

        [PatchPostfix]
        static void PostFix(ref EEftScreenType eftScreenType)
        {
            MenuTaskBar _menuTaskBarInstance = MonoBehaviourSingleton<PreloaderUI>.Instance.MenuTaskBar;
            Dictionary<EEftScreenType, EMenuType> _screenType = AccessTools.Field(typeof(MenuTaskBar), "dictionary_0").GetValue(_menuTaskBarInstance) as Dictionary<EEftScreenType, EMenuType>;
            Dictionary<EMenuType, HoverTooltipArea> _hoverToolTipAreas = AccessTools.Field(typeof(MenuTaskBar), "_hoverTooltipAreas").GetValue(_menuTaskBarInstance) as Dictionary<EMenuType, HoverTooltipArea>;
            bool bool_0 = (bool)AccessTools.Field(typeof(MenuTaskBar), "bool_0").GetValue(_menuTaskBarInstance);

            if (_screenType.TryGetValue(eftScreenType, out EMenuType _emenuType) && Singleton<GameWorld>.Instantiated)
            {
                if (_emenuType == EMenuType.Handbook)
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
                            hoverTooltipArea.SetUnlockStatus(false);
                            hoverTooltipArea.SetMessageText("Not available in raid", false);
                        }
                    }
                }
            }
        }
    }
    public class FleaTraderScreenPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod() => typeof(TradingScreen).GetMethod("method_5", BindingFlags.NonPublic | BindingFlags.Instance);

        [PatchPostfix]
        static void Postfix()
        {
            TradingScreen? _menuTaskBarInstance = MonoBehaviourSingleton<MenuUI>.Instance.TradingScreen;
            UIAnimatedToggleSpawner? _ragfairToggle = AccessTools.Field(typeof(TradingScreen), "_ragfairToggle").GetValue(_menuTaskBarInstance) as UIAnimatedToggleSpawner;


            _ragfairToggle.SetActive(false);
            
        }
    }

    public class GlobalsPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod() => typeof(RagFairClass).GetMethod("method_1", BindingFlags.Instance | BindingFlags.NonPublic);

        [PatchPrefix]
        static void Prefix()
        {
            if (!MonoBehaviourSingleton<PreloaderUI>.Instantiated)
                return;

           
        }
    }
}
