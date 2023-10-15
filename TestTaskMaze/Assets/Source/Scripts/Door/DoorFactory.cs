using Assets.Source.Script;
using Assets.Source.Scripts.Factories;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public class DoorFactory : GameObjectFactory<Door>
    {
        public DoorFactory(Door prefab)
        {
            objectToCreate = prefab;
            parent = new GameObject("DoorsContent").transform;
        }

        public override Door Get()
        {
            return base.Get();
        }
    }
}
