using Google.Apis.YouTube.v3.Data;
using MovieAPI.Application.Services;

namespace MovieAPI.Infrastructure.Clients
{
    public class CachedMovieVideosClient : IMovieVideosClient
    {
        private readonly IMovieVideosClient _movieVideosClient;
        private readonly IDistributedCacheService _cache;

        public CachedMovieVideosClient(IMovieVideosClient movieVideosClient, IDistributedCacheService cache)
        {
            _movieVideosClient = movieVideosClient;
            _cache = cache;
        }

        public async Task<IEnumerable<SearchResult>> GetMovieVideosAsync(string movieName)
        {
            var cacheKey = $"MovieVideos-{movieName}";
            var movieVideosResponse = await _cache.GetCacheObjectAsync<IEnumerable<SearchResult>>(cacheKey, CancellationToken.None);
            if (movieVideosResponse != null)
            {
                return movieVideosResponse;
            }

            var result = await _movieVideosClient.GetMovieVideosAsync(movieName);
            await _cache.SetCacheValueAsync(cacheKey, result, Constants.SLIDING_EXPIRATION_TIME_IN_MINUTES,
                Constants.ABSOLUTE_EXPIRATION_TIME_IN_MINUTES, CancellationToken.None);
            return result;
        }
    }
}
