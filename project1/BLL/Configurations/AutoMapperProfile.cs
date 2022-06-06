using AutoMapper;
using DAL.Model;
using WEBAPI.BLL.DTO.Requests;
using WEBAPI.BLL.DTO.Responses;

namespace WEBAPI.BLL.Configurations
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreatePostMaps();
            CreateRepliesMaps();
        }

        private void CreatePostMaps()
        {
            CreateMap<PostRespons, PostResponsDTO>()
                .ForMember("Name",p => p.MapFrom(u => u.user.name))
                .ForMember("Rating",p=> p.MapFrom(u=>u.user.rating))
                ;
            CreateMap<PostRequestDTO, PostRespons>(); 
        }

        private void CreateRepliesMaps()
        {
            CreateMap<RepliesRespons, RepliesResponsDTO>()
                .ForMember("Name", p => p.MapFrom(u => u.user.name))
                .ForMember("Rating", p => p.MapFrom(u => u.user.rating));
        }
    }
}
