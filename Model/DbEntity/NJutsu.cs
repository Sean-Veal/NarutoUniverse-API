using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Naruto_Universe.Model.DbEntity;

[Index(nameof(Name), IsUnique = true)]
public class NJutsu
{
    public int Id { get; init; }
    [StringLength(100)]
    public string Name { get; init; } = string.Empty;
    [StringLength(5000)]
    public string Description { get; init; } = string.Empty;
    public NJutsuRank? Rank { get; init; }
    public List<NJutsuClass> Classes { get; init; } = [];
    public int? CreatorId { get; set; }
    public List<NJutsuClassification> JutsuClassifications { get; set; } = [];
    
    // Relationships
    public List<NMedia> MediaList { get; set; } = [];
    public List<NCharacter> Characters { get; set; } = [];
}