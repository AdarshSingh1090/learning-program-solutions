using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        Console.WriteLine("🔍 Retrieving all products...");
        var products = await context.Products.ToListAsync();
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} - ₹{p.Price}");
        }

        Console.WriteLine("\n🔍 Finding product by ID (1)...");
        var productById = await context.Products.FindAsync(1);
        if (productById != null)
            Console.WriteLine($"Found: {productById.Name}");

        Console.WriteLine("\n🔍 Finding first expensive product (> ₹50,000)...");
        var expensive = await context.Products.FirstOrDefaultAsync(p => 
        p.Price > 50000);
        if (expensive != null)
            Console.WriteLine($"Expensive Product: {expensive.Name}");
    }
}
