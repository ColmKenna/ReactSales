using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SalesAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ProductsController : ControllerBase
{
    [Authorize("ViewProducts")]
    public IActionResult Get()
    {
        return new JsonResult("Placeholder for a list of products only those with a ViewProducts claim should be able to see this");
    }
}