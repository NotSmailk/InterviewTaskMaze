using Assets.Source.Scripts.Factories;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public class PlayerFactory : GameObjectFactory<Player>
    {
        public PlayerFactory(Player prefab)
        {
            objectToCreate = prefab;
            parent = new GameObject("PlayerContent").transform;
        }

        public override Player Get()
        {
            return base.Get();
        }
    }
}
