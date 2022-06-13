using BLL_Project2.DTO;
using BLL_Project2.DTO.Requests;

namespace WEBAPI_Project2.Helpers
{
    public interface IIdentity
    {
        Task<AuthenticationDTO> SignInAsync(UserSignInRequest request);

        Task<AuthenticationDTO> SignUpAsync(UserSignUpRequest request);
    }
}
