using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegApp.Entities;

public class UserActivityEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey (nameof(UserEntity))]
    public int UserId { get; set; }

  
    [Required]
    [StringLength(100)]
    public DateTime LastLoggedIn { get; set; } 

    //Navigation properites 

    public virtual UserEntity User { get; set; } = null!;

}