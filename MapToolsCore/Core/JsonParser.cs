using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using EFT.UI;
using MapTools.Data.Loot;

namespace MapTools.Core
{
    public class JsonParser
    {
        Dictionary<string, ItemsJsonData.Root> _itemData = new Dictionary<string, ItemsJsonData.Root>();

        public void LoadItemJsonFromDisk()
        {
            try
            {
                string _itemJsonString = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Aki_Data\Server\database\templates\items.json");
                _itemData = JsonConvert.DeserializeObject<Dictionary<string, ItemsJsonData.Root>> (_itemJsonString);

                ConsoleScreen.Log($"Items Loaded from disk: {_itemData.Count}");
            }
            catch (Exception e)
            {
                ConsoleScreen.LogException(e);
            }
        }

        private string _nextParent = string.Empty;
        private int _parentCount = 0;
        private bool _refire = false;
        public void SearchForItem(string searchId = "")
        {

            foreach (var item in _itemData.Values)
            {
                if (item._id == searchId && _refire == false)
                {
                    ConsoleScreen.Log("----------Searched Object------------");
                    ConsoleScreen.Log($"Item name: {item._name}");
                    ConsoleScreen.Log($"ParentID:  {item?._parent}");
                    ConsoleScreen.Log("-------------------------------------");
                    _nextParent = item._parent;
                }

                if (_nextParent != string.Empty)
                {
                    foreach (var parent in _itemData.Values)
                    {
                        if (parent._id == _nextParent)
                        {
                            _parentCount++;
                            ConsoleScreen.Log($"---Parent: {_parentCount} ------------------");
                            ConsoleScreen.Log($"Item name: {parent._name}");
                            ConsoleScreen.Log($"ParentID:  {parent?._parent}");
                            ConsoleScreen.Log("-------------------------------");
                            _nextParent = parent._parent;
                            if (_nextParent == "")
                            {
                                _refire = false;
                                _parentCount = 0;
                            }
                            else
                            {
                                _refire = true;
                                SearchForItem();
                            }
                        }
                    }
                }
            }
        }
    }
}
