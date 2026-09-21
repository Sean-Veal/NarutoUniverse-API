using Naruto_Universe.Extensions;

namespace Naruto_Universe.Model.DbEntity;

public enum NMediaType
{
    [EnumExtensions.StringValue("Manga")]
    MANGA,
    [EnumExtensions.StringValue("Anime")]
    ANIME
}