using BLL_Project2.DTO;
using BLL_Project2.DTO.Requests;
using BLL_Project2.DTO.Responses;
using BLL_Project2.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WEBAPI_Project2.Helpers;

namespace WEBAPI_Project2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService identityService;
        private readonly IIdentity _identity;
        private IConfiguration _config;

        public IdentityController(IIdentityService identityService,IIdentity identity,IConfiguration config)
        {
            this.identityService = identityService;
            this._config = config;
            _identity = identity;

        }

        [HttpGet("Get")]
        public async Task<ActionResult<string>> GetCurrentUser()
        {
            return Ok("1");
        }

        [Authorized]
        [HttpGet("Get1")]
        public async Task<ActionResult<string>> GetCurrentUser1()
        {
            return Ok("2");
        }

        [HttpPost("signIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AuthenticationDTO>> SignInAsync(
            [FromBody] UserSignInRequest request)
        {
            try
            {
                var response = await _identity.SignInAsync(request);
                    //SetRefreshTokenInCookie(response.RefreshToken);
                return Ok(response);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await identityService.RefreshTokenAsync(refreshToken);
            if (!string.IsNullOrEmpty(response.RefreshToken))
                SetRefreshTokenInCookie(response.RefreshToken);
            return Ok(response);
        }

        [HttpPost("RevokeToken")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenRequestDTO model)
        {
            // accept token from request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });
            var response = identityService.RevokeToken(token);
            if (!response)
                return NotFound(new { message = "Token not found" });
            return Ok(new { message = "Token revoked" });
        }

        [HttpPost("signUp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AuthenticationDTO>> SignUpAsync(
            [FromBody] UserSignUpRequest request)
        {
            try
            {
                var response = await _identity.SignUpAsync(request);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        private void SetRefreshTokenInCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(10),
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }

    }
}
