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
    public class OrderToCategoryConfiguration : IEntityTypeConfiguration<OrderToCategorys>
    {
        public void Configure(EntityTypeBuilder<OrderToCategorys> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.OrderId, x.CategoryId });

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Orders);
        }
    }
}
