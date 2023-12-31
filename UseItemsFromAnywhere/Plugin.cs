﻿using BepInEx;
using BepInEx.Configuration;
using static UseItemsFromAnywhere.UseItemsFromAnywhere;

namespace UseItemsFromAnywhere
{
    [BepInPlugin("com.dirtbikercj.useFromAnywhere", "Use items from any place in your inventory", "1.0.4")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance;

        internal void Awake()
        {
            instance = this;
            DontDestroyOnLoad(this);

            new IsAtBindablePlace().Enable();
            new IsAtReachablePlace().Enable();
        }
    }
}