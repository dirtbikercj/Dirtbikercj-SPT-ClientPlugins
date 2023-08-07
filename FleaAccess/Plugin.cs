using BepInEx;
using Comfort.Common;
using EFT.UI;
using FleaAccess.Patches;
using HarmonyLib;
using Sirenix.Serialization;
using static FleaAccess.Patches.OnScreenChangedPatch;
using static RagFairClass;

namespace SPC
{
    [BepInPlugin("com.dirtbikercj.fleaAccess", "FleaAccessPanel", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance;

        internal void Awake()
        {
            instance = this;
            DontDestroyOnLoad(this);

            new MenuTaskBarPatch().Enable();
            new OnScreenChangedPatch().Enable();
            new FleaTraderScreenPatch().Enable();
            new OfferViewPatch().Enable();
        }

        internal void Update()
        {
          
        }
    }
}