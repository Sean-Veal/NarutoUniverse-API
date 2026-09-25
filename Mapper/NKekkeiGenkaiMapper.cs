using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Model.FileEntity;
using Naruto_Universe.Model.Response;

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

    public static NKekkeiGenkaiItemResponse ToKekkeiGenkaiItemResponse(this NKekkeiGenkai kekkeiGenkai)
    {
        return new NKekkeiGenkaiItemResponse
        {
            Id = kekkeiGenkai.Id,
            Name = kekkeiGenkai.Name,
        };
    }
}