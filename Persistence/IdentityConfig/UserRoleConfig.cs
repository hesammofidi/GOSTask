using Domain.Users;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IdentityConfig
{
    public class RoleConfig : IEntityTypeConfiguration<Roles>
    {
        public static IdentityRole AdminRole = new IdentityRole
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR"
        };

        public static IdentityRole BasicUserRole = new IdentityRole
        {
            Id = Guid.NewGuid().ToString(),
            Name = "User",
            NormalizedName = "USER"
        };

        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            //builder.HasData(AdminRole, BasicUserRole);
           
            builder.HasMany(p => p.SystemRole)
           .WithOne(p => p.Role)
           .HasForeignKey(p => p.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.SystemRoleUser)
          .WithOne(p => p.Role)
          .HasForeignKey(p => p.RoleId)
          .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.SystemRolesPermission)
          .WithOne(p => p.Role)
          .HasForeignKey(p => p.RoleId)
          .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.SystemUserRolePermission)
          .WithOne(p => p.Role)
          .HasForeignKey(p => p.RoleId)
          .OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class UserConfig : IEntityTypeConfiguration<DomainUser>
    {
        public static DomainUser User1 = new DomainUser
        {
            Id = Guid.NewGuid().ToString(),
            Email = "mofidihesam8@gmail.com",
            NormalizedEmail = "MOFIDIHESAM8@GMAIL.COM",
            FullName = "HesamMofidi1",
            UserName = "mofidihesam8@gmail.com",
            NormalizedUserName = "MOFIDIHESAM8@GMAIL.COM",
            PasswordHash = new PasswordHasher<DomainUser>().HashPassword(null, "P@ssw0rd1"),
        };

        public static DomainUser User2 = new DomainUser
        {
            Id = Guid.NewGuid().ToString(),
            Email = "mofidihessam@gmail.com",
            NormalizedEmail = "MOFIDIHESSAM@GMAIL.COM",
            FullName = "HesamMofidi1",
            UserName = "mofidihessam@gmail.com",
            NormalizedUserName = "MOFIDIHESSAM@GMAIL.COM",
            PasswordHash = new PasswordHasher<DomainUser>().HashPassword(null, "P@ssw0rd2"),
        };

        public void Configure(EntityTypeBuilder<DomainUser> builder)
        {
            //builder.HasData(User1, User2);

            builder.HasMany(p => p.SystemRoleUser)
            .WithOne(p => p.users)
            .HasForeignKey(p => p.usersId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.SystemUserPermission)
            .WithOne(p => p.users)
            .HasForeignKey(p => p.usersId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.SystemUserRolePermission)
            .WithOne(p => p.users)
            .HasForeignKey(p => p.usersId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }

    //public class UserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    //{
    //    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    //    {
    //        builder.HasData(
    //            new IdentityUserRole<string>
    //            {
    //                UserId = UserConfig.User1.Id,
    //                RoleId = RoleConfig.AdminRole.Id
    //            },
    //            new IdentityUserRole<string>
    //            {
    //                UserId = UserConfig.User2.Id,
    //                RoleId = RoleConfig.BasicUserRole.Id
    //            }
    //        );
    //    }
    //}

}
