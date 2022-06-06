using project1.Model;
using project1.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Repositories
{
    public class UserRepository : GenericRepository<user> , IUserRepository
    {
        public UserRepository(IDbTransaction transaction) : base("AspNetUsers",transaction)
        {

        }
    }
}
