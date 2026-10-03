using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SiteEntities;

namespace Shop.Infrastructure.Persistent.Ef.SliderAgg
{
    public class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.ToTable("Sliders","slider");
            builder.Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(s => s.Link)
               .IsRequired()
               .HasMaxLength(200);

            builder.Property(s => s.ImageName)
               .IsRequired()
               .HasMaxLength(1500);

        }
    }
}
