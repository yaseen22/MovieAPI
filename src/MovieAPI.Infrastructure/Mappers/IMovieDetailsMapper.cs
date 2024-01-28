using MovieAPI.Application.Entities;
using MovieAPI.Infrastructure.Models.MovieDetailsResponse;

namespace MovieAPI.Infrastructure.Mappers
{
    public interface IMovieDetailsMapper
    {
        MovieDetails MapMovieDetails(MovieDetailsResponse movieDetailsResponse);
    }
}