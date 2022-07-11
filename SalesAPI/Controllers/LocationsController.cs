using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SalesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class LocationsController : ControllerBase
    {
        [Authorize("ViewLocations")]
        public IActionResult Get()
        {
            return new JsonResult("Placeholder for a list of locations only those with a ViewLocations claim should be able to see this");
        }

      
    }


}