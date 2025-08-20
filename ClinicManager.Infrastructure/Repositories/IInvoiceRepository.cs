using ClinicManager.Core.Entities;
using ClinicManager.Core.RepositoryContracts;
using ClinicManager.Infrastructure.DbContext;
namespace ClinicManager.Infrastructure.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}