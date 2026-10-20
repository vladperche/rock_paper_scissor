
using Microsoft.AspNetCore.Mvc;

namespace RockPaperScissor.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet("check")]
    public ActionResult Get()
    {
        return Ok("Running!");
    }
}
