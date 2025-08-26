using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.UserAgg;

namespace Shop.Infrastructure.Persistent.Ef.UserAgg
{
    internal class UserConfigoration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users","user");
            builder.HasIndex(u => u.PhoneNumber);
            builder.HasIndex(u=>u.Email);

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.AvatarName)
                .HasColumnName("Image")
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.Gender)
                .IsRequired()
                .HasMaxLength(50);

            builder.OwnsMany(u => u.Roles, option =>
            {
                builder.ToTable("Roles","user");
                option.HasIndex(u=>u.UserId);
            });
            builder.OwnsMany(u => u.Wallets, option =>
            {
                builder.ToTable("Wallets", "user");
                option.HasIndex(u=>u.UserId);
                option.Property(u => u.Description)
                .IsRequired(false)
                .HasMaxLength(500);
            });
            builder.OwnsMany(r => r.Addresses, option =>
            {
                builder.ToTable("Addresses", "user");
                option.HasIndex(u => u.UserId);

                option.Property(u => u.Shire)
                    .IsRequired()
                    .HasMaxLength(50);

                option.Property(u => u.City)
                    .IsRequired()
                    .HasMaxLength(50);

                option.Property(u => u.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                option.Property(u => u.PostalAddress)
                    .IsRequired()
                    .HasMaxLength(150);

                option.Property(u => u.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                option.Property(u => u.Family)
                    .IsRequired()
                    .HasMaxLength(100);

                option.Property(u => u.NationalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                option.OwnsOne(u => u.Phone, option =>
                {
                    option.Property(u => u.Value)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("PhoneNumber");
                });
            });
        }
    }
}
