using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Project2.DTO.Requests
{
    public class OfferRequestDTO
    {
        public string? PerformerId { get; set; }
        public int OfferedPrise { get; set; }
        public int OfferedDay { get; set; }
        public string? DescriptionPerformer { get; set; }
        public bool? Selected { get; set; }
    }
}
