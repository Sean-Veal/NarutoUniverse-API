using Naruto_Universe.Extensions;
using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Model.FileEntity;

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
}