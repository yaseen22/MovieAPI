using AutoMapper;
using MovieAPI.Application.Entities;
using MovieAPI.Infrastructure.Models.MovieDetailsResponse;

namespace MovieAPI.Infrastructure.Mappers
{
    public class MovieDetailsMappingProfile : Profile
    {
        public MovieDetailsMappingProfile()
        {
            CreateMap<Models.MovieDetailsResponse.Rating, Application.Entities.Rating>();
            CreateMap<MovieDetailsResponse, MovieDetails>()
                .ForMember(dest => dest.IMDBID, opt => opt.MapFrom(src => src.imdbID))
                .ForMember(dest => dest.IMDBVotes, opt => opt.MapFrom(src => src.imdbVotes))
                .ForMember(dest => dest.IMDBRating, opt => opt.MapFrom(src => src.imdbRating))
                .ForMember(dest => dest.Ratings, opt => opt.MapFrom(src => src.Ratings));
        }
    }
}
