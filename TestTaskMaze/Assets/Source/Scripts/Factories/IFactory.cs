namespace Assets.Source.Scripts.Factories
{
    public interface IFactory<out T>
    {
        public T Get();
        public void ReclaimAll();
    }
}