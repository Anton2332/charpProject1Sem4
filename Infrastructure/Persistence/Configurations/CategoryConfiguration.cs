using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Categorys>
    {
        public void Configure(EntityTypeBuilder<Categorys> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasKey(c => c.Id);

        }
    }
}
