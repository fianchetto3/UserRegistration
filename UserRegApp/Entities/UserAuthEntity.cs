using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegApp.Entities;

public class UserAuthEntity
{
    [Key]
    [ForeignKey(nameof(UserEntity))]
    public int Id { get; set; }


    [Required]
    [Column(TypeName = "varchar(200)")]
    public string? Password { get; set; }

    // navigation Properties 

    public virtual UserEntity User { get; set; } = null!;

}
