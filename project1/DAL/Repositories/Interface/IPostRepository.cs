using DAL.Model;
using project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Repositories.Interface
{
    public interface IPostRepository:IGenericRepository<PostRespons>
    {
        Task<IEnumerable<PostRespons>> GetAllByOrderIdAsync(long id);
        Task<IEnumerable<PostRespons>> GetAllByOrderIdProcAsync(long id);
    }
}
