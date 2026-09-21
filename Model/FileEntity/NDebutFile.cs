using System.Text.Json.Serialization;

namespace Naruto_Universe.Model.FileEntity;

public class NDebutFile
{
    [JsonPropertyName("type")]
    public required string MediaType { get; set; }
    [JsonPropertyName("entryIndex")]
    public required int MediaIndex { get; set; }
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("description")]
    public required string Description { get; set; }
    [JsonPropertyName("arc")]
    public required NArcFile NArcFile { get; set; }

}