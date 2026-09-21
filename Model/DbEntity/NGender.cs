using Naruto_Universe.Extensions;

namespace Naruto_Universe.Model.DbEntity;

public enum NGender
{
    [EnumExtensions.StringValue("Male")]
    M,
    [EnumExtensions.StringValue("Female")]
    F
}