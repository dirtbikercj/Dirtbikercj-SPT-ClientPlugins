using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using EFT.UI;
using System.IO;
using MapTools.Core.Base;
using MapTools.Data.Loot;
using MapTools.Data.Base;

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
        }

        public void Build_baseJson()
        {
            _looseLootJsonExport = JsonConvert.SerializeObject(_looseLootJson, Formatting.Indented);
        }

        public void ExportJson()
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
