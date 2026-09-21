using Naruto_Universe.Model.FileEntity;

namespace Naruto_Universe.Service.Misc;

public interface IDBSaveService
{
    Task SaveData(NCharacterFile characterFile, List<NJutsuFile> jutsuFiles);
}