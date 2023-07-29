using System;
using EFT.UI;
using EFT.Console.Core;
using JetBrains.Annotations;

namespace MapTools.Helpers
{
    public class CommandProcessor
    {
        public void RegisterCommandProcessor()
        {
            // Clear console
            ConsoleScreen.Processor.RegisterCommand("clear",
                delegate() { MonoBehaviourSingleton<PreloaderUI>.Instance.Console.Clear(); });

            // Lists all loot in the gameworld
            ConsoleScreen.Processor.RegisterCommand("ListAllLoot",
                delegate() { MapTools.instance.worldLoot.ListAllLoot(MapTools.instance.gameWorldInstance); });

            ConsoleScreen.Processor.RegisterCommand("LoadItemJson",
                delegate () { MapTools.instance.jsonParser.LoadItemJsonFromDisk(); });
        }
    }

    public class Commands
    {
        [ConsoleCommand("SearchItem", "", null, "", new string[] { })]
        public static void SearchItem([ConsoleArgument("", "Search for an item by ID")] string item)
        {
            if (item != "")
            {
                try
                {
                    MapTools.instance.jsonParser.SearchForItem(item);
                }
                catch (Exception e)
                {
                    ConsoleScreen.LogException(e);
                }
            }
        }
    }
}