using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public class Constants
    {
        public static Dictionary<ColorType, Color> Colors = new Dictionary<ColorType, Color>
        {
            { ColorType.Yellow, Color.yellow },
            { ColorType.Blue, Color.blue },
            { ColorType.Green, Color.green },
            { ColorType.Default, Color.gray }
        };

        public static Dictionary<ConnectionType, Vector2> Offest = new Dictionary<ConnectionType, Vector2>
        {
            { ConnectionType.Vertical, Vector2.right },
            { ConnectionType.Horizontal, Vector2.up }
        };

        public static Dictionary<ConnectionType, Vector3> Rotations = new Dictionary<ConnectionType, Vector3>
        {
            { ConnectionType.Vertical, Vector3.zero },
            { ConnectionType.Horizontal, Vector3.forward * 90f }
        };
    }
}
