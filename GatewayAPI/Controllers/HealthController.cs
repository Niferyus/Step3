using Microsoft.AspNetCore.Mvc;

namespace GatewayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Status = "Gateway is running", Timestamp = DateTime.UtcNow });
        }

        [HttpGet("check")]
        public IActionResult HealthCheck()
        {
            return Ok(new
            {
                Status = "Healthy",
                Gateway = "Running",
                Version = "1.0.0",
                Timestamp = DateTime.UtcNow
            });
        }
    }
}
