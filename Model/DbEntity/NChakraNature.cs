using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Naruto_Universe.Model.DbEntity;

[Index(nameof(Name), IsUnique = true)]
public class NChakraNature
{
    public int Id { get; set; }
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    [StringLength(5000)]
    public string Description { get; set; } = string.Empty;
    
    // Relationships
    public List<NCharacter> NCharacters { get; set; } = [];
}