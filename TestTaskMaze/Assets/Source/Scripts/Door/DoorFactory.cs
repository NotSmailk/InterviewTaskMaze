using Assets.Source.Script;
using Assets.Source.Scripts.Factories;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public class DoorFactory : GameObjectFactory<Door>
    {
        public DoorFactory(Door prefab, Transform parent)
        {
            this.parent = parent;
            objectToCreate = prefab;
        }

        public override Door Get()
        {
            return base.Get();
        }
    }
}
