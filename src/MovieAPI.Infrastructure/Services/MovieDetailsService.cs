using MovieAPI.Application.Entities.MovieDetails;
using MovieAPI.Application.Services;
using MovieAPI.Infrastructure.Clients;
using MovieAPI.Infrastructure.Mappers;

namespace MovieAPI.Infrastructure.Services
{
    public class MovieDetailsService : IMovieDetailsService
    {
        private readonly IMovieDetailsClient _movieDetailsClient;
        private readonly IMovieDetailsMapper _movieDetailsMapper;

        public MovieDetailsService(IMovieDetailsClient movieDetailsClient, IMovieDetailsMapper movieDetailsMapper)
        {
            _movieDetailsClient = movieDetailsClient;
            _movieDetailsMapper = movieDetailsMapper;
        }

        public async Task<MovieDetails> GetMovieDetailsAsync(string movieName)
        {
            var response = await _movieDetailsClient.GetMovieDetailsAsync(movieName);

            return _movieDetailsMapper.MapMovieDetails(response);
        }
    }
}
