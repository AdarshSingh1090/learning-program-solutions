using System;

class Program
{
    static void Main()
    {
        Product[] products = {
            new Product(103, "Mouse", "Electronics"),
            new Product(101, "Shirt", "Clothing"),
            new Product(105, "Keyboard", "Electronics"),
            new Product(102, "Book", "Stationery"),
            new Product(104, "Shoes", "Footwear")
        };

        // For Binary Search - sort array by ProductId
        Array.Sort(products, (p1, p2) => p1.ProductId.CompareTo(p2.ProductId));

        int targetId = 104;

        Product result1 = SearchFunctions.LinearSearch(products, targetId);
        Console.WriteLine("Linear Search: " + (result1 != null ? result1.ProductName : "Not Found"));

        Product result2 = SearchFunctions.BinarySearch(products, targetId);
        Console.WriteLine("Binary Search: " + (result2 != null ? result2.ProductName : "Not Found"));
    }
}
