using Assets.Source.Scripts.Factories;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public class KeyFactory : GameObjectFactory<Key>
    {
        public KeyFactory(Key prefab)
        {
            objectToCreate = prefab;
            parent = new GameObject("KeysContent").transform;
        }

        public override Key Get()
        {
            return base.Get();
        }
    }
}
