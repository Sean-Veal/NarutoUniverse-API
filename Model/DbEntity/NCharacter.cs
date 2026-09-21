using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Naruto_Universe.Model.DbEntity;

[Index(nameof(Name),  IsUnique = true)]
public class NCharacter
{
    public int Id { get; init; }
    [StringLength(1000)]
    public string Name { get; init; } = string.Empty;
    public int Age { get; init; }
    public NGender Gender { get; init; }
    public NRank? Rank { get; init; }
    public NStatus Status { get; init; }
    public NVillageStatus? VillageStatus { get; init; }
    
    // Relationships
    public NKekkeiGenkai? KekkeiGenkai { get; init; }
    public List<NJutsu> Jutsus { get; init; } = [];
    public List<NChakraNature> ChakraNatures { get; init; } = [];
    public NClan? Clan { get; init; }
    public NVillage? Village { get; init; }
    public List<NMedia> MediaList { get; set; } = [];
}