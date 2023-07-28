using BepInEx;
using MapTools.Core;
using Comfort.Common;
using EFT;
using UnityEngine;
using MapTools.Config;



namespace MapTools
{
    [BepInPlugin("com.dirtbikercj.maptools", "Map Tools", "1.0.0")]
    public class MapTools : BaseUnityPlugin
    {
        public static MapTools instance;
        public static Render renderer;
        public WorldLoot worldLoot;
        public GameWorld gameWorldInstance;

        public BaseJsonBuilder baseJsonBuilder = new BaseJsonBuilder();
        public LooseLootJsonBuilder looseLootJsonBuilder = new LooseLootJsonBuilder();

        private const string MainConfig = "Main Settings";

        internal void Awake()
        {
            instance = this;
            DontDestroyOnLoad(this);

            #region MainSettings
            ConfigMapTools.logAllLoot = Config.Bind(
               MainConfig,
                "Log all spawned loot to console",
                KeyCode.KeypadMinus,
                "Key bind to list all loot");

            ConfigMapTools.setSpawnPoint = Config.Bind(
               MainConfig,
                "Select World Position",
                KeyCode.Mouse1,
                "Key bind to select the world position");

            ConfigMapTools.dumpWorldLootJson = Config.Bind(
               MainConfig,
                "Export looseloot.json",
                KeyCode.KeypadPlus,
                "Dumps all created loot positions to json");

            ConfigMapTools.dumpBaseJson = Config.Bind(
                MainConfig,
                "Export base.json",
                KeyCode.KeypadEnter,
                "Dumps all created loot positions to json");

            ConfigMapTools.undo = Config.Bind(
               MainConfig,
                "Undo Last Action",
                KeyCode.Keypad0,
                "Undoes last action");
            
            ConfigMapTools.enableLootSpheres = Config.Bind(
               MainConfig,
                "Draw Spheres on loot positions",
                true,
                "Draws Spheres on placed loot positons using the editor");

            ConfigMapTools.enableSpawnSpheres = Config.Bind(
                MainConfig,
                "Draw Spheres on loot positions",
                true,
                "Draws Spheres on placed loot positons using the editor");

            ConfigMapTools.lootColor = Config.Bind(
               MainConfig,
                "Set lootsphere color",
                Colors.Red,
                "Undoes last action");

            #endregion


            

        }

        internal void Start()
        {
            renderer = new Render();
            worldLoot = new WorldLoot();

            baseJsonBuilder.InitBaseJson();
            looseLootJsonBuilder.InitLooseLootJson();
        }

        internal void Update()
        {
            if (Singleton<GameWorld>.Instantiated)
            {
                gameWorldInstance = Singleton<GameWorld>.Instance;

                // Log all loot to console
                if (Input.GetKeyDown(ConfigMapTools.logAllLoot.Value))
                {
                    worldLoot.ListAllLoot(gameWorldInstance);
                }

                // 
                if (Input.GetKeyDown(ConfigMapTools.setSpawnPoint.Value))
                {
                    worldLoot.GetWorldPoint(looseLootJsonBuilder);
                }

                // Export Looseloot.json
                if (Input.GetKeyDown(ConfigMapTools.dumpWorldLootJson.Value))
                {
                    looseLootJsonBuilder.ExportLooseLootJson();
                }

                //Undo last action on looseloot.json
                if (Input.GetKeyDown(ConfigMapTools.undo.Value))
                { 
                    renderer.Undo();
                    looseLootJsonBuilder.Undo();
                }

                // Export Base.json
                if (Input.GetKeyDown(ConfigMapTools.dumpBaseJson.Value))
                {
                    baseJsonBuilder.ExportBaseJson();
                }
            }

            // Export Looseloot.json
            if (Input.GetKeyDown(ConfigMapTools.dumpWorldLootJson.Value))
            {
                looseLootJsonBuilder.ExportLooseLootJson();
            }

            // Export Base.json
            if (Input.GetKeyDown(ConfigMapTools.dumpBaseJson.Value))
            {
                baseJsonBuilder.ExportBaseJson();
            }
        }
    }
}
