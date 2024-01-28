using MovieAPI.Application.Entities;
using MovieAPI.Application.Services;
using MovieAPI.Infrastructure.Clients;
using MovieAPI.Infrastructure.Mappers;

namespace MovieAPI.Infrastructure.Services
{
    public class MovieVideosService : IMovieVideosService
    {
        private readonly IMovieVideosClient _movieVideosClient;
        private readonly IMovieVideosMapper _movieVideosMapper;

        public MovieVideosService(IMovieVideosClient movieVideosClient, IMovieVideosMapper movieVideosMapper)
        {
            _movieVideosClient = movieVideosClient;
            _movieVideosMapper = movieVideosMapper;
        }

        public async Task<MovieVideos> GetMovieVideosURLsAsync(string movieName)
        {
            var result = await _movieVideosClient.GetMovieVideosAsync(movieName);

            return _movieVideosMapper.MapMovieVideos(result);
        }
    }
}
