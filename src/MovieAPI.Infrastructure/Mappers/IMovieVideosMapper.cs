using Google.Apis.YouTube.v3.Data;
using MovieAPI.Application.Entities.MovieVideos;

namespace MovieAPI.Infrastructure.Mappers
{
    public interface IMovieVideosMapper
    {
        MovieVideos MapMovieVideos(IEnumerable<SearchResult> searchResults);
    }
}