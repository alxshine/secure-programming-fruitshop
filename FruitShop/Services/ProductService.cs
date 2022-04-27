using FruitShop.Models;

namespace FruitShop.Services;

public static class ProductService
{
    private static List<Product> Products { get; }
    private static int nextId = 3;

    static ProductService()
    {
        Products = new List<Product>
        {
            new() { Id = 1, Name = "Bananas", Description = "Tasty Bananas", Price = (decimal)2.99 },
            new() { Id = 2, Name = "Apples", Description = "Some dope Apples", Price = (decimal)1.29 }
        };
    }

    public static List<Product> GetAll() => Products;
    public static Product? Get(int id) => Products.FirstOrDefault(p => p.Id == id);

    public static void Add(Product product)
    {
        product.Id = nextId++;
        Products.Add(product);
    }

    public static void Delete(int id)
    {
        var product = Get(id);
        if (product is null)
            return;
        Products.Remove(product);
    }

    public static void Update(Product product)
    {
        var index = Products.FindIndex(p => p.Id == product.Id);
        if (index == -1)
            return;

        Products[index] = product;
    }
}