
using ClinicManager.Core.Common;
using ClinicManager.Core.DTO.User;
using ClinicManager.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("PatientRegister")]
        public async Task<ActionResult<Result<AuthResult>>> PatientRegisterAsync([FromBody] PatientRegister model)
        {
            var res = await _authService.PatinetRegisterAsync(model);

            if (res.Success)
            {
                if (!String.IsNullOrEmpty(res.RefreshToken) && res.RefreshTokenExpiration is not null)
                {
                    SetRefreshTokenInCookie(res.RefreshToken, res.RefreshTokenExpiration.Value);
                }
                return Ok(Result<AuthResult>.SuccessResult(res, res.Message));

            }

            return BadRequest(Result<AuthResult>.Failure(res.Message));
        }


        [HttpPost("DoctorRegister")]
        public async Task<ActionResult<Result<AuthResult>>> DoctorRegisterAsync([FromBody] DoctorRegister model)
        {
            var res = await _authService.DoctorRegisterAsync(model);

            if (res.Success)
            {
                if (!String.IsNullOrEmpty(res.RefreshToken) && res.RefreshTokenExpiration is not null)
                {
                    SetRefreshTokenInCookie(res.RefreshToken, res.RefreshTokenExpiration.Value);
                }
                return Ok(Result<AuthResult>.SuccessResult(res, res.Message));
            }

            return BadRequest(Result<AuthResult>.Failure(res.Message));
        }

        [HttpPost]

        public async Task<ActionResult<Result<AuthResult>>> LogIn(LoginModel model)
        {
            var res = await _authService.Login(model);

            if (res.Success)
            {
                if (!String.IsNullOrEmpty(res.RefreshToken) && res.RefreshTokenExpiration is not null)
                {
                    SetRefreshTokenInCookie(res.RefreshToken, res.RefreshTokenExpiration.Value);
                }
                return Ok(Result<AuthResult>.SuccessResult(res, res.Message));

            }
            return BadRequest(Result<AuthResult>.Failure(res.Message));
        }

        [HttpGet]
        public async Task<ActionResult<Result<AuthResult>>> RefreshTokenAsync()
        {
            var requestRefreshToken = Request.Cookies["refToken"];

            if (String.IsNullOrEmpty(requestRefreshToken))
            {
                return BadRequest(Result<AuthResult>.Failure("Missed Refresh Token Cookie"));
            }
            var res = await _authService.RefreshTokenAync(requestRefreshToken);

            if (!res.Success)
            {
                return BadRequest(Result<AuthResult>.Failure(res.Message));
            }


            SetRefreshTokenInCookie(res.RefreshToken!, res.RefreshTokenExpiration!.Value);
            return Ok(Result<AuthResult>.SuccessResult(res, res.Message));
        }

        [HttpPost("revoke-token")]

        public async Task<ActionResult<Result<bool>>> RevokeTokenAsync([FromBody] string? refreshToken)
        {
            var token = refreshToken ?? Request.Cookies["refToken"];
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(Result<bool>.Failure("Token is required"));
            }
            var res = await _authService.RevokeRefreshTokenAsync(token);

            if (!res)
                return BadRequest(Result<bool>.Failure("Token is invalid"));

            return Ok(Result<bool>.SuccessResult(res,"Token revoked Succefully"));
        }

        [HttpPost("logOut")]

        public async Task<ActionResult<Result<bool>>> LogOutAsync([FromBody]string? refToken)
            {
            var token = refToken ?? Request.Cookies["refToken"];

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(Result<bool>.Failure("Token is required"));
            }
            var res = await _authService.LogoutAsync(token);

            if (!res)
                return BadRequest(Result<bool>.Failure("Token is invalid"));

            return Ok(Result<bool>.SuccessResult(res, "Logout Succeded"));
        }


        private void SetRefreshTokenInCookie(string refreshToken , DateTime expDate)
        {
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Expires = expDate.ToLocalTime(),
            };

            Response.Cookies.Append("refToken",refreshToken, cookieOptions);
        }

        private void DeleteRefreshTokenInCookie()
        {
            Response.Cookies.Delete("refToken");
        }
    }
}
