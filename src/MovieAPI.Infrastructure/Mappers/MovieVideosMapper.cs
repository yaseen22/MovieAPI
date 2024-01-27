using Google.Apis.YouTube.v3.Data;
using MovieAPI.Application.Entities.MovieVideos;

namespace MovieAPI.Infrastructure.Mappers
{
    public class MovieVideosMapper : IMovieVideosMapper
    {
        public MovieVideos MapMovieVideos(IEnumerable<SearchResult> searchResults)
        {
            var videosIDs = searchResults.Select(id => id.Id.VideoId).ToList();
            return new MovieVideos()
            {
                VideoURLs = videosIDs.Select(videoId => Constants.YOUTUBE_VIDEO_BASE_URL + videoId).ToList()
            };
        }
    }
}
