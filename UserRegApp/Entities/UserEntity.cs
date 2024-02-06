using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegApp.Entities;

public class UserEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Email { get; set; } = null!;


    [Required]
    [StringLength(15)]
    public string Phone { get; set; } = null!;

    [Required]
   
    public int AddressId { get; set; }

    // Navigation prorperties 
    public virtual ProfileEntity Profile { get; set; } = null!;  // 1:1


    public virtual AddressEntity Address { get; set; } = null!; // n:1 

    public virtual UserAuthEntity UserAuth { get; set; } = null!; // 1:1

    public virtual UserActivityEntity UserActivity { get; set; } = null!; //1:1
}
