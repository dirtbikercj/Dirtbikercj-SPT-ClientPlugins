using HarmonyLib;
using EFT;
using EFT.UI;
using Comfort.Common;
using System.Collections.Generic;
using UnityEngine;
using MapTools.Helpers;
using MapTools.Core.Base;

namespace MapTools.Core
{

    public class WorldLoot
    {
        private readonly Render _renderer = MapTools.instance.renderer;
        public void ListAllLoot(GameWorld gameWorldInstance)
        {
            List<LootItemPositionClass> allLoot = AccessTools.Field(typeof(GameWorld), "AllLoot").GetValue(gameWorldInstance) as List<LootItemPositionClass>;
            int lootcount = 0;

            foreach (var result in allLoot)
            {
                ConsoleScreen.Log("-------------------------------------------------------------------------------");
                ConsoleScreen.Log($"Item        : {result.Item.ToString()}");
                ConsoleScreen.Log($"ID          : {result.Id.ToString()}");
                ConsoleScreen.Log($"Position    : {result.Position.ToString()}");
                ConsoleScreen.Log($"Rotation    : {result.Rotation.ToString()}");
                ConsoleScreen.Log($"IsStatic    : {result.IsStatic.ToString()}");
                ConsoleScreen.Log($"useGravity  : {result.useGravity.ToString()}");
                ConsoleScreen.Log($"Shift(Vec3) : {result.Shift.ToString()}");
                ConsoleScreen.Log($"RandRotation: {result.randomRotation.ToString()}");
                ConsoleScreen.Log("-------------------------------------------------------------------------------");
                lootcount++;
            }
            ConsoleScreen.Log($"Loot items found: {lootcount}");
        }

        public void GetWorldPoint(LooseLootJsonBuilder jsonDump, Render draw)
        {
            if (Singleton<GameWorld>.Instantiated)
            {
                Vector3 mousePos = Input.mousePosition;
                RaycastHit hit;
                Ray worldPos = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

                if (!Physics.Raycast(worldPos, out hit))
                {
                    return;
                }

                if (hit.point != null)
                {
                    ConsoleScreen.Log($"LootDebug: World Position: {hit.point} \n");
                    AddLootEntry(hit.point, jsonDump);
                    _renderer.AddSphereToList(hit.point);

                    if (MapToolsConfig.enableLootSpheres.Value == true)
                    {
                        _renderer.DrawLootSpheres();
                    }
                }
                else
                {
                    ConsoleScreen.LogError("LootDebug: No Suitable Collider found. \n");
                }
            }
        }

        private string CreateIdHash()
        {
            var random = new System.Random();
            string lootId = MapToolsConfig.id.Value + " ";
            int randNum = random.Next(1000000);
            string key = randNum.ToString("D7");
            lootId += key;
            return lootId;
        }

        private void AddLootEntry(Vector3 point, LooseLootJsonBuilder jsonDump)
        {
            WorldLootJson.locationId = $"({point.x}, {point.y}, {point.z})";
            WorldLootJson.probability = MapToolsConfig.probability.Value;
            WorldLootJson.Id = CreateIdHash();
            WorldLootJson.isStatic = MapToolsConfig.isStatic.Value;
            WorldLootJson.useGravity = MapToolsConfig.useGravity.Value;
            WorldLootJson.randomRotation = MapToolsConfig.randomRotation.Value;
            WorldLootJson.posX = point.x;
            WorldLootJson.posY = point.y;
            WorldLootJson.posZ = point.z;
            WorldLootJson.rotX = 0;
            WorldLootJson.rotY = 0;
            WorldLootJson.rotZ = 0;
            WorldLootJson.isAlwaysSpawn = MapToolsConfig.isAlwaysSpawn.Value;
            WorldLootJson.isGroupPosition = MapToolsConfig.isGroupPosition.Value;

        }
    }
}
