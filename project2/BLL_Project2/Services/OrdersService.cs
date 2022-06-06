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
    public class OrdersService:IOrdersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrdersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(OrderRequestDTO order)
        {
            var result = _mapper.Map<OrderRequestDTO, Orders>(order);
            await _unitOfWork.OrdersRepository.AddAsync(result);
        }

        public async Task UpdateAsync(OrderRequestDTO order)
        {
            var result = _mapper.Map<OrderRequestDTO, Orders>(order);
            await _unitOfWork.OrdersRepository.UpdateAsync(result);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.OrdersRepository.RemoveAsync(id);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllByAllIdAndOrderByNameDescAsync(List<int> allId,int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllByAllIdAndOrderByAsync(allId, pageNumber, 50, true, "name");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllByAllIdAndOrderByMaximumPriceDescAsync(List<int> allId, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllByAllIdAndOrderByAsync(allId, pageNumber, 50, true, "maximumPrice");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllByAllIdAndOrderByMaximumDayDescAsync(List<int> allId, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllByAllIdAndOrderByAsync(allId, pageNumber, 50, true, "maximumDay");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllByAllIdAndOrderByDateOrderDescAsync(List<int> allId, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllByAllIdAndOrderByAsync(allId, pageNumber, 50, true, "dataOrder");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllByAllIdAndOrderByNameAsync(List<int> allId, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllByAllIdAndOrderByAsync(allId, pageNumber, 50, false, "name");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllByAllIdAndOrderByMaximumPriceAsync(List<int> allId, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllByAllIdAndOrderByAsync(allId, pageNumber, 50, false, "maximumPrice");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllByAllIdAndOrderByMaximumDayAsync(List<int> allId, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllByAllIdAndOrderByAsync(allId, pageNumber, 50, false, "maximumDay");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllByAllIdAndOrderByDateOrderAsync(List<int> allId, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllByAllIdAndOrderByAsync(allId, pageNumber, 50, false, "dataOrder");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }


        public async Task<IEnumerable<OrderResponseDTO>> GetAllAndOrderByNameDescAsync(List<int> allId, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllAndOrderByAsync(pageNumber, 50, true, "name");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllAndOrderByMaximumPriceDescAsync(List<int> allId, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllAndOrderByAsync(pageNumber, 50, true, "maximumPrice");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }


        public async Task<IEnumerable<OrderResponseDTO>> GetAllAndOrderByMaximumDayDescAsync(List<int> allId, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllAndOrderByAsync(pageNumber, 50, true, "maximumDay");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }


        public async Task<IEnumerable<OrderResponseDTO>> GetAllAndOrderByDateOrderDescAsync(List<int> allId, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllAndOrderByAsync(pageNumber, 50, true, "dateOrder");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllAndOrderByNameAsync(List<int> allId, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllAndOrderByAsync(pageNumber, 50, false, "name");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllAndOrderByMaximumPriceAsync(List<int> allId, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllAndOrderByAsync(pageNumber, 50, false, "maximumPrice");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }


        public async Task<IEnumerable<OrderResponseDTO>> GetAllAndOrderByMaximumDayAsync(List<int> allId, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllAndOrderByAsync(pageNumber, 50, false, "maximumDay");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }


        public async Task<IEnumerable<OrderResponseDTO>> GetAllAndOrderByDateOrderAsync(List<int> allId, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllAndOrderByAsync(pageNumber, 50, false, "dateOrder");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllByNameAndOrderByMaximumPriceDescAsync(string name ,int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllByNameAndOrderByAsync(name, pageNumber, 50, true, "maximumPrice");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllByNameAndOrderByMaximumDayDescAsync(string name, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllByNameAndOrderByAsync(name, pageNumber, 50, true, "maximumDay");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllByNameAndOrderByDateOrderDescAsync(string name, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllByNameAndOrderByAsync(name, pageNumber, 50, true, "dateOrder");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllByNameAndOrderByMaximumPriceAsync(string name, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllByNameAndOrderByAsync(name, pageNumber, 50, false, "maximumPrice");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllByNameAndOrderByMaximumDayAsync(string name, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllByNameAndOrderByAsync(name, pageNumber, 50, false, "maximumDay");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllByNameAndOrderByDateOrderAsync(string name, int pageNumber)
        {
            var items = await _unitOfWork.OrdersRepository.GetAllByNameAndOrderByAsync(name, pageNumber, 50, false, "dateOrder");

            return items?.Select(_mapper.Map<Orders, OrderResponseDTO>);
        }





    }
}
