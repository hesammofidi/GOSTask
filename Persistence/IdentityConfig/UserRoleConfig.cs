using Domain.Users;
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
    public class RoleConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.HasData(
                new Roles
                {
                    Id = "9845f909-799c-45fd-9158-58c1336ffddc",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new Roles
                {
                    Id = "cb275765-1cac-4652-a03f-f8871dd575d1",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
                );
        }
    }


    public class UserConfiguration : IEntityTypeConfiguration<DomainUser>
    {
        public void Configure(EntityTypeBuilder<DomainUser> builder)
        {
            var hasher = new PasswordHasher<DomainUser>();

            builder.HasData(
                new DomainUser
                {
                    Id = "05446344-f9cc-4566-bd2c-36791b4e28ed",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    FullName = "Admin Adminian",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                },
                 new DomainUser
                 {
                     Id = "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                     Email = "user@localhost.com",
                     NormalizedEmail = "USER@LOCALHOST.COM",
                     FullName = "System User",
                     UserName = "user@localhost.com",
                     NormalizedUserName = "USER@LOCALHOST.COM",
                     PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                     EmailConfirmed = true,
                 }
                );
        }
    }

    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "05446344-f9cc-4566-bd2c-36791b4e28ed",
                    RoleId = "cb275765-1cac-4652-a03f-f8871dd575d1"
                },
                  new IdentityUserRole<string>
                  {
                      UserId = "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                      RoleId = "9845f909-799c-45fd-9158-58c1336ffddc"
                  }
                );
        }
    }

}
