using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using EFT.UI;
using MapTools.Data;

namespace MapTools.Core
{
    public class JsonParser
    {
        public Dictionary<string, ItemsJsonData.Root> _itemData = new Dictionary<string, ItemsJsonData.Root>();
        public Dictionary<string, string> _localeData = new Dictionary<string, string>();

        public void LoadItemJsonFromDisk()
        {
            try
            { 
                string itemJsonString = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory +
                                                       @"\Aki_Data\Server\database\templates\items.json");
                string localejsonString = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory +
                                                               @"\Aki_Data\Server\database\locales\global\en.json");
                _itemData = JsonConvert.DeserializeObject<Dictionary<string, ItemsJsonData.Root>>(itemJsonString);
                _localeData = JsonConvert.DeserializeObject<Dictionary<string, string>>(localejsonString);
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
                    _localeData.TryGetValue(searchId + " Name", out string name);
                    ConsoleScreen.Log("----------Searched Object------------");
                    ConsoleScreen.Log($"Item name: {name}");
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
                            ConsoleScreen.Log($"----------Parent: {_parentCount} ------------------");
                            ConsoleScreen.Log($"Item name: {parent._name}");
                            ConsoleScreen.Log($"ParentID:  {parent?._parent}");
                            ConsoleScreen.Log("--------------------------------------");
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
