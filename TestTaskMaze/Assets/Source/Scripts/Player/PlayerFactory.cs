using Assets.Source.Scripts.Factories;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public class PlayerFactory : GameObjectFactory<Player>
    {
        public PlayerFactory(Player prefab, Transform parent)
        {
            objectToCreate = prefab;
            this.parent = parent;
        }

        public override Player Get()
        {
            return base.Get();
        }
    }
}
