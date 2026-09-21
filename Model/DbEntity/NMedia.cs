using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Naruto_Universe.Model.DbEntity;

[Index(nameof(EntryIndex), nameof(MediaType), IsUnique = true)]
public class NMedia
{
    public int Id { get; init; }
    public int EntryIndex { get; init; }
    [StringLength(100)]
    public string Name { get; init; } = string.Empty;
    [StringLength(5000)]
    public string Description { get; init; } = string.Empty;
    public NMediaType MediaType { get; init; }
    // Relationships
    public int NArcId { get; set; }
    public required NArc Arc { get; set; }
    public List<NCharacter> Characters { get; init; } = [];
    public List<NJutsu> Jutsus { get; init; } = [];
}