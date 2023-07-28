using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using MapTools.Data.Loot;

namespace MapTools.Core
{
    public class LooseLootJsonBuilder
    {
        private LooseLootJson _looseLootJson = new LooseLootJson();
        private string _looseLootJsonExport;
        public void InitLooseLootJson()
        {
            _looseLootJson.spawnpointCount = new SpawnpointCount();
            _looseLootJson.spawnpointsForced = new List<SpawnpointsForced>();
            _looseLootJson.spawnpoints = new List<Spawnpoint>();

            BuildBaseJson();
        }

        public void BuildBaseJson()
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
