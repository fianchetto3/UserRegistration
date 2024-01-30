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
        // unique email&phone

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
            .HasOne(u => u.UserAuth)                                   // User - UserAuth , 1-1 , 
            .WithOne (ua  => ua.User)
            .HasForeignKey<UserAuthEntity>(ua => ua.Id);
        
        modelBuilder.Entity<UserEntity>()                              // User - Address , n-1 , 
            .HasOne(u => u.Address)                                   // 
            .WithMany(a => a.Users)
            .HasForeignKey(u => u.AddressId);

        modelBuilder.Entity<ProfileEntity>()                         // Profile - Role , 1-n , 
            .HasOne(p => p.Role)                                    // 1 profile has 1 role
            .WithMany(r => r.Profiles)                              // 1 role has many profiles
            .HasForeignKey(p => p.RoleId);                          // FK RoleId 

        modelBuilder.Entity<UserActivityEntity>()
            .HasOne(ua => ua.User)
            .WithOne(u => u.UserActivity)
            .HasForeignKey<UserActivityEntity>(u => u.UserId);





    }
}
