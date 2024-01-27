using MovieAPI.Application.Entities.MovieDetails;
using MovieAPI.Infrastructure.Models.MovieDetailsResponse;

namespace MovieAPI.Infrastructure.Mappers
{
    public class MovieDetailsMapper : IMovieDetailsMapper
    {
        public MovieDetails MapMovieDetails(MovieDetailsResponse movieDetailsResponse)
        {
            return new MovieDetails()
            {
                Title = movieDetailsResponse.Title,
                Year = movieDetailsResponse.Year,
                Rated = movieDetailsResponse.Rated,
                Released = movieDetailsResponse.Released,
                Runtime = movieDetailsResponse.Runtime,
                Genre = movieDetailsResponse.Genre,
                Director = movieDetailsResponse.Director,
                Writer = movieDetailsResponse.Writer,
                Actors = movieDetailsResponse.Actors,
                Plot = movieDetailsResponse.Plot,
                Language = movieDetailsResponse.Language,
                Country = movieDetailsResponse.Country,
                Awards = movieDetailsResponse.Awards,
                Poster = movieDetailsResponse.Poster,
                Metascore = movieDetailsResponse.Metascore,
                IMDBRating = movieDetailsResponse.imdbID,
                IMDBVotes = movieDetailsResponse.imdbVotes,
                IMDBID = movieDetailsResponse.imdbID,
                Type = movieDetailsResponse.Type,
                DVD = movieDetailsResponse.DVD,
                BoxOffice = movieDetailsResponse.BoxOffice,
                Production = movieDetailsResponse.Production,
                Website = movieDetailsResponse.Website,
                Response = movieDetailsResponse.Response,
                Ratings = movieDetailsResponse.Ratings.Select(
                    rating => new Application.Entities.MovieDetails.Rating()
                    {
                        Source = rating.Source,
                        Value = rating.Value
                    }).ToList()
            };
        }
    }
}
