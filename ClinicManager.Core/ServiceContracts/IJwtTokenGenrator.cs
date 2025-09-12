

using ClinicManager.Core.Common;
using ClinicManager.Core.Entities;

namespace ClinicManager.Core.ServiceContracts
{
    public interface IJwtTokenGenrator
    {
        Task<AuthResult> GenrateToken(ApplicationUser user);
    }
}
