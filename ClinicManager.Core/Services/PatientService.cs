
using ClinicManager.Core.Entities;
using ClinicManager.Core.RepositoryContracts;
using ClinicManager.Core.ServiceContracts;
using System.Linq.Expressions;

namespace ClinicManager.Core.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _repository;

        public PatientService(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        public async Task<Patient> AddAsync(Patient entity)
        {
            entity.Id = Guid.NewGuid();
            await _repository.AddAsync(entity);
            await _repository.Save();
            return entity;
        }

        public Task DeleteAsync(Patient entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Patient>> GetAllAsync(Expression<Func<Patient, bool>>? filter = null, Func<IQueryable<Patient>, IQueryable<Patient>>? included = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public Task<Patient?> GetByIdAsync(Guid id, Func<IQueryable<Patient>, IQueryable<Patient>>? included = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Patient entity)
        {
            throw new NotImplementedException();
        }
    }
}
