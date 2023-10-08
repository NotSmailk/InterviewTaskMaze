using Assets.Source.Scripts.Factories;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public class WallFactory : GameObjectFactory<Wall>
    {
        private WallData _data;

        public WallFactory(Wall prefab, Transform parent, WallData data)
        {
            this.parent = parent;
            objectToCreate = prefab;
            _data = data;
        }

        public override Wall Get()
        {
            return base.Get().Init(_data.RandomWall);
        }
    }
}
