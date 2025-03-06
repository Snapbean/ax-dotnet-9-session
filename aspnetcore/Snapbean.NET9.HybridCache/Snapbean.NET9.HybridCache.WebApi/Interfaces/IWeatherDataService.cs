using Snapbean.NET9.HybridCache.WebApi.Models;

namespace Snapbean.NET9.HybridCache.WebApi.Interfaces;

public interface IWeatherDataService
{
    Task<WeatherForecast> GetWeatherForecastByLocation(string location);
}