using System.Text.Json.Serialization;

namespace Naruto_Universe.Model.FileEntity;

public class NChakraNatureFile
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("description")]
    public required string Description { get; set; }
}