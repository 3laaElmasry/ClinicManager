

using ClinicManager.Core.Entities;

namespace ClinicManager.Core.ServiceContracts
{
    public interface IJwtTokenGenrator
    {
        string GenrateToken(ApplicationUser user);
    }
}
