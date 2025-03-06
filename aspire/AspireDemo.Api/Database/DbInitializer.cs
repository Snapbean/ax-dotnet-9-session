using AspireDemo.Shared;

namespace AspireDemo.Api.Database;

public static class DbInitializer
{
    public static void Initialize(ProductDbContext context)
    {
        context.Database.EnsureCreated();
        
        if (context.Products.Any())
            return;

        var products = new List<Product>
        {
            new() { Name = "Solar Powered Flashlight", Description = "A fantastic product for outdoor enthusiasts", Price = 19.99m },
            new() { Name = "Hiking Poles", Description = "Ideal for camping and hiking trips", Price = 24.99m },
            new() { Name = "Outdoor Rain Jacket", Description = "This product will keep you warm and dry in all weathers", Price = 49.99m },
            new() { Name = "Survival Kit", Description = "A must-have for any outdoor adventurer", Price = 99.99m },
            new() { Name = "Outdoor Backpack", Description = "This backpack is perfect for carrying all your outdoor essentials", Price = 39.99m },
            new() { Name = "Camping Cookware", Description = "This cookware set is ideal for cooking outdoors", Price = 29.99m },
            new() { Name = "Camping Stove", Description = "This stove is perfect for cooking outdoors", Price = 49.99m },
            new() { Name = "Camping Lantern", Description = "This lantern is perfect for lighting up your campsite", Price = 19.99m },
            new() {  Name = "Camping Tent", Description = "This tent is perfect for camping trips", Price = 99.99m }
        };

        context.AddRange(products);

        context.SaveChanges();
    }
}