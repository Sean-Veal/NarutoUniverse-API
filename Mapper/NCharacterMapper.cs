using Naruto_Universe.Extensions;
using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Model.FileEntity;
using Naruto_Universe.Model.Response;

namespace Naruto_Universe.Mapper;

public static class NCharacterMapper
{
    public static NCharacter ToNCharacter(this NCharacterFile characterFile, NVillage nVillage, List<NChakraNature> chakraNatures)
    {
        return new NCharacter
        {
            Id = characterFile.Id,
            Name = characterFile.Name,
            Description = characterFile.Description,
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

    public static NCharacterResponse ToNCharacterResponse(this NCharacter character)
    {
        return new NCharacterResponse
        {
            Id = character.Id,
            Name = character.Name,
            Age = character.Age,
            Gender = character.Gender.GetStringValue(),
            Status = character.Status.GetStringValue(),
            Description = character.Description,
            Village = character.Village?.ToNVillageItemResponse(),
            VillageStatus = character.VillageStatus?.GetStringValue(),
            KekkeiGenkai = character.KekkeiGenkai?.ToKekkeiGenkaiItemResponse(),
            Jutsu = character.Jutsus.Select(j => j.ToNJutsuItemResponse()).ToList(),
            ChakraNatures = character.ChakraNatures.Select(c => c.ToNChakraNatureItemResponse()).ToList(),
            Clan = character.Clan?.ToNClanItemResponse(),
            Debut = character.MediaList.Select(m => m.ToNMediaItemResponse()).ToList()
        };
    }
}