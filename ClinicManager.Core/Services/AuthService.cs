

using ClinicManager.Core.Common;
using ClinicManager.Core.DTO.User;
using ClinicManager.Core.ServiceContracts;

namespace ClinicManager.Core.Services
{
    public class AuthService : IAuthService
    {
        public Task<AuthResult> Login(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> Logout()
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> PatinetRegister(RegisterPatientDto model)
        {
            throw new NotImplementedException();
        }
    }
}
