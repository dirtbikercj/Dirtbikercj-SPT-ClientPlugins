using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

        string nextParent = string.Empty;
        int parentCount = 0;
        private bool refire = false;
        public void SearchForItem(string searchId = "", bool searchParents = true)
        {

            foreach (var item in _itemData.Values)
            {
                if (item._id == searchId && refire == false)
                {
                    ConsoleScreen.Log("----------Searched Object------------");
                    ConsoleScreen.Log($"Item name: {item._name}");
                    ConsoleScreen.Log($"ParentID:  {item?._parent}");
                    ConsoleScreen.Log("-------------------------------------");
                    nextParent = item._parent;
                }

                if (nextParent != string.Empty)
                {
                    foreach (var parent in _itemData.Values)
                    {
                        if (parent._id == nextParent)
                        {
                            parentCount++;
                            ConsoleScreen.Log($"---Parent: {parentCount} ------------------");
                            ConsoleScreen.Log($"Item name: {parent._name}");
                            ConsoleScreen.Log($"ParentID:  {parent?._parent}");
                            ConsoleScreen.Log("-------------------------------");
                            nextParent = parent._parent;
                            if (nextParent == "")
                            {
                                refire = false;
                                parentCount = 0;
                            }
                            else
                            {
                                refire = true;
                                SearchForItem();
                            }
                        }
                    }
                }
            }
        }
    }
}
