using Domain.Common;
using Domain.Primitives.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IdentityConfig.BaseConfigs
{
    public class BaseIdentityConfiguration<TEntity, TId> :
        IEntityTypeConfiguration<TEntity> where TEntity :
        BaseDomainEntity<TId>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
            //builder.Property(e => e.Title).IsRequired();
            builder.HasIndex(p=>p.Title).IsUnique();
        }
    }
}
