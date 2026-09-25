using Microsoft.AspNetCore.Mvc;

namespace Naruto_Universe.Controller;

[ApiController]
[Route("api/[controller]")]
public class ChakraNaturesController: ControllerBase
{
    [HttpGet(Name = "GetAllChakraNatures")]
    public async Task<IActionResult> GetAllChakraNatures()
    {
        return Ok();
    }
    
    [HttpGet("{id:int}",  Name = "GetChakraNatureById")]
    public async Task<IActionResult> GetChakraNatureById([FromRoute] int id)
    {
        return Ok();
    }
}