using Microsoft.Extensions.Caching.Hybrid;
using Snapbean.NET9.HybridCache.WebApi.Interfaces;
using Snapbean.NET9.HybridCache.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

builder.Services.AddAuthorization();

// Register the WeatherDataService service which uses the new HybridCache
builder.Services.AddScoped<IWeatherDataService, WeatherDataService>();

// Register the HybridCache service with cache expiration settings
builder.Services.AddHybridCache(options =>
{
    options.DefaultEntryOptions = new HybridCacheEntryOptions
    {
        LocalCacheExpiration = TimeSpan.FromSeconds(15),
        Expiration = TimeSpan.FromSeconds(30)
    };
});

// Add sample redis cache service registration as distributed cache
// builder.Services.AddStackExchangeRedisCache(options =>
// {
//     options.Configuration = "localhost:6379";
//     options.InstanceName = "SampleInstance";
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Endpoint to get weather forecast by location
app.MapGet("/weatherforecast/{location}", async (string location, IWeatherDataService weatherDataService) =>
    {
        var forecastByLocation = await weatherDataService.GetWeatherForecastByLocation(location);
        return Results.Ok(forecastByLocation);
    })
    .WithName("GetWeatherForecastByLocation");

app.Run();