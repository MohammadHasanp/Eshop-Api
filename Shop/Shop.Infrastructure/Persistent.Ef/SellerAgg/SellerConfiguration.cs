using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SellerAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg
{
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.ToTable("Sellers","seller");
            builder.HasIndex(b => b.NationalCode).IsUnique();

            builder.Property(s=>s.ShopName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.NationalCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(s => s.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.OwnsMany(s => s.SellerInventories, option =>
            {
                option.ToTable("Inventories", "seller");
                option.HasKey(s => s.Id);
                option.HasIndex(s=>s.ProductId);
                option.HasIndex(s=>s.SellerId);

            });

        }
    }
}
