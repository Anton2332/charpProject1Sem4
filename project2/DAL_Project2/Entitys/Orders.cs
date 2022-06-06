
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Project2.Entitys
{
    public class Orders :Entity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? MaximumPrice { get; set; }
        public int? MaximumDay { get; set; }
        public DateTime? DateOrder { get; set; }

        public IList<Offers> Offers { get; set; }
        public string? customerId { get; set; }
        public User User { get; set; }
    }
}
