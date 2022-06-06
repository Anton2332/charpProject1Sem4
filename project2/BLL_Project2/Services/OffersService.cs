using AutoMapper;
using BLL_Project2.DTO.Requests;
using BLL_Project2.DTO.Responses;
using BLL_Project2.Interfaces;
using DAL_Project2.Entitys;
using DAL_Project2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Project2.Services
{
    public class OffersService:IOffersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OffersService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(OfferRequestDTO offer)
        {
            var result = _mapper.Map<OfferRequestDTO,Offers>(offer);
            await _unitOfWork.OffersRepository.AddAsync(result);
        }

        public async Task UpdateAsync(OfferRequestDTO offer)
        {
            var result = _mapper.Map<OfferRequestDTO, Offers>(offer);
            await _unitOfWork.OffersRepository.UpdateAsync(result);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.OffersRepository.RemoveAsync(id);
        }

        public async Task<IEnumerable<OfferResponseDTO>> GetAllByOrderIdAndOrderByOffeeredPriceDesc(int OrderId,int pageNumber)
        {
            var item = await _unitOfWork.OffersRepository.GetAllByOrderId(OrderId, pageNumber, 50, true, "offeredPrice");

            return item?.Select(_mapper.Map<Offers,OfferResponseDTO>);
        }

        public async Task<IEnumerable<OfferResponseDTO>> GetAllByOrderIdAndOrderByOffeeredPrice(int OrderId, int pageNumber)
        {
            var item = await _unitOfWork.OffersRepository.GetAllByOrderId(OrderId, pageNumber, 50, false, "offeredPrice");

            return item?.Select(_mapper.Map<Offers, OfferResponseDTO>);
        }

        public async Task<IEnumerable<OfferResponseDTO>> GetAllByOrderIdAndOrderByOffeeredDayDesc(int OrderId, int pageNumber)
        {
            var item = await _unitOfWork.OffersRepository.GetAllByOrderId(OrderId, pageNumber, 50, true, "offeredDay");

            return item?.Select(_mapper.Map<Offers, OfferResponseDTO>);
        }

        public async Task<IEnumerable<OfferResponseDTO>> GetAllByOrderIdAndOrderByOffeeredDay(int OrderId, int pageNumber)
        {
            var item = await _unitOfWork.OffersRepository.GetAllByOrderId(OrderId, pageNumber, 50, false, "offeredDay");

            return item?.Select(_mapper.Map<Offers, OfferResponseDTO>);
        }
    }
}
