using DAL_Project2.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Project2.Interfaces
{
    public interface IOrdersRepository:IRepository<Orders>
    {
        Task<IEnumerable<Orders>> GetAllByAllIdAndOrderByAsync(List<int> allId, int pageNumber, int pageSize, bool desc, string orderbyName);
        Task<IEnumerable<Orders>> GetAllAndOrderByAsync(int pageNumber, int pageSize, bool desc, string orderbyName);
        Task<IEnumerable<Orders>> GetAllByNameAndOrderByAsync(string name, int pageNumber, int pageSize, bool desc, string orderbyName);
    }
}
