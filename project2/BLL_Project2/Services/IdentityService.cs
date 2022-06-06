
using AutoMapper;
using BLL_Project2.Configurations;
using BLL_Project2.DTO;
using BLL_Project2.DTO.Requests;
using BLL_Project2.Interfaces;
using DAL_Project2.Entitys;
using DAL_Project2.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL_Project2.Services
{
    public class IdentityService:IIdentityService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly JWT _jwt;

        public IdentityService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IOptions<JWT> jwt)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwt = jwt.Value;
        }

        public async Task<AuthenticationDTO> SignInAsync(UserSignInRequest request)
        {
            var authenticationDTO = new AuthenticationDTO();
            var user = await _unitOfWork.UserManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                authenticationDTO.IsAuthenticated = false;
                authenticationDTO.Message = $"No Accounts Registered with {request.UserName}.";
                return authenticationDTO;
            }

            if (await _unitOfWork.UserManager.CheckPasswordAsync(user, request.Password))
            {
                authenticationDTO.IsAuthenticated = true;
                JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);
                authenticationDTO.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                authenticationDTO.Email = user.Email;
                authenticationDTO.UserName = user.UserName;
                var rolesList = await _unitOfWork.UserManager.GetRolesAsync(user).ConfigureAwait(false);
                authenticationDTO.Roles = rolesList.ToList();
                if (user.RefreshTokens.Any(a => a.IsActive))
                {
                    var activeRefreshToken = user.RefreshTokens.Where(a => a.IsActive == true).FirstOrDefault();
                    authenticationDTO.RefreshToken = activeRefreshToken.Token;
                    authenticationDTO.RefreshTokenExpiration = activeRefreshToken.Expires;
                }
                else
                {
                    var refreshToken = CreateRefreshToken();
                    authenticationDTO.RefreshToken = refreshToken.Token;
                    authenticationDTO.RefreshTokenExpiration = refreshToken.Expires;
                    user.RefreshTokens.Add(refreshToken);
                    _unitOfWork.DBContext.Update(user);
                    _unitOfWork.DBContext.SaveChanges();
                }

                return authenticationDTO;
            }
            authenticationDTO.IsAuthenticated = false;
            authenticationDTO.Message = $"Incorrect Credentials for user {user.UserName}.";
            return authenticationDTO;
        }


        public async Task<AuthenticationDTO> SignUpAsync(UserSignUpRequest request)
        {
            var user = _mapper.Map<UserSignUpRequest, User>(request);
            var signUpResult = await _unitOfWork.UserManager.CreateAsync(user, request.Password);
            await _unitOfWork.UserManager.AddToRoleAsync(user, "basic");
            if (!signUpResult.Succeeded)
            {
                string errors = string.Join("\n",
                    signUpResult.Errors.Select(error => error.Description));

                throw new ArgumentException(errors);
            }

            await _unitOfWork.SaveChangesAsync();

            var signIn = new UserSignInRequest();
            signIn.UserName = request.UserName;
            signIn.Password = request.Password;

            return await SignInAsync(signIn);
        }

        public async Task<AuthenticationDTO> RefreshTokenAsync(string token)
        {
            var authenticationModel = new AuthenticationDTO();
            var user = _unitOfWork.DBContext.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
            if (user == null)
            {
                authenticationModel.IsAuthenticated = false;
                authenticationModel.Message = $"Token did not match any users.";
                return authenticationModel;
            }
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            if (!refreshToken.IsActive)
            {
                authenticationModel.IsAuthenticated = false;
                authenticationModel.Message = $"Token Not Active.";
                return authenticationModel;
            }
            //Revoke Current Refresh Token
            refreshToken.Revoked = DateTime.UtcNow;
            //Generate new Refresh Token and save to Database
            var newRefreshToken = CreateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            _unitOfWork.DBContext.Update(user);
            _unitOfWork.DBContext.SaveChanges();
            //Generates new jwt
            authenticationModel.IsAuthenticated = true;
            JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);
            authenticationModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authenticationModel.Email = user.Email;
            authenticationModel.UserName = user.UserName;
            var rolesList = await _unitOfWork.UserManager.GetRolesAsync(user).ConfigureAwait(false);
            authenticationModel.Roles = rolesList.ToList();
            authenticationModel.RefreshToken = newRefreshToken.Token;
            authenticationModel.RefreshTokenExpiration = newRefreshToken.Expires;
            return authenticationModel;
        }

        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var userClaims = await _unitOfWork.UserManager.GetClaimsAsync(user);
            var roles = await _unitOfWork.UserManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);
            _unitOfWork.SaveChangesAsync();
            return jwtSecurityToken;
        }

        private RefreshToken CreateRefreshToken()
        {
            string path = Path.GetRandomFileName();
            string path2 = Path.GetRandomFileName();
            path = path.Replace(".", "");
            path2 = path2.Replace(".", "");
            string random = path + path2;
                return new RefreshToken
                {
                    Token = random,
                    Expires = DateTime.UtcNow.AddMinutes(180),
                    Created = DateTime.UtcNow
                };
            
        }


        public bool RevokeToken(string token)
        {
            var user = _unitOfWork.DBContext.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
            // return false if no user found with token
            if (user == null) return false;
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            // return false if token is not active
            if (!refreshToken.IsActive) return false;
            // revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            _unitOfWork.DBContext.Update(user);
            _unitOfWork.DBContext.SaveChanges();
            return true;
        }


    }
}
