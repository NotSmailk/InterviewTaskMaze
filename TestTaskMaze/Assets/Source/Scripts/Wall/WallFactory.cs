using Assets.Source.Scripts.Factories;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public class WallFactory : GameObjectFactory<Wall>
    {
        private WallData _data;

        public WallFactory(WallData data)
        {
            objectToCreate = data.WallPrefab;
            _data = data;
            parent = new GameObject("WallsContent").transform;
        }

        public override Wall Get()
        {
            return base.Get().Init(_data.RandomWall);
        }
    }
}
