using Microsoft.AspNetCore.Mvc;

namespace TEST_DEV_JRL_20210731.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API");
        }
    }
}
