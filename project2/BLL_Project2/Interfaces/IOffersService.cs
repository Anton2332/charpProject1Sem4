using BLL_Project2.DTO.Requests;
using BLL_Project2.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Project2.Interfaces
{
    public interface IOffersService
    {
        Task AddAsync(OfferRequestDTO offer);
        Task UpdateAsync(OfferRequestDTO offer);
        Task DeleteAsync(int id);
        Task<IEnumerable<OfferResponseDTO>> GetAllByOrderIdAndOrderByOffeeredPriceDesc(int OrderId, int pageNumber);
        Task<IEnumerable<OfferResponseDTO>> GetAllByOrderIdAndOrderByOffeeredPrice(int OrderId, int pageNumber);
        Task<IEnumerable<OfferResponseDTO>> GetAllByOrderIdAndOrderByOffeeredDayDesc(int OrderId, int pageNumber);
       Task<IEnumerable<OfferResponseDTO>> GetAllByOrderIdAndOrderByOffeeredDay(int OrderId, int pageNumber);
    }
}
