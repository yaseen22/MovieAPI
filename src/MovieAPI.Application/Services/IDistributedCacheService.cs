namespace MovieAPI.Application.Services
{
    public interface IDistributedCacheService
    {
        Task<T?> GetCacheObjectAsync<T>(string key, CancellationToken cancellationToken) where T : class;
        Task SetCacheValueAsync<T>(string key, T value, int slidingExpirationInMinutes, int absoluteExpirationInMinutes, CancellationToken cancellationToken) where T : class;
    }
}