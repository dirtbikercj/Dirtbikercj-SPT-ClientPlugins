using System.Collections.Generic;

namespace MapTools.Data.Loot
{
    public class LooseLootJson
    {
        public SpawnpointCount spawnpointCount { get; set; }
        public List<SpawnpointsForced> spawnpointsForced { get; set; }
        public List<LooseLootSpawnpoint> spawnpoints = new List<LooseLootSpawnpoint>();
    }

    public class ComposedKey
    {
        public string key { get; set; }
    }

    public class Item
    {
        public string _id { get; set; }
        public string _tpl { get; set; }
        public string parentId { get; set; }
        public string slotId { get; set; }
        public Upd upd { get; set; }
        public int? location { get; set; }
    }

    public class ItemDistribution
    {
        public ComposedKey composedKey { get; set; }
        public int relativeProbability { get; set; }
    }

    public class Position
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
    }

    public class Rotation
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
    }

    public class LooseLootSpawnpoint
    {
        public string locationId { get; set; }
        public double probability { get; set; }
        public Template template { get; set; }
        public List<ItemDistribution> itemDistribution { get; set; }
    }

    public class SpawnpointCount
    {
        public double mean { get; set; }
        public double std { get; set; }
    }

    public class SpawnpointsForced
    {
        public string locationId { get; set; }
        public int probability { get; set; }
        public Template template { get; set; }
    }

    public class Template
    {
        public string Id { get; set; }
        public bool IsStatic { get; set; }
        public bool useGravity { get; set; }
        public bool randomRotation { get; set; }
        public Position Position { get; set; }
        public Rotation Rotation { get; set; }
        public bool IsGroupPosition { get; set; }
        public List<object> GroupPositions { get; set; }
        public bool IsAlwaysSpawn { get; set; }
        public string Root { get; set; }
        public List<Item> Items = new List<Item>();
    }

    public class Upd
    {
        public int StackObjectsCount { get; set; }
    }


}
