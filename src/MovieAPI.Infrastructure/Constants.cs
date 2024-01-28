namespace MovieAPI.Infrastructure
{
    public static class Constants
    {
        public const string YOUTUBE_VIDEOS_IDENTIFIER = "youtube#video";
        public const int YOUTUBE_VIDEOS_MAX_RESULTS = 20;
        public const string YOUTUBE_VIDEO_BASE_URL = "https://www.youtube.com/watch?v=";

        public const int SLIDING_EXPIRATION_TIME_IN_MINUTES = 5;
        public const int ABSOLUTE_EXPIRATION_TIME_IN_MINUTES = 15;
    }
}
