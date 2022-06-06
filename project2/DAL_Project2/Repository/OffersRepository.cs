using DAL_Project2.Entitys;
using DAL_Project2.Helpers;
using DAL_Project2.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DAL_Project2.Repository
{
    public class OffersRepository:GenericRepository<Offers>,IOffersRepository
    {
        public OffersRepository(DBContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Offers>> GetAllByOrderId(int id,int pageNumber,int pageSize,bool desc,string orderbyName)
        {
            var item = Items.Include(x => x.User).Where(x => x.OrderId == id);
            var offers = await PagedList<Offers>.ToPagedList(item, pageNumber, pageSize);
            if (desc)
            {
                switch (orderbyName)
                {
                    case "offeredPrice":
                        offers.Items.OrderByDescending(p => p.OfferedPrise);
                        break;
                    case "offeredDay":
                        offers.Items.OrderByDescending(p => p.OfferedDay);

                        break;
                }
            }
            else
            {
                switch (orderbyName)
                {
                    case "offeredPrice":
                        offers.Items.OrderBy(p => p.OfferedPrise);
                        break;
                    case "offeredDay":
                        offers.Items.OrderBy(p => p.OfferedDay);

                        break;
                }
            }

            return item;
        }
    }
}
