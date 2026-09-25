using Microsoft.AspNetCore.Mvc;

namespace Naruto_Universe.Controller;

[ApiController]
[Route("api/[controller]")]
public class MediaController: ControllerBase
{
    [HttpGet(Name = "GetMedia")]
    public async Task<IActionResult> GetAllMedia()
    {
        return Ok();
    }
    
    [HttpGet("{id:int}", Name = "GetMediaById")]
    public async Task<IActionResult> GetMediaById([FromRoute] int id)
    {
        return Ok();
    }
}