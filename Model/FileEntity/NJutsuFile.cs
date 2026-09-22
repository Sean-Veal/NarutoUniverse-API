using System.Text.Json.Serialization;
using Naruto_Universe.Model.DbEntity;

namespace Naruto_Universe.Model.FileEntity;

public class NJutsuFile
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("classification")]
    public required List<NJutsuClassFile> Classifications { get; set; }
    [JsonPropertyName("rank")]
    public string? JutsuRank { get; set; }
    [JsonPropertyName("class")]
    public required List<String> Classes { get; set; }
    [JsonPropertyName("description")]
    public required string Description { get; set; }
    [JsonPropertyName("debut")]
    public required List<NDebutFile> Debuts { get; set; }
}