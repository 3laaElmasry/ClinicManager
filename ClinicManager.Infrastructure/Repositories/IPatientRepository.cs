using ClinicManager.Core.Entities;
using ClinicManager.Core.RepositoryContracts;
using ClinicManager.Infrastructure.DbContext;
namespace ClinicManager.Infrastructure.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}