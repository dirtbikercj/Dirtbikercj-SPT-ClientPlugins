using System;
using BepInEx;
using Comfort.Common;
using EFT.UI;
using UnityEngine;

namespace SPC
{
    [BepInPlugin("com.dirtbikercj.TraderApi", "Trader API", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance;
        private GameObject _merchants;


        internal void Awake()
        {
            instance = this;
            DontDestroyOnLoad(this);

            _merchants = GameObject.Find("");
        }

        internal void Update()
        {
            if (Singleton<MenuUI>.Instantiated)
            {
                try
                {
                    Singleton<PreloaderUI>.Instance.
                }
                catch (Exception e)
                {
                    
                }
            }
        }
    }
}