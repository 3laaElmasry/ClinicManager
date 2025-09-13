
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

        private void SetRefreshTokenInCookie(string refreshToken , DateTime expDate)
        {
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Expires = expDate.ToLocalTime(),
            };

            Response.Cookies.Append("refToken",refreshToken, cookieOptions);
        }
    }
}
