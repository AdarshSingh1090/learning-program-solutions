using System;
using System.Threading.Tasks;
using RetailInventory.Models;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("📦 Inserting initial data...");

        using var context = new AppDbContext();

        
        var electronics = new Category
        {
            Name = "Electronics",
            Products = new List<Product>() 
        };

        var groceries = new Category
        {
            Name = "Groceries",
            Products = new List<Product>()
         };

        
        await context.Categories.AddRangeAsync(electronics, groceries);
        await context.SaveChangesAsync(); 

        
        var product1 = new Product
        {
            Name = "Laptop",
            Price = 75000,
            CategoryId = electronics.Id
        };

        var product2 = new Product
        {
            Name = "Rice Bag",
            Price = 1200,
            CategoryId = groceries.Id
        };

        
        await context.Products.AddRangeAsync(product1, product2);
        await context.SaveChangesAsync();

        Console.WriteLine("✅ Data inserted successfully!");
}
}

