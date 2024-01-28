using MovieAPI.Application.Exceptions;
using MovieAPI.Application.Services;
using MovieAPI.Mappers;
using MovieAPI.ViewModels;

namespace MovieAPI.Services
{
    public class MovieInformationService : IMovieInformationService
    {
        private readonly IMovieDetailsService _movieDetailsService;
        private readonly IMovieVideosService _movieVideosService;
        private readonly IMovieViewModelMapper _movieViewModelMapper;

        public MovieInformationService(IMovieDetailsService movieDetailsService, IMovieVideosService movieVideosService, IMovieViewModelMapper movieViewModelMapper)
        {
            _movieDetailsService = movieDetailsService;
            _movieVideosService = movieVideosService;
            _movieViewModelMapper = movieViewModelMapper;
        }

        public async Task<MovieViewModel> GetMovieInformation(string movieName)
        {
            var movieDetails = await _movieDetailsService.GetMovieDetailsAsync(movieName);
            if (!movieDetails.IsValid)
            {
                throw new MovieDetailsResponseException("Movie is invalid");
            }

            var movieVideos = await _movieVideosService.GetMovieVideosURLsAsync(movieName);
            return _movieViewModelMapper.MapMovieViewModel(movieDetails, movieVideos);
        }
    }
}
