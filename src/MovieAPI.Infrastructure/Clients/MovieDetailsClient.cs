using Microsoft.Extensions.Options;
using MovieAPI.Infrastructure.Models.MovieDetailsResponse;
using MovieAPI.Infrastructure.Options;
using System.Net;
using System.Net.Http.Json;

namespace MovieAPI.Infrastructure.Clients
{
    public class MovieDetailsClient : IMovieDetailsClient
    {
        private readonly MovieDetailsAPIConfigurationOptions _movieDetailsAPIConfigurationOptions;
        public MovieDetailsClient(IOptions<MovieDetailsAPIConfigurationOptions> movieDetailsAPIConfigurationOptions)
        {
            _movieDetailsAPIConfigurationOptions = movieDetailsAPIConfigurationOptions.Value;
        }

        public async Task<MovieDetailsResponse> GetMovieDetailsAsync(string movieName)
        {
            var apiKey = _movieDetailsAPIConfigurationOptions.ApiKey;
            var baseUrl = _movieDetailsAPIConfigurationOptions.BaseUrl;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var fullUrl = $"{baseUrl}?t={movieName}&apikey={apiKey}";
                    var response = await client.GetAsync(fullUrl);
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadFromJsonAsync<MovieDetailsResponse>();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
