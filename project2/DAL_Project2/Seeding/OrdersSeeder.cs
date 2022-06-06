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
    public class OrdersSeeder : ISeeder<Orders>
    {

        private readonly List<Orders> _orders = new()
        {

        };

        public void Seed(EntityTypeBuilder<Orders> builder) => builder.HasData(_orders);
    }
}
