using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Project2.DTO.Requests
{
    public class OrderRequestDTO
    {
        
        public string? customerId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? MaximumPrice { get; set; }
        public int? MaximumDay { get; set; }
        public DateTime? DateOrder { get; set; }

    }
}
