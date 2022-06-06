using AutoMapper;
using BLL_Project2.DTO.Requests;
using BLL_Project2.DTO.Responses;
using DAL_Project2.Entitys;

namespace BLL_Project2.Configurations
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateUserMaps();
            CreateOrderMaps();
            CreateOfferMaps();

        }

        private void CreateUserMaps()
        {
            CreateMap<UserSignUpRequest, User>();
            CreateMap<User,UserResponseDTO>();

        }

        private void CreateOrderMaps()
        {
            CreateMap<Orders, OrderResponseDTO>()
                .ForMember("FirstName", o => o.MapFrom(u => u.User.FirstName))
                .ForMember("LastName", o => o.MapFrom(u => u.User.LastName))
                .ForMember("Rating", o => o.MapFrom(u => u.User.Rating));
            CreateMap<OrderRequestDTO, Orders>();
        }

        private void CreateOfferMaps()
        {
            CreateMap<Offers, OfferResponseDTO>()
                .ForMember("FirstName", o => o.MapFrom(u => u.User.FirstName))
                .ForMember("LastName", o => o.MapFrom(u => u.User.LastName))
                .ForMember("Rating", o => o.MapFrom(u => u.User.Rating));
            CreateMap<OfferRequestDTO, Offers>();
        }
    }
}
