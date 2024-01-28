using AutoMapper;
using MovieAPI.Application.Entities;
using MovieAPI.ViewModels;

namespace MovieAPI.Mappers
{
    public class MovieViewModelMappingProfile : Profile
    {
        public MovieViewModelMappingProfile()
        {
            CreateMap<Rating, RatingViewModel>();
            CreateMap<MovieDetails, MovieViewModel>()
            .ForMember(dest => dest.Ratings, opt => opt.MapFrom(src => src.Ratings));
        }
    }
}
