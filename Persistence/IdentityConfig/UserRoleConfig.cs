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
    public class UserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
               new IdentityUserRole<string>
               {
                   UserId = "982bb98e-60e7-4eaa-adff-981b432b0a34",
                   RoleId = "c02facf2-bb3e-4f0c-b503-1c904b429e22"
               },
                 new IdentityUserRole<string>
                 {
                     UserId = "e4651308-6b8d-4514-8bc4-c4cf3f75a925",
                     RoleId = "30b54ae3-5c16-4ee4-8c87-9200ea8a8901"
                 }
               );
        }
    }
}
