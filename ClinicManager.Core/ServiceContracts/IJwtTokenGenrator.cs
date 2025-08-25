

using ClinicManager.Core.Entities;

namespace ClinicManager.Core.ServiceContracts
{
    public interface IJwtTokenGenrator
    {
        Task<string> GenrateToken(ApplicationUser user);
    }
}
