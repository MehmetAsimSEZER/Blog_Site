using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityTypeConfiguration
{
    public class AuthorConfiguration : BaseEntityConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(25);
            builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(25);
            builder.Property(x => x.Resume).IsRequired(true);
            builder.Property(x => x.Phone).IsRequired(true).HasMaxLength(11);
            base.Configure(builder);
        }
    }
}
