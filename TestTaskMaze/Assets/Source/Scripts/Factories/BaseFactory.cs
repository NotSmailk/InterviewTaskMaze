using System.Collections.Generic;

namespace Assets.Source.Scripts.Factories
{
    public abstract class BaseFactory<T> : IFactory<T>
    {
        protected T objectToCreate;
        protected List<T> objects = new List<T>();

        public abstract T Get();
        public abstract void ReclaimAll();
    }
}
