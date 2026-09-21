using Naruto_Universe.Model.DbEntity;
using Naruto_Universe.Model.FileEntity;

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
}