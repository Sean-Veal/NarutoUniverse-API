using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Model.Response;

namespace Naruto_Universe.Service;

public interface ICharacterService
{
    Task<NCharacterResponse> GetByIdAsync(int id);
}