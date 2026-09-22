using Naruto_Universe.Extensions;
using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Model.FileEntity;

namespace Naruto_Universe.Mapper;

public static class NCharacterMapper
{
    public static NCharacter ToNCharacter(this NCharacterFile characterFile, NVillage nVillage, List<NChakraNature> chakraNatures)
    {
        return new NCharacter
        {
            Id = characterFile.Id,
            Name = characterFile.Name,
            Age = characterFile.Age,
            Gender = Enum.Parse<NGender>(characterFile.Gender, true),
            Rank = characterFile.Rank == null ? null : Enum.Parse<NRank>(characterFile.Rank, true),
            Status = Enum.Parse<NStatus>(characterFile.Status, true),
            VillageStatus = characterFile.VillageStatus == null ? null : 
                EnumExtensions.Parse<NVillageStatus>(characterFile.VillageStatus),
            KekkeiGenkai = characterFile.KekkeiGenkai?.ToNKekkeiGenkai(),
            ChakraNatures = chakraNatures,
            Clan = characterFile.Clan?.ToNClan(),
            Village = nVillage
        };
    }
}