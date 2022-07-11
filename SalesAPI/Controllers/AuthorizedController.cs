using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SalesAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AuthorizedController : ControllerBase
{
    public IActionResult Get()
    {
        return new JsonResult("Placeholder, any authorized users should see this regardless of claims");
    }
}