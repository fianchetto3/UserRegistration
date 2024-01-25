using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegApp.Entities;

public class ProfileEntity
{
    [Key]
    [ForeignKey(nameof(UserEntity))]
    public int Id { get; set; }

    [ForeignKey(nameof(RoleEntity))]
    public int RoleId { get; set; }
    

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = null!;

    // Navigaton properties
    public virtual RoleEntity Role { get; set; } = null!; // 1:n

    public virtual UserEntity User { get; set;} = null!; // 1:1 
    
}
