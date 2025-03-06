using AspireDemo.Api.Database;
using AspireDemo.Shared;
using Microsoft.EntityFrameworkCore;

namespace AspireDemo.Api.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Product");

        group.MapGet("/", async (ProductDbContext db) => await db.Products.ToListAsync());

        group.MapGet("/{id:int}", async (int id, ProductDbContext db) =>
        {
            return await db.Products.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.Id == id)
                is Product model
                ? Results.Ok(model)
                : Results.NotFound();
        });
    }
}