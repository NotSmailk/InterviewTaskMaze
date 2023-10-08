using UnityEngine;

namespace Assets.Source.Scripts.Factories
{
    public abstract class GameObjectFactory<TMonoBehaviour> : BaseFactory<TMonoBehaviour> where TMonoBehaviour : MonoBehaviour
    {
        protected Transform parent;

        public override TMonoBehaviour Get()
        {
            var obj = Object.Instantiate(objectToCreate, parent);
            objects.Add(obj);
            return obj;
        }

        public override void ReclaimAll()
        {
            foreach (var obj in objects)
            {
                if (obj != null)
                    Object.Destroy(obj.gameObject);
            }

            objects.Clear();
        }
    }
}
