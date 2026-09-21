using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Model.FileEntity;

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
}