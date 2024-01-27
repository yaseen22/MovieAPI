using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Infrastructure.Options
{
    public class MovieVideosAPIConfigurationOptions
    {
        public const string SECTION_NAME = "MovieVideosAPIConfigurationOptions";
        [Required(AllowEmptyStrings = false)]
        public string ApiKey { get; init; } = null!;
    }
}
