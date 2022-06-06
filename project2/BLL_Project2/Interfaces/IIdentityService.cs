using BLL_Project2.DTO;
using BLL_Project2.DTO.Requests;
using BLL_Project2.DTO.Responses;

namespace BLL_Project2.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthenticationDTO> SignInAsync(UserSignInRequest request);

        Task<AuthenticationDTO> SignUpAsync(UserSignUpRequest request);
        Task<AuthenticationDTO> RefreshTokenAsync(string token);
        bool RevokeToken(string token);
    }
}
