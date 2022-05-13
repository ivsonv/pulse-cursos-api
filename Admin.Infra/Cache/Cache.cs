using Microsoft.Extensions.Caching.Memory;

namespace Admin.Infra.Cache
{
    public class Cache : Domain.Interface.Cache.ICache
    {
        private readonly IMemoryCache _cache;
        public Cache(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public void Set(object obj, string key, int seconds = 60)
            => _cache.Set(key, obj, TimeSpan.FromSeconds(seconds));

        public T Get<T>(string key) => (T)_cache.Get(key);

        public void Forget(string key) => _cache.Remove(key);
    }
}