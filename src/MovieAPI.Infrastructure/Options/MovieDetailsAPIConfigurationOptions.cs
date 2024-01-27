using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Infrastructure.Options
{
    public class MovieDetailsAPIConfigurationOptions
    {
        public const string SECTION_NAME = "MovieDetailsAPIConfigurationOptions";
        [Required(AllowEmptyStrings = false)]
        public string ApiKey { get; init; } = null!;
        [Required(AllowEmptyStrings = false)]
        public string BaseUrl { get; init; } = null!;
    }
}
