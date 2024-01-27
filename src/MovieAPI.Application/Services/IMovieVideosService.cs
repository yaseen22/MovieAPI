using MovieAPI.Application.Entities.MovieVideos;

namespace MovieAPI.Application.Services
{
    public interface IMovieVideosService
    {
        Task<MovieVideos> GetMovieVideosURLsAsync(string movieName);
    }
}
