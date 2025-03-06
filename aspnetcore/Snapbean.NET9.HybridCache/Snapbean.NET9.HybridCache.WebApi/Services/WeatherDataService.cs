using Snapbean.NET9.HybridCache.WebApi.Interfaces;
using Snapbean.NET9.HybridCache.WebApi.Models;

namespace Snapbean.NET9.HybridCache.WebApi.Services;

public class WeatherDataService(Microsoft.Extensions.Caching.Hybrid.HybridCache cache) : IWeatherDataService
{
    public async Task<WeatherForecast> GetWeatherForecastByLocation(string location)
    {
        var cacheKey = $"weatherData:{location}";

        // Use HybridCache to fetch data or create it if missing
        return await cache.GetOrCreateAsync(
            cacheKey,
            async cancel => await FetchWeatherData(location));
    }

    // Simulating fetching weather data
    private static Task<WeatherForecast> FetchWeatherData(string location)
    {
        var random = new Random();
        string[] summaries =
            ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

        var temperatureC = random.Next(-20, 55);
        var summary = summaries[random.Next(summaries.Length)];

        return Task.FromResult(new WeatherForecast(location, summary, temperatureC));
    }
}