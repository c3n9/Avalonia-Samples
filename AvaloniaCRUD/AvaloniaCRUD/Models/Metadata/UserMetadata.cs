using System.ComponentModel.DataAnnotations;

namespace AvaloniaCRUD.Models.Metadata;

public class UserMetadata
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    public int RoleId { get; set; }
}