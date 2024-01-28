using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.Extensions.Options;
using MovieAPI.Application.Exceptions;
using MovieAPI.Infrastructure.Options;

namespace MovieAPI.Infrastructure.Clients
{
    public class MovieVideosClient : IMovieVideosClient
    {
        private readonly MovieVideosAPIConfigurationOptions _movieVideosAPIConfigurationOptions;
        public MovieVideosClient(IOptions<MovieVideosAPIConfigurationOptions> movieVideosAPIConfigurationOptions)
        {
            _movieVideosAPIConfigurationOptions = movieVideosAPIConfigurationOptions.Value;
        }

        public async Task<IEnumerable<SearchResult>> GetMovieVideosAsync(string movieName)
        {
            try
            {
                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = _movieVideosAPIConfigurationOptions.ApiKey,
                    ApplicationName = this.GetType().ToString()
                });

                var searchListRequest = youtubeService.Search.List("snippet");
                searchListRequest.Q = movieName;
                searchListRequest.MaxResults = Constants.YOUTUBE_VIDEOS_MAX_RESULTS;
                var searchListResponse = await searchListRequest.ExecuteAsync();

                var result = searchListResponse.Items.Where(x => x.Id.Kind.Equals(Constants.YOUTUBE_VIDEOS_IDENTIFIER));

                return result;
            }
            catch (Exception ex)
            {
                throw new MovieVideosConnectionException(ex.Message);
            }
        }
    }
}
