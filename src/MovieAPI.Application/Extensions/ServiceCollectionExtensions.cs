using Microsoft.Extensions.DependencyInjection;
using MovieAPI.Application.Services;

namespace MovieAPI.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplicationsServices(this IServiceCollection services)
        {
            services.AddScoped<IDistributedCacheService, DistributedCacheService>();

            return services;
        }
    }
}
