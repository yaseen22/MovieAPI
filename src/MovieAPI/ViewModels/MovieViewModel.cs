namespace MovieAPI.ViewModels
{
    public class MovieViewModel
    {
        public string Title { get; set; } = string.Empty;
        public List<string> VideoURLs { get; set; } = new();
    }
}
