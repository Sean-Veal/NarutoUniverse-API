using Naruto_Universe.Model.DbEntity;

namespace Naruto_Universe.Model.Response;

public class NCharacterResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public NVillageItemResponse? Village { get; set; }
    public string? VillageStatus { get; set; }
    public NKekkeiGenkaiItemResponse? KekkeiGenkai { get; set; }
    public List<NJutsuItemResponse> Jutsu { get; set; } = [];
    public List<NChakraNatureItemResponse> ChakraNatures { get; set; } = [];
    public NClanItemResponse? Clan { get; set; }
    public List<NMediaItemResponse> Debut { get; set; } = [];

}