using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Register the OpenAPI services
builder.Services.AddOpenApi();

// Register the OpenAPI services with additional configuration
// builder.Services.AddOpenApi("v1", options =>
// {
//     options.AddDocumentTransformer((document, _, _) =>
//     {
//         document.Info.Title = "Weather Forecast API";
//         document.Info.Version = "42.0.0";
//         document.Info.Description = "This is a simple weather forecast API";
//         return Task.CompletedTask;
//     });
//     options.AddSchemaTransformer( (schema, _, _) =>
//     {
//         // Do something with the schema
//         return Task.CompletedTask;
//     });
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Add middleware to serve the OpenAPI document
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint("/openapi/v1.json", "v1")); // Serve the Swagger UI with the OpenAPI document
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast") // Extension methods to define OpenApi metadata
    .WithDescription("Get weather forecast for the next 5 days")
    .WithSummary("Get weather forecast")
    .WithTags("Weather")
    .ProducesProblem(StatusCodes.Status400BadRequest);

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}