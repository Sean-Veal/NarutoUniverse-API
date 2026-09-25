using Naruto_Universe.Extensions;
using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Model.FileEntity;
using Naruto_Universe.Model.Response;

namespace Naruto_Universe.Mapper;

public static class NJutsuMapper
{
    public static NJutsu ToNJutsu(this NJutsuFile nJutsuFile)
    {
        return new NJutsu
        {
            Name = nJutsuFile.Name,
            Description = nJutsuFile.Description,
            Rank = nJutsuFile.JutsuRank == null ? null : EnumExtensions.Parse<NJutsuRank>(nJutsuFile.JutsuRank),
            Classes = nJutsuFile.Classes.Select(c => Enum.Parse<NJutsuClass>(c)).ToList()
        };
    }

    public static NJutsuItemResponse ToNJutsuItemResponse(this NJutsu jutsu)
    {
        return new NJutsuItemResponse
        {
            Id = jutsu.Id,
            Name = jutsu.Name
        };
    }
}