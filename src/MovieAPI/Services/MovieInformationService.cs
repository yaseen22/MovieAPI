using MovieAPI.Application.Services;
using MovieAPI.ViewModels;

namespace MovieAPI.Services
{
    public class MovieInformationService : IMovieInformationService
    {
        private readonly IMovieDetailsService _movieDetailsService;

        public MovieInformationService(IMovieDetailsService movieDetailsService)
        {
            _movieDetailsService = movieDetailsService;
        }

        public async Task<MovieViewModel> GetMovieInformation(string movieName)
        {
            var movieDetails = await _movieDetailsService.GetMovieDetailsAsync(movieName);

            return new MovieViewModel()
            {
                Title = movieDetails.Title
            };
        }
    }
}
