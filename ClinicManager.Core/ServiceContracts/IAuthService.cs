

using ClinicManager.Core.Common;
using ClinicManager.Core.DTO.User;


namespace ClinicManager.Core.ServiceContracts
{
    public interface IAuthService
    {
        Task<AuthResult> Login(LoginModel model);

        Task<AuthResult> Logout();

        Task<AuthResult> PatinetRegister(RegisterPatient model);
    }
}
