public class Singleton<T> where T : class, new()
{
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }

        set
        {
            _instance = value;
        }
    }

    protected static T _instance = null;
}