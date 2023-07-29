using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using MapTools.Config;
using MapTools.Data.Loot;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace MapTools.Core
{
    public class LooseLootJsonBuilder
    {
        private static LooseLootJson _looseLootJson = new LooseLootJson();

        private string _looseLootJsonExport;
        public void InitLooseLootJson()
        {
            SpawnpointCount spawnpointCount = new SpawnpointCount();

            spawnpointCount.mean = ConfigLooseLootJson.mean.Value;
            spawnpointCount.std = ConfigLooseLootJson.std.Value;

            _looseLootJson.spawnpointCount = spawnpointCount;
            _looseLootJson.spawnpointsForced = new List<SpawnpointsForced>();
            _looseLootJson.spawnpoints = new List<LooseLootSpawnpoint>();

            BuildBaseJson();
        }



        // first tpl is the actual ammobox id as found in items.json
        // Second tpl is the ammo in the box
        // Count in this context is the amount of ammo in the box

        public void AddLooseLootPoint(Vector3 hitpoint)
        {
            Random rand = new Random();
            LooseLootSpawnpoint spawnpoint = new LooseLootSpawnpoint();
            Position position = new Position();
            Rotation rotation = new Rotation();
            Upd upd = new Upd();
            Item item = new Item();
            Template template = new Template();
            
            position.x = hitpoint.x;
            position.y = hitpoint.y;
            position.z = hitpoint.z;

            rotation.x = 0;
            rotation.y = 0;
            rotation.z = 0;

            upd.StackObjectsCount = 50;                                      // Only applies to ammo

            item._id = rand.Next(-1000000000, 1000000000).ToString();        // Random ID
            item._tpl = CreateIdString(24);                            // Item ID or ContainerID
            item.parentId = rand.Next(-1000000000, 1000000000).ToString();
            item.slotId = ConfigLooseLootJson.slotId.Value;                 //Always cartridges when ammo box spawn
            item.upd = upd;
            item.location = ConfigLooseLootJson.location.Value;

            template.Id = CreateTemplateIdString();
            template.IsStatic = ConfigLooseLootJson.isStatic.Value;
            template.useGravity = ConfigLooseLootJson.useGravity.Value;
            template.randomRotation = ConfigLooseLootJson.randomRotation.Value;
            template.Position = position;
            template.Rotation = rotation;
            template.IsGroupPosition = ConfigLooseLootJson.isGroupPosition.Value;
            template.GroupPositions = new List<object>();
            template.IsAlwaysSpawn = ConfigLooseLootJson.isAlwaysSpawn.Value;
            template.Root = CreateIdString(24).ToLower(); //Fix me
            template.Items.Add(item);

            spawnpoint.locationId = $"{hitpoint.ToString()}";
            spawnpoint.probability = ConfigLooseLootJson.probability.Value;
            spawnpoint.template = template;


            _looseLootJson.spawnpoints.Add(spawnpoint);
            BuildBaseJson();
            ExportLooseLootJson();
        }

        public void Undo()
        {
            if (_looseLootJson.spawnpoints.Count > 0)
            {
                _looseLootJson.spawnpoints.RemoveAt(_looseLootJson.spawnpoints.Count - 1);
                BuildBaseJson();
                ExportLooseLootJson();
            }
        }

        private static string CreateIdString(int count)
        {
            Random _random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, count)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        private static string CreateTemplateIdString()
        {
            var random = new System.Random();
            string lootId = ConfigLooseLootJson.id.Value + " ";
            int randNum = random.Next(1000000);
            string key = randNum.ToString("D7").ToLower();
            lootId += key;
            return lootId;
        }

        private void BuildBaseJson()
        {
            _looseLootJsonExport = JsonConvert.SerializeObject(_looseLootJson, Formatting.Indented);
        }

        public void ExportLooseLootJson()
        {
            using (StreamWriter file = File.CreateText(AppDomain.CurrentDomain.BaseDirectory + @"\looseloot.json"))
            using (JsonWriter writer = new JsonTextWriter(file))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteRaw(_looseLootJsonExport);
                writer.Close();
            }
        }
    }
}
