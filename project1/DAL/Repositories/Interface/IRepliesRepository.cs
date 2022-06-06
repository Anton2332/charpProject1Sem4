using DAL.Model;
using project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Repositories.Interface
{
    public interface IRepliesRepository:IGenericRepository<RepliesRespons>
    {
        Task<IEnumerable<RepliesRespons>> GetAllByPostIdAsync(long id);
    }
}
