using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Model.FileEntity;
using Naruto_Universe.Model.Response;

namespace Naruto_Universe.Mapper;

public static class NChakraNatureMapper
{
   public static NChakraNature ToNChakraNature(this NChakraNatureFile chakraNatureFile)
   {
      return new NChakraNature
      {
         Name = chakraNatureFile.Name,
         Description = chakraNatureFile.Description,
      };
   }

   public static NChakraNatureItemResponse ToNChakraNatureItemResponse(this NChakraNature chakraNature)
   {
      return new NChakraNatureItemResponse
      {
         Id = chakraNature.Id,
         Name = chakraNature.Name,
      };
   }
}