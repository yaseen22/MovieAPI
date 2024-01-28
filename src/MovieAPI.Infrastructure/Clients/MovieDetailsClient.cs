using Microsoft.Extensions.Options;
using MovieAPI.Application.Exceptions;
using MovieAPI.Infrastructure.Models.MovieDetailsResponse;
using MovieAPI.Infrastructure.Options;
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

                    var result = await response.Content.ReadFromJsonAsync<MovieDetailsResponse>() ?? new MovieDetailsResponse();
                    if (!result.IsValid)
                        throw new MovieDetailsResponseException(result.Error);

                    return result;
                }
            }
            catch (MovieDetailsResponseException ex)
            {
                throw new MovieDetailsResponseException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new MovieDetailsConnectionException(ex.Message);
            }
        }
    }
}
