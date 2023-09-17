using Microsoft.AspNetCore.Mvc;
using Ruby.BusinessLogic.Services;

namespace Ruby.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public ActionResult Login(string email, [FromServices] AuthService authService)
    {
        if (authService.Login(email))
            return Ok();
        return BadRequest();
    }

    [HttpGet]
    public ActionResult Get([FromServices] AuthService authService)
    {
        var result = authService.GetProductsWithPrice();

        return Ok(result);
    }
}
