using MovieAPI.Infrastructure.Mappers;
using MovieAPI.Mappers;
using MovieAPI.Services;

namespace MovieAPI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieInformationService, MovieInformationService>();
            services.AddScoped<IMovieViewModelMapper, MovieViewModelMapper>();
            services.AddAutoMapper(typeof(MovieViewModelMappingProfile));

            return services;
        }
    }
}
