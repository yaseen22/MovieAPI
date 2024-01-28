using AutoMapper;
using MovieAPI.Application.Entities;
using MovieAPI.Infrastructure.Models.MovieDetailsResponse;

namespace MovieAPI.Infrastructure.Mappers
{
    public class MovieDetailsMapper : IMovieDetailsMapper
    {
        public MovieDetails MapMovieDetails(MovieDetailsResponse movieDetailsResponse)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MovieDetailsMappingProfile>();
            });

            var mapper = new Mapper(config);

            return mapper.Map<MovieDetails>(movieDetailsResponse);
        }
    }
}
