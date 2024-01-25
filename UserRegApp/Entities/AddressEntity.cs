using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace UserRegApp.Entities;

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
