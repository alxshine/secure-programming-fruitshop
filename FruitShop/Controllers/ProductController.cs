using FruitShop.Models;
using FruitShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitShop.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet(Name = "products")]
    public IEnumerable<Product> Get()
    {
        return ProductService.GetAll();
    }
}