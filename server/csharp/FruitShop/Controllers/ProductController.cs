using FruitShop.Models;
using FruitShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitShop.Controllers;

[ApiController]
[Route("products")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Product> Get()
    {
        return ProductService.GetAll();
    }

    [HttpGet("{id:int}")]
    public ActionResult<Product> Get(int id)
    {
        var product = ProductService.Get(id);
        if (product != null)
            return product;
        
        return NotFound();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        ProductService.Add(product);
        return CreatedAtAction(nameof(Create), new { id = product.Id }, product);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Product product)
    {
        if (id != product.Id)
            return BadRequest();

        if (ProductService.Get(id) is null)
            return NotFound();
        
        ProductService.Update(product);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (ProductService.Get(id) is null)
            return NotFound();
        
        ProductService.Delete(id);
        return NoContent();
    }
}