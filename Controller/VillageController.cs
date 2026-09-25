using Microsoft.AspNetCore.Mvc;

namespace Naruto_Universe.Controller;

[ApiController]
[Route("api/villages")]
public class VillageController: ControllerBase
{
    [HttpGet(Name = "GetAllVillages")]
    public async Task<IActionResult> GetAllVillages()
    {
        return Ok();
    }
    
    [HttpGet("{id:int}", Name = "GetVillageById")]
    public async Task<IActionResult> GetVillageById([FromRoute] int id)
    {
        return Ok();
    }
}