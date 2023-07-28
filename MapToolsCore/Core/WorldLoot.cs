using HarmonyLib;
using EFT;
using EFT.UI;
using Comfort.Common;
using System.Collections.Generic;
using UnityEngine;
using MapTools.Config;
using MapTools.Core.Base;

namespace MapTools.Core
{

    public class WorldLoot
    {
        private readonly Render _renderer = MapTools.renderer;
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

        public void GetWorldPoint(LooseLootJsonBuilder jsonDump)
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
                    MapTools.instance.looseLootJsonBuilder.AddLooseLootPoint(hit.point);
                    _renderer.AddSphereToList(hit.point);

                    if (ConfigMapTools.enableLootSpheres.Value == true)
                    {
                        _renderer.DrawLootSpheres();
                    }
                }
            }
        }
    }
}
