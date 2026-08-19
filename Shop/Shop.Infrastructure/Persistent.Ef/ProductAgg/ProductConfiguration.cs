using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.ProductAgg
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "product");

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.ImageName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.Slug)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(100);



            builder.OwnsOne(b => b.SeoData, option =>
            {
                option.Property(p => p.MetaTitle)
                     .HasMaxLength(500)
                     .HasColumnName("MetaDescription");

                option.Property(b => b.MetaTitle)
                    .HasMaxLength(500)
                    .HasColumnName("MetaTitle");

                option.Property(b => b.MetaKeyWords)
                    .HasMaxLength(500)
                    .HasColumnName("MetaKeyWords");

                option.Property(b => b.IndexPage)
                    .HasColumnName("IndexPage");

                option.Property(b => b.Canonical)
                    .HasMaxLength(500)
                    .HasColumnName("Canonical");

                option.Property(b => b.Schema)
                    .HasColumnName("Schema");
            });

            builder.OwnsMany(p => p.Images, option =>
            {
                option.ToTable("Images", "product");
                option.Property(p => p.ImageName)
                .IsRequired()
                .HasMaxLength(200);

                option.Property(p => p.ImageName)
                .IsRequired()
                .HasMaxLength(200);
            });

            builder.OwnsMany(p => p.Specifications, option =>
            {
                option.ToTable("Specifications", "product");


                option.Property(p => p.Key)
                .IsRequired()
                .HasMaxLength(100);

                option.Property(p => p.Value)
                .IsRequired()
                .HasMaxLength(100);
            });

        }
    }
}
