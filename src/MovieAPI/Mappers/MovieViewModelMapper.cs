using AutoMapper;
using MovieAPI.Application.Entities;
using MovieAPI.ViewModels;

namespace MovieAPI.Mappers
{
    public class MovieViewModelMapper : IMovieViewModelMapper
    {
        public MovieViewModel MapMovieViewModel(MovieDetails movieDetails, MovieVideos movieVideos)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MovieViewModelMappingProfile>();
            });
            var mapper = new Mapper(config);

            var movieViewModel = mapper.Map<MovieViewModel>(movieDetails);

            movieViewModel.VideoURLs = movieVideos.VideoURLs;

            return movieViewModel;
        }
    }
}
