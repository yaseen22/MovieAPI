using MovieAPI.Application.Services;
using MovieAPI.Infrastructure.Models.MovieDetailsResponse;

namespace MovieAPI.Infrastructure.Clients
{
    public class CachedMovieDetailsClient : IMovieDetailsClient
    {
        private readonly IMovieDetailsClient _movieDetailsClient;
        private readonly IDistributedCacheService _cache;

        public CachedMovieDetailsClient(IDistributedCacheService cache, IMovieDetailsClient movieDetailsClient)
        {
            _cache = cache;
            _movieDetailsClient = movieDetailsClient;
        }

        public async Task<MovieDetailsResponse> GetMovieDetailsAsync(string movieName)
        {
            var cacheKey = $"MovieDetails-{movieName}";
            var movieDetailsResponse = await _cache.GetCacheObjectAsync<MovieDetailsResponse>(cacheKey, CancellationToken.None);
            if (movieDetailsResponse != null)
            {
                return movieDetailsResponse;
            }

            var result = await _movieDetailsClient.GetMovieDetailsAsync(movieName);
            await _cache.SetCacheValueAsync(cacheKey, result, Constants.SLIDING_EXPIRATION_TIME_IN_MINUTES,
                Constants.ABSOLUTE_EXPIRATION_TIME_IN_MINUTES, CancellationToken.None);
            return result;
        }
    }
}
