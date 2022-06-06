using DAL_Project2.Entitys;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Project2.Interfaces
{
    public interface IUnitOfWork
    {
        public IOrdersRepository OrdersRepository { get; }
        public IOffersRepository OffersRepository { get; }
        public UserManager<User> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }
        public SignInManager<User> SignInManager { get; }

        public DBContext DBContext { get; }

        Task SaveChangesAsync();
    }
}
