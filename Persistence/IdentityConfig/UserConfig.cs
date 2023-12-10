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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();
            builder.HasData(
               new User
               {
                   Id = "982bb98e-60e7-4eaa-adff-981b432b0a34",
                   Email = "mofidihesam8@gmail.com",
                   NormalizedEmail = "MOFIDIHESAM8@GMAIL.COM",
                   FullName = "HesamMofidi1",
                   UserName = "mofidihesam8@gmail.com",
                   NormalizedUserName = "MOFIDIHESAM8@GMAIL.COM",
                   PasswordHash = hasher.HashPassword(null, "P@ssw0rd1"),
               },
                new User
                {
                    Id = "e4651308-6b8d-4514-8bc4-c4cf3f75a925",
                    Email = "mofidihessam@gmail.com",
                    NormalizedEmail = "MOFIDIHESSAM@GMAIL.COM",
                    FullName = "HesamMofidi1",
                    UserName = "mofidihessam@gmail.com",
                    NormalizedUserName = "MOFIDIHESSAM@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd2"),
                }
               );
        }
    }
}
