namespace MovieAPI.Infrastructure.Helpers
{
    public static class YoutubeHelper
    {
        private const string YoutubeVideoBaseUrl = Constants.YOUTUBE_VIDEO_BASE_URL;

        public static string GetYoutubeUrl(string videoId)
        {
            return $"{YoutubeVideoBaseUrl}{videoId}";
        }
    }
}
