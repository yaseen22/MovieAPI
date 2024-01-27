using MovieAPI.ViewModels;

namespace MovieAPI.Services
{
    public interface IMovieInformationService
    {
        Task<MovieViewModel> GetMovieInformation(string movieName);
    }
}