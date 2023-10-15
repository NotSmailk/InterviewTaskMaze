using Assets.Source.Scripts.Factories;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public class WallFactory : GameObjectFactory<Wall>
    {
        private WallData _data;

        public WallFactory(Wall prefab, WallData data)
        {
            objectToCreate = prefab;
            _data = data;
            parent = new GameObject("WallsContent").transform;
        }

        public override Wall Get()
        {
            return base.Get().Init(_data.RandomWall);
        }
    }
}
