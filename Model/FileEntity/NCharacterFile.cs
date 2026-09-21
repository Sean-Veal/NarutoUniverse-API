using System.Text.Json.Serialization;
using Naruto_Universe.Model.DbEntity;

namespace Naruto_Universe.Model.FileEntity;

public class NCharacterFile
{
    [JsonPropertyName("id")]
    public required int Id {  get; set; }
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("age")]
    public required int Age { get; set; }
    [JsonPropertyName("gender")]
    public required string Gender { get; set; }
    [JsonPropertyName("rank")]
    public string? Rank { get; set; }
    [JsonPropertyName("status")]
    public required string Status { get; set; }
    [JsonPropertyName("description")]
    public required string Description { get; set; }
    [JsonPropertyName("village")]
    public NVillageFile? NVillageFile { get; set; }
    [JsonPropertyName("villageStatus")]
    public string? VillageStatus { get; set; }
    [JsonPropertyName("clan")]
    public NClanFile? Clan { get; set; }
    [JsonPropertyName("kekkeiGenkai")]
    public NKekkeiGenkaiFile? KekkeiGenkai { get; set; }
    [JsonPropertyName("debut")]
    public required List<NDebutFile> Debuts { get; set; } 
    [JsonPropertyName("chakraNatures")]
    public required List<NChakraNatureFile> ChakraNatures { get; set; }
    [JsonPropertyName("jutsu")]
    public required List<NJutsuFile> Jutsus { get; set; }
}