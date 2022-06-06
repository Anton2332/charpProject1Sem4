using DAL_Project2.Configuration;
using DAL_Project2.Entitys;
using DAL_Project2.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL_Project2
{
    public class DBContext:IdentityDbContext<User>
    {

        public DbSet<Offers> Offers { get; set; }
        public DbSet<Orders> Orders { get; set; }


        public DBContext() : base()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                new UserSeeder().Seed(entity);
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable("Role");
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                new RolesSeeder().Seed(entity);
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });


            modelBuilder.ApplyConfiguration(new OffersConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersConfiguration());

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=project_csharp_01_2;Trusted_Connection=True;");
        //}

    }
}
    