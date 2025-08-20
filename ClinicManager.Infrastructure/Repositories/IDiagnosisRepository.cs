using ClinicManager.Core.Entities;
using ClinicManager.Core.RepositoryContracts;
using ClinicManager.Infrastructure.DbContext;
namespace ClinicManager.Infrastructure.Repositories
{
    public class DiagnosisRepository : Repository<Diagnosis>, IDiagnosisRepository
    {
        public DiagnosisRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}