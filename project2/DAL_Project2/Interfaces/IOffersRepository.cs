using DAL_Project2.Entitys;
using DAL_Project2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Project2.Interfaces
{
    public interface IOffersRepository:IRepository<Offers>
    {
        Task<IEnumerable<Offers>> GetAllByOrderId(int id, int pageNumber, int pageSize, bool desc, string orderbyName);
    }
}
