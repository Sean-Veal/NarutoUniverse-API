using Microsoft.EntityFrameworkCore;
using Naruto_Universe.Data;
using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Util;

namespace Naruto_Universe.Repository;

public class CharacterRepository(AppDbContext dbContext): ICharacterRepository
{
    public async Task<Result<NCharacter>> GetByIdAsync(int id)
    {
        var character = await dbContext
            .NCharacters
            .Include(c => c.KekkeiGenkai)
            .Include(c => c.Jutsus)
            .Include(c => c.ChakraNatures)
            .Include(c => c.Clan)
            .Include(c => c.Village)
            .Include(c => c.MediaList)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (character is null) return new Error(404, "Character.NotFound", $"Character not found with id {id}");
        return character;
    }
}