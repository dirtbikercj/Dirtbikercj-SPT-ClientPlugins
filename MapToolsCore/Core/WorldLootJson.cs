using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTools.Core.Base
{ 
    public static class WorldLootJson
    {
        //Generic
        public static string locationId { get; set; }
        public static float probability { get; set; }
        public static string Id { get; set; }
        public static bool isStatic { get; set; }
        public static bool useGravity { get; set; }
        public static bool randomRotation { get; set; }

        //Position
        public static float posX { get; set; }
        public static float posY { get; set; }
        public static float posZ { get; set; }

        //Rotation
        public static float rotX { get; set; }
        public static float rotY { get; set; }
        public static float rotZ { get; set; }

        //Spawn Params
        public static bool isGroupPosition { get; set; }
        public static bool isAlwaysSpawn { get; set; }

    }
}
