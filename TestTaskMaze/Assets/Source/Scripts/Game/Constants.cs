using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public class Constants
    {
        public static readonly Dictionary<ColorType, Color> Colors = new Dictionary<ColorType, Color>
        {
            { ColorType.Yellow, Color.yellow },
            { ColorType.Blue, Color.blue },
            { ColorType.Green, Color.green },
            { ColorType.Default, Color.gray }
        };

        public static readonly Dictionary<ConnectionType, Vector2> Offest = new Dictionary<ConnectionType, Vector2>
        {
            { ConnectionType.Vertical, Vector2.right },
            { ConnectionType.Horizontal, Vector2.up }
        };

        public static readonly Dictionary<ConnectionType, Vector3> Rotations = new Dictionary<ConnectionType, Vector3>
        {
            { ConnectionType.Vertical, Vector3.zero },
            { ConnectionType.Horizontal, Vector3.forward * 90f }
        };

        public static class KeyWords
        {
            public static readonly string WIN_RESULT = "You escaped the maze";
            public static readonly string LOSE_RESULT = "You are lost in the maze";
            public static readonly string RETRY = "Retry";
            public static readonly string INTERACTABLE_MSG = $"Press {InputInfo.InteractKey} to interact";
        }

        public static class InputInfo
        {
            public static readonly KeyCode InteractKey = KeyCode.E;
            public static readonly string VERTICAL = "Vertical";
            public static readonly string HORIZONTAL = "Horizontal";
        }
    }
}
