using Naruto_Universe.Extensions;

namespace Naruto_Universe.Model.DbEntity;

public enum NVillageStatus
{
    [EnumExtensions.StringValue("Loyal")]
    LOYAL,
    [EnumExtensions.StringValue("Missing-nin")]
    MISSING_NIN, 
    [EnumExtensions.StringValue("Rouge")]
    ROUGE, 
    [EnumExtensions.StringValue("Exiled")]
    EXILED
}