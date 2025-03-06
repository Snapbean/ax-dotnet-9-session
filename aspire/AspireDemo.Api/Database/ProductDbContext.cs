using AspireDemo.Shared;
using Microsoft.EntityFrameworkCore;

namespace AspireDemo.Api.Database;

public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; init; }
}