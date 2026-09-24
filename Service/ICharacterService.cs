using Naruto_Universe.Model.DbEntity;

namespace Naruto_Universe.Service;

public interface ICharacterService
{
    Task<NCharacter> GetByIdAsync(int id);
}