using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Model.FileEntity;
using Naruto_Universe.Model.Response;

namespace Naruto_Universe.Mapper;

public static class NClanMapper
{
    public static NClan ToNClan(this NClanFile nClanFile)
    {
        return new NClan
        {
            Name = nClanFile.Name,
            Description = nClanFile.Description
        };
    }

    public static NClanItemResponse ToNClanItemResponse(this NClan clan)
    {
        return new NClanItemResponse
        {
            Id = clan.Id,
            Name = clan.Name,
        };
    }
}