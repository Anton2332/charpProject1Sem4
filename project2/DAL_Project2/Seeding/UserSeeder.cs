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
    public class UserSeeder : ISeeder<User>
    {

        private readonly List<User> _users = new()
        {
            new User
            {
                UserName ="superadmin",
                Email = "superadmin@gmail.com",
                FirstName = "super",
                LastName ="admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            }

        };
        public void Seed(EntityTypeBuilder<User> builder) => builder.HasData(_users);
    }
}
