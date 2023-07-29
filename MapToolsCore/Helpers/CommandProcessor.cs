using System;
using EFT.UI;
using EFT.Console.Core;

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
        }
    }

    public class Commands
    {
        [ConsoleCommand("SearchItem", "", null, "", new string[] { })]
        public static void SearchItem([ConsoleArgument("", "Search for an item by ID")] string[] item)
        {
            if (item[0] != "")
            {
                try
                {
                    MapTools.instance.jsonParser.SearchForItem(item[0]);
                }
                catch (Exception e)
                {
                    ConsoleScreen.LogException(e);
                }
            }
            else if (item[1] == "true")
            {
                try
                {
                    MapTools.instance.jsonParser.SearchForItem(item[0]);
                }
                catch (Exception e)
                {
                    ConsoleScreen.LogException(e);
                }
            }
        }
    }
}