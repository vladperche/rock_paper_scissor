
using Microsoft.AspNetCore.Mvc;
using RockPaperScissor.Entities.Enums;
using RockPaperScissor.Entities.Models;

namespace RockPaperScissor.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExampleController : ControllerBase
{
    [HttpGet("Rock")]
    public ActionResult GetRock()
    {
        var move = new PlayerMove(ValidMove.Rock);
        var name = move.GetMove();
        var s = name.ConvertToString();

        return Ok(s);
    }
}