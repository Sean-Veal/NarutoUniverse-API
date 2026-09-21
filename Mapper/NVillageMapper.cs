using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Model.FileEntity;

namespace Naruto_Universe.Mapper;

public static class NVillageMapper
{
    public static NVillage ToNVillage(this NVillageFile nVillageFile, NCountry country)
    {
        return new NVillage
        {
            Name = nVillageFile.Name,
            Description = nVillageFile.Description,
            Country =  country
        };
    }
}