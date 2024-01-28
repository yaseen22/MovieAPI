using MovieAPI.Application.Extensions;
using MovieAPI.Extensions;
using MovieAPI.Infrastructure.Extensions;
using MovieAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureServices();
builder.Services.ConfigureApplicationsServices();
builder.Services.RegisterOmdbOptions(builder.Configuration);
builder.Services.ConfigureMovieDetailsServices();
builder.Services.RegisterYoutubeOptions(builder.Configuration);
builder.Services.ConfigureMovieVideosServices();

builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
