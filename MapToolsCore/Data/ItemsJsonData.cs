using System.Collections.Generic;
using EFT;
using EFT.InventoryLogic;
using JetBrains.Annotations;
using JsonType;

namespace MapTools.Data;

public class ItemsJsonData
{
    public class Root
    {
        public string _id { get; set; }
        public bool? _mergeSlotWithChildren { get; set; }

        // Name of Item
        public string _name { get; set; }

        // Parent ID of item
        public string _parent { get; set; }

        // Type of container, by ID
        public string _proto { get; set; }

        public bool? _required { get; set; }
    }
}