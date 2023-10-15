using System;

namespace Assets.Source.Scripts
{
    [Serializable]
    public struct ColorVector
    {
        public static ColorVector None => new ColorVector(false, false, false);
        public static ColorVector All => new ColorVector(true, true, true);

        public bool yellow;
        public bool blue;
        public bool green;

        public ColorVector(bool y, bool b, bool g)
        {
            yellow = y;
            blue = b;
            green = g;
        }
    }
}
