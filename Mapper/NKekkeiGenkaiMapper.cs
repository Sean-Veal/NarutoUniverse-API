using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Model.FileEntity;

namespace Naruto_Universe.Mapper;

public static class NKekkeiGenkaiMapper
{
    public static NKekkeiGenkai ToNKekkeiGenkai(this NKekkeiGenkaiFile kekkeiGenkaiFile)
    {
        return new NKekkeiGenkai
        {
            Name = kekkeiGenkaiFile.Name,
            Description = kekkeiGenkaiFile.Description
        };
    }
}