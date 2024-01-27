using Google.Apis.YouTube.v3.Data;

namespace MovieAPI.Infrastructure.Clients
{
    public interface IMovieVideosClient
    {
        Task<IEnumerable<SearchResult>> GetMovieVideosAsync(string movieName);
    }
}