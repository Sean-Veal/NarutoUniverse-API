using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Util;

namespace Naruto_Universe.Repository;

public interface ICharacterRepository
{
    Task<Result<NCharacter>> GetByIdAsync(int id);
}