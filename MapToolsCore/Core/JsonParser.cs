using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFT.UI;
using MapTools.Data.Loot;
using Newtonsoft.Json.Linq;
using static MapTools.Data.Loot.ItemsJsonData;

namespace MapTools.Core
{
    public class JsonParser
    {
        Dictionary<string, Root> _itemData = new Dictionary<string, Root>();

        public void LoadItemJsonFromDisk()
        {
            try
            {
                string _itemJsonString = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Aki_Data\Server\database\templates\items.json");
                _itemData = JsonConvert.DeserializeObject<Dictionary<string, Root>> (_itemJsonString);

                ConsoleScreen.Log($"Items Loaded from disk: {_itemData.Count}");
            }
            catch (Exception e)
            {
                ConsoleScreen.LogException(e);
            }
        }

        public void SearchForItem(string searchId)
        {
            foreach (var item in _itemData.Values)
            {
                if (item._id == searchId)
                {
                    ConsoleScreen.Log(item._name);
                }
            }
        }
    }
}
