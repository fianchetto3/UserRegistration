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
    [ForeignKey(nameof(AddressEntity))]
    public int AddressId { get; set; }

    // Navigation prorperties 
    public virtual ProfileEntity Profile { get; set; } = null!;  // 1:1


    public virtual AddressEntity Address { get; set; } = null!; // n:1 

    public virtual UserAuthEntity UserAuth { get; set; } = null!; // 1:1

    public virtual UserActivityEntity UserActivity { get; set; } = null!; //1:1
}


public class UserAuthEntity
{
    [Key]
    [ForeignKey(nameof(UserEntity))]
    public int Id { get; set; }


    [Required]
    [Column(TypeName = "varchar(200)")]
    public string Password { get; set; } = null!;

    // navigation Properties 

    public virtual UserEntity User { get; set; } = null!;

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

    // navigation properties 

    public virtual ICollection<UserEntity> Users { get; set; } = new HashSet<UserEntity>(); // n:1

}


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