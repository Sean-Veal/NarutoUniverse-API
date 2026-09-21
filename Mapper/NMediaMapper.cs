using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Model.FileEntity;

namespace Naruto_Universe.Mapper;

public static class NMediaMapper
{
    public static NMedia ToNMedia(this NDebutFile nDebutFile, NArc nArc)
    {
        return new NMedia
        {
            EntryIndex = nDebutFile.MediaIndex,
            Name = nDebutFile.Name,
            Description = nDebutFile.Description,
            MediaType = Enum.Parse<NMediaType>(nDebutFile.MediaType, true),
            Arc = nArc,
        };
    }
}