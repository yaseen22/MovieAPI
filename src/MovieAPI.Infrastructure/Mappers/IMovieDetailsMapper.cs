using MovieAPI.Application.Entities.MovieDetails;
using MovieAPI.Infrastructure.Models.MovieDetailsResponse;

namespace MovieAPI.Infrastructure.Mappers
{
    public interface IMovieDetailsMapper
    {
        MovieDetails MapMovieDetails(MovieDetailsResponse movieDetailsResponse);
    }
}