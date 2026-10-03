using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.CommentAgg
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments","comment");

            builder.HasIndex(c=>c.UserId);
            builder.HasIndex(c=>c.ProductId);

            builder.Property(c=>c.Text)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
