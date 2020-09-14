using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aletheia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet("unprotected/")]
        [AllowAnonymous]
        public IActionResult GetAnonymous()
        {
            return Ok("Hello, world!");
        }

        [HttpGet("protected/")]
        [Authorize]
        public IActionResult GetAuthorized()
        {
            return Ok("Hello, protected world!");
        }
    }
}
