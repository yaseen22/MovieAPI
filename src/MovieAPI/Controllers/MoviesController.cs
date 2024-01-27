using Microsoft.AspNetCore.Mvc;
using MovieAPI.Services;
using MovieAPI.ViewModels;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovieInformationService _movieInformationService;

        public MoviesController(IMovieInformationService movieInformationService)
        {
            _movieInformationService = movieInformationService;
        }

        [HttpGet]
        public async Task<ActionResult<MovieViewModel>> Get(string name)
        {
            return await _movieInformationService.GetMovieInformation(name);
        }
    }
}
