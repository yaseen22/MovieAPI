using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace MovieAPI.Application.Services
{
    public class DistributedCacheService : IDistributedCacheService
    {
        private readonly IDistributedCache _cache;

        public DistributedCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> GetCacheObjectAsync<T>(string key, CancellationToken cancellationToken) where T : class?
        {
            var cachedValue = await _cache.GetStringAsync(key, cancellationToken);
            if (cachedValue == null)
            {
                return null;
            }
            var value = JsonConvert.DeserializeObject<T>(cachedValue);
            return value;
        }

        public async Task SetCacheValueAsync<T>(string key, T value, int slidingExpirationInMinutes,
            int absoluteExpirationInMinutes, CancellationToken cancellationToken) where T : class
        {
            var cacheValue = JsonConvert.SerializeObject(value);
            await _cache.SetStringAsync(key, cacheValue, new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(slidingExpirationInMinutes),
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(absoluteExpirationInMinutes)
            }, cancellationToken);
        }
    }
}
