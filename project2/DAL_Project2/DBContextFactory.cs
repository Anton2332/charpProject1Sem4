using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Project2
{
    public class DBContextFactory: IDesignTimeDbContextFactory<DBContext>
    {
        public DBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=project_csharp_01_2;Trusted_Connection=True;");

            return new DBContext(optionsBuilder.Options);
        }
    }
}
