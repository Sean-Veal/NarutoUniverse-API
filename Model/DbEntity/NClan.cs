using System.ComponentModel.DataAnnotations;

namespace Naruto_Universe.Model.DbEntity;
using Microsoft.EntityFrameworkCore;

[Index(nameof(Name), IsUnique = true)]
public class NClan
{
    public int Id { get; set; }
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    [StringLength(5000)]
    public string Description { get; set; } = string.Empty;
    
    // Relationships
    public List<NCharacter> NCharacters { get; set; } = [];
}