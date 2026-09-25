using Microsoft.AspNetCore.Mvc;
using Naruto_Universe.Service;

namespace Naruto_Universe.Controller;

[ApiController]
[Route("api/characters")]
public class CharacterController(ICharacterService characterService): ControllerBase
{
    [HttpGet(Name = "GetAllCharacters")]
    public async Task<IActionResult> GetAllCharacters()
    {
        return Ok();
    }

    [HttpGet("{id:int}",Name = "GetCharacterById")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var character = await characterService.GetByIdAsync(id);
        return Ok(character);
    }
}