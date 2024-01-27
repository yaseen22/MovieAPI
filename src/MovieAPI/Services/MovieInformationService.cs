using MovieAPI.Application.Services;
using MovieAPI.ViewModels;

namespace MovieAPI.Services
{
    public class MovieInformationService : IMovieInformationService
    {
        private readonly IMovieDetailsService _movieDetailsService;
        private readonly IMovieVideosService _movieVideosService;

        public MovieInformationService(IMovieDetailsService movieDetailsService, IMovieVideosService movieVideosService)
        {
            _movieDetailsService = movieDetailsService;
            _movieVideosService = movieVideosService;
        }

        public async Task<MovieViewModel> GetMovieInformation(string movieName)
        {
            var movieDetails = await _movieDetailsService.GetMovieDetailsAsync(movieName);
            var movieVideos = await _movieVideosService.GetMovieVideosURLsAsync(movieName);

            return new MovieViewModel()
            {
                Title = movieDetails.Title,
                VideoURLs = movieVideos.VideoURLs
            };
        }
    }
}
