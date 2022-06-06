using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Project2.DTO.Responses
{
    public class OfferResponseDTO
    {
        public string? PerformerId { get; set; }
        public int OfferedPrise { get; set; }
        public int OfferedDay { get; set; }
        public string? DescriptionPerformer { get; set; }
        public bool? Selected { get; set; }

        public int Rating { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
