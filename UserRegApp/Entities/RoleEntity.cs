using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace UserRegApp.Entities;

public class RoleEntity
{
    [Key]
   
    public int Id { get; set;}

    [Required]
    [StringLength(50)]
    public string RoleName { get; set; } = null!;

    // Navigation Properties
    public virtual ICollection<ProfileEntity> Profiles { get; set; } = new HashSet<ProfileEntity>();  // 1-N

}
