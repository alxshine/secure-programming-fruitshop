using FruitShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace FruitShop.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet(Name = "products")]
    public IEnumerable<Product> Get()
    {
        return new[]
        {
            new Product { Name = "Bananas", Description = "Super tasty bananas", Price = (decimal)2.99 },
            new Product { Name = "Apples", Description = "Very tasty apples, much fresh", Price = (decimal)1.29 }
        };
    }
}