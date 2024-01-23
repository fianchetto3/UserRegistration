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
    [ForeignKey (nameof(AddressEntity))]
    public int AddressId { get; set; } 

}
public class UserAuthEntity
{
    [Key]
    public int UserId { get; set; }


    [Required]
    [Column(TypeName = "varchar(200)")]
    public string Password { get; set; } = null!;

}
public class AddressEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string City { get; set; } = null!;
    [Required]
    [StringLength(15)]
    public string PostalCode { get; set; } = null!;
    [Required]
    [StringLength(100)]
    public string Street { get; set; } = null!;

}
public class ProfileEntity
{
    [Key]
    [ForeignKey(nameof(UserEntity))]
    public int Id { get; set; }

    [Required]
    public int RoleId { get; set; }
    public virtual RoleEntity Role { get; set; } = null!; 

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

}
public class RoleEntity
{
    public int Id { get; set;}
    
  
}