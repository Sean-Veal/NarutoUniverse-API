using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Repository;
using Naruto_Universe.Util;
using ApplicationException = Naruto_Universe.Exception.ApplicationException;

namespace Naruto_Universe.Service;

public class CharacterService: ICharacterService
{
    private readonly ICharacterRepository _repo;
    private readonly ILogger<CharacterService> _logger;
    
    public CharacterService(
        ILogger<CharacterService> logger,
        ICharacterRepository characterRepository
    )
    {
        _logger = logger;
        _repo = characterRepository;
    }
    
    
    public async Task<NCharacter> GetByIdAsync(int id)
    {
        var result = await _repo.GetByIdAsync(id);
        if (result.IsFailure)
        {
            throw new ApplicationException(result.Error);
        }
        
        return result.Value;
    }
}