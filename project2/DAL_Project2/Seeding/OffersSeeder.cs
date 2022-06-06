using DAL_Project2.Entitys;
using DAL_Project2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Project2.Seeding
{
    public class OffersSeeder : ISeeder<Offers>
    {
        private readonly List<Offers> _offers = new()
        {

        };

        public void Seed(EntityTypeBuilder<Offers> builder) => builder.HasData(_offers);
    }
}
