using AspireDemo.Api.Database;
using AspireDemo.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddNpgsqlDbContext<ProductDbContext>("db");
builder.EnrichNpgsqlDbContext<ProductDbContext>();

var app = builder.Build();

app.MapProductEndpoints();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
DbInitializer.Initialize(context);

app.Run();
