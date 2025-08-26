

using ClinicManager.Core.Common;
using ClinicManager.Core.DTO.User;
using ClinicManager.Core.Entities;


namespace ClinicManager.Core.ServiceContracts
{
    public interface IAuthService
    {
        Task<AuthResult> Login(LoginModel model);

        Task<AuthResult> Logout();

        Task<AuthResult> PatinetRegister(RegisterPatient model);

        Task<ApplicationUser?> CreateUserAsync(RegisterModel model);
    }
}
