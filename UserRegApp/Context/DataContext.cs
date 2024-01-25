using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using UserRegApp.Entities;

namespace UserRegApp.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public virtual DbSet<UserEntity> Users { get; set; }

    public virtual DbSet<AddressEntity> Address { get; set; }

    public virtual DbSet<UserAuthEntity> UserAuth { get; set; }

    public virtual DbSet<UserActivityEntity> UserActivity { get; set; }

    public virtual DbSet<ProfileEntity> Profile { get; set; }

    public virtual DbSet<RoleEntity> Role { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // unqiue email&phone

        modelBuilder.Entity<UserEntity>()  
            .HasIndex(x => x.Email)
            .IsUnique();

        modelBuilder.Entity<UserEntity>()
            .HasIndex(x => x.Phone)
            .IsUnique();

        // key relations

        modelBuilder.Entity<UserEntity>()
            .HasOne(u => u.Profile) 
            .WithOne(p => p.User)                                       // User - Profile  , 1-1  , 
            .HasForeignKey<ProfileEntity>(p => p.Id);

        modelBuilder.Entity<UserEntity>()
            .HasOne(u => u.UserAuth)
            .WithOne (ua  => ua.User)
            .HasForeignKey<UserAuthEntity>(ua => ua.Id);


    }
}
