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
                    case MovieNotFoundException:
                        message = JsonSerializer.Serialize(new ErrorViewModel
                        {
                            Title = "Movie is not found" 
                        });
                        break;
                    default:
                        message = JsonSerializer.Serialize(new ErrorViewModel
                        {
                            Title = "An error occured"
                        });
                        break;
                }
                await response.WriteAsync(message);
            }
        }
    }
}
