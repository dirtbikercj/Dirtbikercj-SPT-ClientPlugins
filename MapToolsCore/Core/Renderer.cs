using MapTools.Config;
using System.Collections.Generic;
using UnityEngine;

namespace MapTools.Core
{
    public enum Colors
    {
        Red,
        Green,
        Blue,
        Yellow,
        White,
        Black,
        Cyan,
        Magenta
    }

    public class Render : MonoBehaviour
    {

        List<Vector3> positions = new List<Vector3>();
        List<Vector3> positonsRedo = new List<Vector3>();

        List<GameObject> sphereObjects = new List<GameObject>();
        List<GameObject> sphereObjectsRedo = new List<GameObject>();

        private Color _color = new Color();

        public void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Undo()
        {
            if (positions.Count > 0 || sphereObjects.Count > 0)
            {
                Destroy(sphereObjects[positions.Count - 1]);
                positions.RemoveAt(positions.Count - 1);
                sphereObjects.RemoveAt(sphereObjects.Count - 1);
            }
            DrawLootSpheres();
        }

        public void AddSphereToList(Vector3 position)
        {
            GameObject sphereObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphereObj.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            var sphereRenderer = sphereObj.GetComponent<Renderer>();

            switch (ConfigMapTools.lootColor.Value)
            {
                case Colors.Red:
                    _color = Color.red;
                    break;
                case Colors.Green:
                    _color = Color.green;
                    break;
                case Colors.Blue:
                    _color = Color.blue;
                    break;
                case Colors.Yellow:
                    _color = Color.yellow;
                    break;
                case Colors.White:
                    _color = Color.white;
                    break;
                case Colors.Black:
                    _color = Color.black;
                    break;
                case Colors.Cyan:
                    _color = Color.cyan;
                    break;
                case Colors.Magenta:
                    _color = Color.magenta;
                    break;
                default:
                    _color = Color.red;
                    break;
            }
            sphereRenderer.material.color = _color;

            positions.Add(position);
            sphereObjects.Add(sphereObj);
        }

        public void DrawLootSpheres()
        {
            if (positions.Count > 0)
            {
                for (int i = 0; i < positions.Count; i++)
                {
                    sphereObjects[i].transform.position = positions[i];
                }
            }
        }
    }
}
