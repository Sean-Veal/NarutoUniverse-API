using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Model.FileEntity;
using Naruto_Universe.Model.Response;

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

    public static NVillageItemResponse ToNVillageItemResponse(this NVillage village)
    {
        return new NVillageItemResponse
        {
            Id = village.Id,
            Name = village.Name,
        };
    }
}