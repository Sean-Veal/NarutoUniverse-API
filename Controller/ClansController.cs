using Microsoft.AspNetCore.Mvc;

namespace Naruto_Universe.Controller;

[ApiController]
[Route("api/[controller]")]
public class ClansController: ControllerBase
{
    [HttpGet(Name = "GetAllClans")]
    public async Task<IActionResult> GetAllClans()
    {
        return Ok();
    }
    
    [HttpGet("{id:int}",  Name = "GetClanById")]
    public async Task<IActionResult> GetClanById([FromRoute] int id)
    {
        return Ok();
    }
}