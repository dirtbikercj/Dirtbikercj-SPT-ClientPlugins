using BepInEx;

namespace UseItemsFromAnywhere
{
    [BepInPlugin("com.dirtbikercj.useFromAnywhere", "Use items from any place in your inventory", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance;

        internal void Awake()
        {
            instance = this;
            DontDestroyOnLoad(this);

            new UseItemsFromAnywhere.IsAtBindablePlace().Enable();
            new UseItemsFromAnywhere.IsAtReachablePlace().Enable();
        }
    }
}