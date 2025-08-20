using ClinicManager.Core.Entities;
using ClinicManager.Core.RepositoryContracts;
using ClinicManager.Infrastructure.DbContext;
namespace ClinicManager.Infrastructure.Repositories
{
    public class DiagnosisMedicationRepository : Repository<DiagnosisMedication>, IDiagnosisMedicationRepository
    {
        public DiagnosisMedicationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}