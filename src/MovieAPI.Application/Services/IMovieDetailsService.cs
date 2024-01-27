using MovieAPI.Application.Entities.MovieDetails;

namespace MovieAPI.Application.Services
{
    public interface IMovieDetailsService
    {
        Task<MovieDetails> GetMovieDetailsAsync(string movieName);
    }
}
