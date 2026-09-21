using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Model.FileEntity;

namespace Naruto_Universe.Mapper;

public static class NArcMapper
{
    public static NArc ToNArc(this NArcFile nArcFile)
    {
        return new NArc
        {
            Name = nArcFile.Name,
            Description = nArcFile.Description
        };
    }
}