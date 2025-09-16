

using ClinicManager.Core.Common;
using ClinicManager.Core.DTO.User;
using ClinicManager.Core.Entities;


namespace ClinicManager.Core.ServiceContracts
{
    public interface IAuthService
    {
        Task<AuthResult> Login(LoginModel model);

        Task<bool> LogoutAsync(string refToken);

        Task<AuthResult> PatinetRegisterAsync(PatientRegister model);

        Task<ApplicationUser?> CreateUserAsync(RegisterModel model);

        Task<AuthResult> DoctorRegisterAsync(DoctorRegister model);

        Task<AuthResult> RefreshTokenAync(string refreshToken);

        Task<bool> RevokeRefreshTokenAsync(string refreshToken);
    }
}
