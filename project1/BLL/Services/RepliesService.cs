using AutoMapper;
using DAL.Model;
using project1.Repositories.Interface;
using WEBAPI.BLL.DTO.Requests;
using WEBAPI.BLL.DTO.Responses;
using WEBAPI.BLL.Interfaces;

namespace WEBAPI.BLL.Services
{
    public class RepliesService:IRepliesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public RepliesService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RepliesResponsDTO>> GetAllByPostIdAsync(long id)
        {
            var result = await _unitOfWork.RepliesRepository.GetAllByPostIdAsync(id);

            return result?.Select(_mapper.Map<RepliesRespons, RepliesResponsDTO>);
        }

        public async Task<long> AddAsync(RepliesRequestDTO post)
        {
            var result = _mapper.Map<RepliesRequestDTO, RepliesRespons>(post);
            return await _unitOfWork.RepliesRepository.AddAsync(result);
        }

        public async Task UpdateAsync(RepliesRequestDTO post)
        {
            var result = _mapper.Map<RepliesRequestDTO, RepliesRespons>(post);
            await _unitOfWork.RepliesRepository.ReplaceAsync(result);
        }

        public async Task DeleteAsync(long id)
        {
            await _unitOfWork.RepliesRepository.DeleteAsync(id);
        }
    }
}
