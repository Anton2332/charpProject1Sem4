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
    public class OffersConfiguration : IEntityTypeConfiguration<Offers>
    {
        public void Configure(EntityTypeBuilder<Offers> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(o => o.User)
                .WithMany(u => u.Offers)
                .HasForeignKey(o => o.PerformerId);

            builder.HasOne(o => o.Order)
                .WithMany(or => or.Offers)
                .HasForeignKey(o => o.OrderId);

            builder.HasIndex(x => new
            {
                x.OrderId,
                x.PerformerId
            }).IsUnique();

            builder.Property(o => o.OfferedPrise).IsRequired();
            builder.Property(o => o.OfferedDay).IsRequired();
            builder.Property(o => o.DescriptionPerformer).IsRequired();
            


        }
    }
}
