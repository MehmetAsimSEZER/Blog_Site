using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityTypeConfiguration
{
    public class ContactConfiguration : BaseEntityConfiguration<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(25);
            builder.Property(x => x.Email).IsRequired(true);
            builder.Property(x => x.Phone).IsRequired(true).HasMaxLength(11);
            builder.Property(x => x.Message).IsRequired(true);
            base.Configure(builder);
        }
    }
}
