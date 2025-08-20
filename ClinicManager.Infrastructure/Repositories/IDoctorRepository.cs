using ClinicManager.Core.Entities;
using ClinicManager.Core.RepositoryContracts;
using ClinicManager.Infrastructure.DbContext;
namespace ClinicManager.Infrastructure.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}