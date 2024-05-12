using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.IdentityConfig.BaseConfigs;

namespace Persistence.IdentityConfig
{
    public class OrdersConfig : BaseIdentityConfiguration<Orders, int>
    {
        public override void Configure(EntityTypeBuilder<Orders> builder)
        {
            base.Configure(builder);
            builder.HasMany(p => p.OrderProduct)
                .WithOne(p => p.Order)
                .HasForeignKey(p => p.OrderId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sr => sr.People)
                 .WithMany()
                 .HasForeignKey(sr => sr.PeopleId).OnDelete(DeleteBehavior.Restrict);

        }
    }

    public class ProductsConfigs : BaseIdentityConfiguration<Products, int>
    {
        public override void Configure(EntityTypeBuilder<Products> builder)
        {
            base.Configure(builder);

            builder.HasMany(p => p.OrderProducts)
           .WithOne(p => p.product)
           .HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);

         
        }
    }

    public class PeopleConfigs : BaseIdentityConfiguration<People, int>
    {
        public override void Configure(EntityTypeBuilder<People> builder)
        {
            base.Configure(builder);

            builder.HasMany(p => p.Order)
           .WithOne(p => p.People)
           .HasForeignKey(p => p.PeopleId).OnDelete(DeleteBehavior.Restrict);


        }
    }
    public class OrderProductConfig : BaseIdentityConfiguration<OrderProduct, int>
    {
        public override void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            base.Configure(builder);
            builder.HasIndex(sr => new { sr.OrderId, sr.ProductId })
                .IsUnique();

            builder.HasOne(sr => sr.Order)
                .WithMany()
                .HasForeignKey(sr => sr.OrderId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sr => sr.product)
                .WithMany()
                .HasForeignKey(sr => sr.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }

    
}
