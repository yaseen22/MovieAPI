using MovieAPI.Application.Entities;

namespace MovieAPI.Application.Services
{
    public interface IMovieDetailsService
    {
        Task<MovieDetails> GetMovieDetailsAsync(string movieName);
    }
}
