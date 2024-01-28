using MovieAPI.Application.Exceptions;
using MovieAPI.ViewModels;
using System.Text.Json;

namespace MovieAPI.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                string? message;
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case MovieDetailsResponseException:
                        message = JsonSerializer.Serialize(new ErrorViewModel
                        {
                            Title = "Error retrieving movie details",
                            Description = error.Message
                        });
                        break;
                    case MovieDetailsConnectionException:
                        message = JsonSerializer.Serialize(new ErrorViewModel
                        {
                            Title = "Connection to get movie details has failed",
                            Description = error.Message
                        });
                        break;
                    case MovieVideosConnectionException:
                        message = JsonSerializer.Serialize(new ErrorViewModel
                        {
                            Title = "Connection to get movie videos has failed",
                            Description = error.Message
                        });
                        break;
                    default:
                        message = JsonSerializer.Serialize(new ErrorViewModel
                        {
                            Title = "An error has occured"
                        });
                        break;
                }
                await response.WriteAsync(message);
            }
        }
    }
}
