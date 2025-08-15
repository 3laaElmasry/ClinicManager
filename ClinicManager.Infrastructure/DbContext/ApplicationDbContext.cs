

using ClinicManager.Infrastructure.DbContext.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
    {
    }
}
