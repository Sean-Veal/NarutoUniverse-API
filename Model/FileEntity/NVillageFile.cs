using System.Text.Json.Serialization;

namespace Naruto_Universe.Model.FileEntity;

public class NVillageFile
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("description")]
    public required string Description { get; set; }
    [JsonPropertyName("country")]
    public required NCountryFile NCountryFile { get; set; }
}