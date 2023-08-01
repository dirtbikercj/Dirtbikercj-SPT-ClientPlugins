using BepInEx;

namespace SPC
{
    [BepInPlugin("com.SPC.SPC_CORE", "SPC Core Module", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance;

        internal void Awake()
        {
            instance = this;
            DontDestroyOnLoad(this);

        }
    }
}