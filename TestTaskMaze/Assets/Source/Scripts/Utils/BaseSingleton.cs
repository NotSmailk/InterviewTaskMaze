namespace Assets.Source.Scripts.Utils
{
    public class BaseSingleton<T> where T : new()
    {
        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new T();

                return _instance;
            }
        }

        private static T _instance;
    }
}
