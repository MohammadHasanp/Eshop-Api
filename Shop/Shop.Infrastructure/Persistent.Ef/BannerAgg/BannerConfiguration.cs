using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SiteEntities;


namespace Shop.Infrastructure.Persistent.Ef.BannerAgg
{
    public class BannerConfiguration : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.ToTable("Banners","banner");
            builder.Property(b=>b.Link)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(b => b.ImageName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(b => b.Position)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
