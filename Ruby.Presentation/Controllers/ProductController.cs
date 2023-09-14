using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ruby.BusinessLogic.Models;
using Ruby.BusinessLogic.Services;

namespace Ruby.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<ProductDto> Get([FromServices]ProductService productService)
    {
       return productService.GetProducts();
    }

    [HttpPost]
    public IActionResult Post([FromBody] ProductInputDto newProduct, [FromServices]ProductService productService)
    {
        productService.CreateProduct(newProduct);
        return Ok();
    }
}
