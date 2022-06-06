using WEBAPI.BLL.DTO.Requests;
using WEBAPI.BLL.DTO.Responses;

namespace WEBAPI.BLL.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostResponsDTO>> GetAllByOrderIdAsync(long id);
        Task<long> AddAsync(PostRequestDTO post);
        Task UpdateAsync(PostRequestDTO post);
        Task DeleteAsync(long id);
    }
}
