using MovieAPI.Application.Entities;

namespace MovieAPI.Application.Services
{
    public interface IMovieVideosService
    {
        Task<MovieVideos> GetMovieVideosURLsAsync(string movieName);
    }
}
