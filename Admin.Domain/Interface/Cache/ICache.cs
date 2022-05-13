namespace Admin.Domain.Interface.Cache
{
    public interface ICache
    {
        void Set(object obj, string key, int seconds = 60);
        void Forget(string key);
        T Get<T>(string key);
    }
}