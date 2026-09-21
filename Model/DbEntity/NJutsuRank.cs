using Naruto_Universe.Extensions;

namespace Naruto_Universe.Model.DbEntity;

public enum NJutsuRank
{
    [EnumExtensions.StringValue("S-Rank")]
    S,
    [EnumExtensions.StringValue("A-Rank")]
    A, 
    [EnumExtensions.StringValue("B-Rank")]
    B, 
    [EnumExtensions.StringValue("C-Rank")]
    C,
    [EnumExtensions.StringValue("D-Rank")]
    D
}