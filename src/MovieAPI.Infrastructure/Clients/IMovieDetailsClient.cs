using MovieAPI.Infrastructure.Models.MovieDetailsResponse;

namespace MovieAPI.Infrastructure.Clients
{
    public interface IMovieDetailsClient
    {
        Task<MovieDetailsResponse> GetMovieDetailsAsync(string movieName);
    }
}