using WEBAPI.BLL.DTO.Requests;
using WEBAPI.BLL.DTO.Responses;

namespace WEBAPI.BLL.Interfaces
{
    public interface IRepliesService
    {
        Task<IEnumerable<RepliesResponsDTO>> GetAllByPostIdAsync(long id);
        Task<long> AddAsync(RepliesRequestDTO post);
        Task UpdateAsync(RepliesRequestDTO post);
        Task DeleteAsync(long id);
    }
}
