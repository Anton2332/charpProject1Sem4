using DAL_Project2.Entitys;
using DAL_Project2.Helpers;
using DAL_Project2.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DAL_Project2.Repository
{
    public class OrdersRepository:GenericRepository<Orders>,IOrdersRepository
    {
        public OrdersRepository(DBContext dbContext) : base(dbContext) { }

         public async Task<IEnumerable<Orders>> GetAllByAllIdAndOrderByAsync(List<int> allId,int pageNumber,int pageSize,bool desc,string orderbyName)
        {
            var item = Items.Include(x => x.customerId);
            var orders =await PagedList<Orders>.ToPagedList(item.Where(x => allId.Contains(x.Id)),pageNumber,pageSize);
            if (desc)
            {
                switch (orderbyName) {
                    case "name":
                        orders.Items.OrderByDescending(p => p.Name);
                        break;
                    case "maximumPrice":
                        orders.Items.OrderByDescending(p => p.MaximumPrice);
                        break;
                    case "maximumDay":
                        orders.Items.OrderByDescending(p => p.MaximumDay);
                        break;
                    case "dateOrder":
                        orders.Items.OrderByDescending(p => p.DateOrder);
                        break;
                }
            }
            else
            {
                switch (orderbyName)
                {
                    case "name":
                        orders.Items.OrderBy(p => p.Name);
                        break;
                    case "maximumPrice":
                        orders.Items.OrderBy(p => p.MaximumPrice);
                        break;
                    case "maximumDay":
                        orders.Items.OrderBy(p => p.MaximumDay);
                        break;
                    case "dateOrder":
                        orders.Items.OrderBy(p => p.DateOrder);
                        break;
                }
            }

            return orders.Items.ToList();
        }

        public async Task<IEnumerable<Orders>> GetAllAndOrderByAsync(int pageNumber, int pageSize, bool desc, string orderbyName)
        {
            var item = Items.Include(x => x.customerId);
            var orders = await PagedList<Orders>.ToPagedList(item, pageNumber, pageSize);
            if (desc)
            {
                switch (orderbyName)
                {
                    case "name":
                        orders.Items.OrderByDescending(p => p.Name);
                        break;
                    case "maximumPrice":
                        orders.Items.OrderByDescending(p => p.MaximumPrice);
                        break;
                    case "maximumDay":
                        orders.Items.OrderByDescending(p => p.MaximumDay);
                        break;
                    case "dateOrder":
                        orders.Items.OrderByDescending(p => p.DateOrder);
                        break;
                }
            }
            else
            {
                switch (orderbyName)
                {
                    case "name":
                        orders.Items.OrderBy(p => p.Name);
                        break;
                    case "maximumPrice":
                        orders.Items.OrderBy(p => p.MaximumPrice);
                        break;
                    case "maximumDay":
                        orders.Items.OrderBy(p => p.MaximumDay);
                        break;
                    case "dateOrder":
                        orders.Items.OrderBy(p => p.DateOrder);
                        break;
                }
            }

            return orders.Items.ToList();
        }

        public async Task<IEnumerable<Orders>> GetAllByNameAndOrderByAsync(string name,int pageNumber, int pageSize, bool desc, string orderbyName)
        {
            var item = Items.Include(x => x.customerId);
            var orders = await PagedList<Orders>.ToPagedList(item.Where(p => p.Name == name), pageNumber, pageSize);
            if (desc)
            {
                switch (orderbyName)
                {
                    case "maximumPrice":
                        orders.Items.OrderByDescending(p => p.MaximumPrice);
                        break;
                    case "maximumDay":
                        orders.Items.OrderByDescending(p => p.MaximumDay);
                        break;
                    case "dateOrder":
                        orders.Items.OrderByDescending(p => p.DateOrder);
                        break;
                }
            }
            else
            {
                switch (orderbyName)
                {
                    case "maximumPrice":
                        orders.Items.OrderBy(p => p.MaximumPrice);
                        break;
                    case "maximumDay":
                        orders.Items.OrderBy(p => p.MaximumDay);
                        break;
                    case "dateOrder":
                        orders.Items.OrderBy(p => p.DateOrder);
                        break;
                }
            }

            return orders.Items.ToList();
        }







    }
}
