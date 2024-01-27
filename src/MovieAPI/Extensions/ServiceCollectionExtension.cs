using MovieAPI.Services;

namespace MovieAPI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieInformationService, MovieInformationService>();

            return services;
        }
    }
}
