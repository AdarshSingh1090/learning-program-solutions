public class SearchFunctions
{
    public static Product? LinearSearch(Product[] products, int targetId)
    {
        foreach (Product p in products)
        {
            if (p.ProductId == targetId)
                return p;
        }
        return null;
    }

    public static Product? BinarySearch(Product[] products, int targetId)
    {
        int low = 0, high = products.Length - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (products[mid].ProductId == targetId)
                return products[mid];
            else if (products[mid].ProductId < targetId)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return null;
    }
}