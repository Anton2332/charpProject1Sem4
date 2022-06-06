using AutoMapper;
using DAL.Model;
using project1.Repositories.Interface;
using WEBAPI.BLL.DTO.Requests;
using WEBAPI.BLL.DTO.Responses;
using WEBAPI.BLL.Interfaces;

namespace WEBAPI.BLL.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;  
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostResponsDTO>> GetAllByOrderIdAsync(long id)
        {
            var result = await _unitOfWork.PostRepository.GetAllByOrderIdAsync(id);

            return result?.Select(_mapper.Map<PostRespons,PostResponsDTO>);
        }

        public async Task<long> AddAsync(PostRequestDTO post)
        {
            var result = _mapper.Map<PostRequestDTO, PostRespons>(post);
            return await _unitOfWork.PostRepository.AddAsync(result);
        }

        public async Task UpdateAsync(PostRequestDTO post)
        {
            var result = _mapper.Map<PostRequestDTO,PostRespons>(post);
            await _unitOfWork.PostRepository.ReplaceAsync(result);
        }

        public async Task DeleteAsync(long id)
        {
            await _unitOfWork.PostRepository.DeleteAsync(id);
        }
    }
}
