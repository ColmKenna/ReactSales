using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SalesAPI.Controllers;

[Route("AllUsers")]
[AllowAnonymous]
public class AllUsersController : ControllerBase
{
    public IActionResult Get()
    {
        return new JsonResult("Anyone should be able to see this");
    }

}