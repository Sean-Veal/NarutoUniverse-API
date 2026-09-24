using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Repository;
using Naruto_Universe.Util;
using ApplicationException = Naruto_Universe.Exceptions.ApplicationException;

namespace Naruto_Universe.Service;

public class CharacterService( 
    ILogger<CharacterService> logger,
    ICharacterRepository repo
    ): ICharacterService
{ 
    public async Task<NCharacter> GetByIdAsync(int id)
    {
        logger.LogInformation("Getting character with id {id}", id);
        var result = await repo.GetByIdAsync(id);
        if (result.IsSuccess) return result.Value;
        throw new ApplicationException(result.Error);
    }
}