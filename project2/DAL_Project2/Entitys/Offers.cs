
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Project2.Entitys
{
    public class Offers:Entity
    {
        public int OrderId { get; set; }
        public string? PerformerId { get; set; }
        public int OfferedPrise { get; set; }
        public int OfferedDay { get; set; }
        public string? DescriptionPerformer { get; set; }
        public bool? Selected { get; set; }

        public Orders Order { get; set; }
        public User User { get; set; }
    }
}
