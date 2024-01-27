﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieAPI.Application.Services;
using MovieAPI.Infrastructure.Clients;
using MovieAPI.Infrastructure.Mappers;
using MovieAPI.Infrastructure.Options;
using MovieAPI.Infrastructure.Services;

namespace MovieAPI.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureMovieDetailsServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieDetailsService, MovieDetailsService>();
            services.AddScoped<IMovieDetailsClient, MovieDetailsClient>();
            services.AddScoped<IMovieDetailsMapper, MovieDetailsMapper>();

            return services;
        }

        public static IServiceCollection RegisterOmdbOptions(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddOptions<MovieDetailsAPIConfigurationOptions>()
            .Bind(configuration.GetRequiredSection(MovieDetailsAPIConfigurationOptions.SECTION_NAME))
            .ValidateDataAnnotations()
            .ValidateOnStart();
            return services;
        }
    }
}