using System;

namespace Assets.Source.Scripts
{
    [Serializable]
    public struct WallConfig
    {
        public bool up;
        public bool bot;
        public bool left;
        public bool right;

        public WallConfig(bool up, bool bot, bool left, bool right)
        {
            this.up = up;
            this.bot = bot;
            this.left = left;
            this.right = right;
        }
    }
}
