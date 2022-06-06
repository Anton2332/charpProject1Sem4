using DAL_Project2.Entitys;
using DAL_Project2.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Project2
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DBContext _dbContext;

        public IOrdersRepository OrdersRepository { get; }
        public IOffersRepository OffersRepository { get; }

        public UnitOfWork(DBContext dbContext,IOrdersRepository ordersRepository,IOffersRepository offersRepository,UserManager<User> userManager,RoleManager<IdentityRole> roleManager,SignInManager<User> signInManager) {
            _dbContext = dbContext;
            OrdersRepository = ordersRepository;
            OffersRepository = offersRepository;

            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
        }

        public UserManager<User> UserManager { get;  }
        public RoleManager<IdentityRole> RoleManager { get;  }
        public SignInManager<User> SignInManager { get;  }
        public DBContext DBContext { get { return _dbContext; } }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
