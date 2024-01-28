using MovieAPI.Application.Entities;
using MovieAPI.ViewModels;

namespace MovieAPI.Mappers
{
    public interface IMovieViewModelMapper
    {
        MovieViewModel MapMovieViewModel(MovieDetails movieDetails, MovieVideos movieVideos);
    }
}