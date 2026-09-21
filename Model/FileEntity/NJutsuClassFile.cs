using System.Text.Json.Serialization;

namespace Naruto_Universe.Model.FileEntity;

public class NJutsuClassFile
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("description")]
    public required string Description { get; set; }
}