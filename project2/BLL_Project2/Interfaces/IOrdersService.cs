using BLL_Project2.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Project2.Interfaces
{
    public interface IOrdersService 
    {
        Task<IEnumerable<OrderResponseDTO>> GetAllByAllIdAndOrderByMaximumPriceDescAsync(List<int> allId, int pageNumber);

        Task<IEnumerable<OrderResponseDTO>> GetAllByAllIdAndOrderByMaximumDayDescAsync(List<int> allId, int pageNumber);

        Task<IEnumerable<OrderResponseDTO>> GetAllByAllIdAndOrderByDateOrderDescAsync(List<int> allId, int pageNumber);

        Task<IEnumerable<OrderResponseDTO>> GetAllByAllIdAndOrderByNameAsync(List<int> allId, int pageNumber);

        Task<IEnumerable<OrderResponseDTO>> GetAllByAllIdAndOrderByMaximumPriceAsync(List<int> allId, int pageNumber);

        Task<IEnumerable<OrderResponseDTO>> GetAllByAllIdAndOrderByMaximumDayAsync(List<int> allId, int pageNumber);

        Task<IEnumerable<OrderResponseDTO>> GetAllByAllIdAndOrderByDateOrderAsync(List<int> allId, int pageNumber);


        Task<IEnumerable<OrderResponseDTO>> GetAllAndOrderByNameDescAsync(List<int> allId, int pageNumber);

        Task<IEnumerable<OrderResponseDTO>> GetAllAndOrderByMaximumPriceDescAsync(List<int> allId, int pageNumber);


        Task<IEnumerable<OrderResponseDTO>> GetAllAndOrderByMaximumDayDescAsync(List<int> allId, int pageNumber);


        Task<IEnumerable<OrderResponseDTO>> GetAllAndOrderByDateOrderDescAsync(List<int> allId, int pageNumber);

        Task<IEnumerable<OrderResponseDTO>> GetAllAndOrderByNameAsync(List<int> allId, int pageNumber);

        Task<IEnumerable<OrderResponseDTO>> GetAllAndOrderByMaximumPriceAsync(List<int> allId, int pageNumber);


        Task<IEnumerable<OrderResponseDTO>> GetAllAndOrderByMaximumDayAsync(List<int> allId, int pageNumber);


        Task<IEnumerable<OrderResponseDTO>> GetAllAndOrderByDateOrderAsync(List<int> allId, int pageNumber);

        Task<IEnumerable<OrderResponseDTO>> GetAllByNameAndOrderByMaximumPriceDescAsync(string name ,int pageNumber);

        Task<IEnumerable<OrderResponseDTO>> GetAllByNameAndOrderByMaximumDayDescAsync(string name, int pageNumber);

        Task<IEnumerable<OrderResponseDTO>> GetAllByNameAndOrderByDateOrderDescAsync(string name, int pageNumber);

        Task<IEnumerable<OrderResponseDTO>> GetAllByNameAndOrderByMaximumPriceAsync(string name, int pageNumber);

        Task<IEnumerable<OrderResponseDTO>> GetAllByNameAndOrderByMaximumDayAsync(string name, int pageNumber);

        Task<IEnumerable<OrderResponseDTO>> GetAllByNameAndOrderByDateOrderAsync(string name, int pageNumber);


    }
}
