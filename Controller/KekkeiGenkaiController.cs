using Microsoft.AspNetCore.Mvc;

namespace Naruto_Universe.Controller;

[ApiController]
[Route("api/[controller]")]
public class KekkeiGenkaiController: ControllerBase
{
    [HttpGet("{id:int}", Name = "GetKekkeiGenkaiById")]
    public async Task<IActionResult> GetKekkeiGenkaiById([FromRoute] int id)
    {
        return Ok();
    }
    
    [HttpGet(Name = "GetAllKekkeiGenkai")]
    public async Task<IActionResult> GetAllKekkeiGenkai()
    {
        return Ok();
    }
}