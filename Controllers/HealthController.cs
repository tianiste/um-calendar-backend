using Microsoft.AspNetCore.Mvc;
using UmCalendar.DTOs;
using UmCalendar.Models;
using UmCalendar.Services;
using NSwag.Annotations;
namespace UmCalendar.Controllers
{

    [ApiController]
    [Route("health")]
    [OpenApiTag("Health")]
    public class HealthController : ControllerBase
    {
        [HttpGet("/health")]
        public IActionResult GetHealth()
        {
            return Ok(new { status = "healthy" });
        }
    }
}