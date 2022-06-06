using DAL_Project2.Enums;
using DAL_Project2.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Project2.Seeding
{
    public class RolesSeeder:ISeeder<IdentityRole>
    {

        private readonly List<IdentityRole> _roles = new()
        {
            new IdentityRole(Roles.SuperAdmin.ToString()),
            new IdentityRole(Roles.Admin.ToString()),
            new IdentityRole(Roles.Moderator.ToString()),
            new IdentityRole(Roles.Basic.ToString())
        };


        public void Seed(EntityTypeBuilder<IdentityRole> builder) => builder.HasData(_roles);
    }
}
