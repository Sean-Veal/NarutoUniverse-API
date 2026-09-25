using Microsoft.AspNetCore.Mvc;

namespace Naruto_Universe.Controller;

[ApiController]
[Route("api/[controller]")]
public class JutsuController: ControllerBase
{
    [HttpGet(Name = "GetAllJutsu")]
    public async Task<IActionResult> GetAllJutsu()
    {
        return Ok();
    }
    
    [HttpGet("{id:int}", Name = "GetJutsuById")]
    public async Task<IActionResult> GetJutsuById([FromRoute] int id)
    {
        return Ok();
    }
}