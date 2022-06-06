using DAL_Project2.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Project2.Configuration
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.customerId);

            builder.Property(o => o.customerId).IsRequired();
            builder.Property(o=>o.Name).IsRequired();
            builder.Property(o=>o.Description).IsRequired();
            builder.Property(o => o.DateOrder).IsRequired();

            builder.Property(o => o.Name).HasMaxLength(100);
        }
    }
}
