using Assets.Source.Scripts.Factories;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public class KeyFactory : GameObjectFactory<Key>
    {
        public KeyFactory(Key prefab, Transform parent)
        {
            this.parent = parent;
            objectToCreate = prefab;
        }

        public override Key Get()
        {
            return base.Get();
        }
    }
}
