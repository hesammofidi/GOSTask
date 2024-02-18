using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.IdentityConfig.BaseConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IdentityConfig
{
    public class SystemsConfig : BaseIdentityConfiguration<Systems, int>
    {
        public override void Configure(EntityTypeBuilder<Systems> builder)
        {
            base.Configure(builder);
            builder.HasMany(p => p.SystemRole)
                .WithOne(p => p.System)
                .HasForeignKey(p => p.systemId).OnDelete(DeleteBehavior.Restrict);
            // Add other properties and relationships here...
            builder.HasMany(p => p.SystemPermission)
            .WithOne(p => p.System)
            .HasForeignKey(p => p.systemId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.SystemRoleUser)
            .WithOne(p => p.System)
            .HasForeignKey(p => p.systemId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.SystemRolesPermission)
            .WithOne(p => p.System)
            .HasForeignKey(p => p.systemId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.SystemUserPermission)
           .WithOne(p => p.System)
           .HasForeignKey(p => p.systemId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.SystemUserRolePermission)
           .WithOne(p => p.System)
           .HasForeignKey(p => p.systemId).OnDelete(DeleteBehavior.Restrict);

        }
    }

    public class PermissionConfigs : BaseIdentityConfiguration<Permisions, int>
    {
        public override void Configure(EntityTypeBuilder<Permisions> builder)
        {
            base.Configure(builder);

            builder.HasMany(p => p.SystemPermision)
           .WithOne(p => p.Permission)
           .HasForeignKey(p => p.PermissionId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.SystemUserPermission)
            .WithOne(p => p.Permission)
            .HasForeignKey(p => p.PermissionId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.SystemRolesPermission)
            .WithOne(p => p.Permission)
            .HasForeignKey(p => p.PermissionId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.SystemUserRolePermission)
            .WithOne(p => p.Permission)
            .HasForeignKey(p => p.PermissionId).OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class SystemRolesConfig : BaseIdentityConfiguration<SystemRoles, int>
    {
        public override void Configure(EntityTypeBuilder<SystemRoles> builder)
        {
            base.Configure(builder);
            builder.HasIndex(sr => new { sr.RoleId, sr.systemId })
                .IsUnique();

            builder.HasOne(sr => sr.Role)
                .WithMany()
                .HasForeignKey(sr => sr.RoleId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sr => sr.System)
                .WithMany()
                .HasForeignKey(sr => sr.systemId).OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class SystemPermissionConfig : BaseIdentityConfiguration<SystemPermission, int>
    {
        public override void Configure(EntityTypeBuilder<SystemPermission> builder)
        {
            base.Configure(builder);
            builder.HasIndex(sp => new { sp.PermissionId, sp.systemId })
                .IsUnique();

            builder.HasOne(sr => sr.Permission)
                .WithMany()
                .HasForeignKey(sr => sr.PermissionId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sr => sr.System)
                .WithMany()
                .HasForeignKey(sr => sr.systemId).OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class SystemRolesPermissionConfigs : BaseIdentityConfiguration<SystemRolesPermission, int>
    {
        public override void Configure(EntityTypeBuilder<SystemRolesPermission> builder)
        {
            base.Configure(builder);
            builder.HasIndex(sp => new { sp.PermissionId, sp.systemId, sp.RoleId })
               .IsUnique();

            builder.HasOne(sr => sr.Permission)
                .WithMany()
                .HasForeignKey(sr => sr.PermissionId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sr => sr.System)
                .WithMany()
                .HasForeignKey(sr => sr.systemId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sr => sr.Role)
                .WithMany()
                .HasForeignKey(sr => sr.RoleId).OnDelete(DeleteBehavior.Restrict);

        }
    }

    public class SystemUserPermissionConfigs : BaseIdentityConfiguration<SystemUserPermission, int>
    {
        public override void Configure(EntityTypeBuilder<SystemUserPermission> builder)
        {
            base.Configure(builder);
            builder.HasIndex(sp => new { sp.PermissionId, sp.systemId, sp.usersId })
               .IsUnique();

            builder.HasOne(sr => sr.Permission)
                .WithMany()
                .HasForeignKey(sr => sr.PermissionId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sr => sr.System)
                .WithMany()
                .HasForeignKey(sr => sr.systemId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sr => sr.users)
                .WithMany()
                .HasForeignKey(sr => sr.usersId).OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class SystemRolesUserConfigs : BaseIdentityConfiguration<SystemRoleUser, int>
    {
        public override void Configure(EntityTypeBuilder<SystemRoleUser> builder)
        {
            base.Configure(builder);
            
            builder.HasIndex(sp => new {  sp.systemId, sp.RoleId, sp.usersId })
               .IsUnique();

            builder.HasOne(sr => sr.System)
                .WithMany()
                .HasForeignKey(sr => sr.systemId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sr => sr.Role)
                .WithMany()
                .HasForeignKey(sr => sr.RoleId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sr => sr.users)
                .WithMany()
                .HasForeignKey(sr => sr.usersId).OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class SystemUserRolePermissionConfig : BaseIdentityConfiguration<SystemUserRolePermission, int>
    {
        public override void Configure(EntityTypeBuilder<SystemUserRolePermission> builder)
        {
            base.Configure(builder);
            builder.HasIndex(sp => new { sp.PermissionId, sp.systemId, sp.RoleId, sp.usersId })
               .IsUnique();

            builder.HasOne(sr => sr.Permission)
                .WithMany()
                .HasForeignKey(sr => sr.PermissionId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sr => sr.System)
                .WithMany()
                .HasForeignKey(sr => sr.systemId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sr => sr.Role)
                .WithMany()
                .HasForeignKey(sr => sr.RoleId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sr => sr.users)
                .WithMany()
                .HasForeignKey(sr => sr.usersId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
