
using ClinicManager.Core.Entities;
using ClinicManager.Core.RepositoryContracts;
using ClinicManager.Core.ServiceContracts;
using System.Linq.Expressions;

namespace ClinicManager.Core.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<Doctor> _repository;

        public DoctorService(IRepository<Doctor> repository)
        {
            _repository = repository;
        }

        public async Task<Doctor> AddAsync(Doctor entity)
        {
            entity.Id = Guid.NewGuid();
            await _repository.AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Doctor>> GetAllAsync(Expression<Func<Doctor, bool>>? filter = null, Func<IQueryable<Doctor>, IQueryable<Doctor>>? included = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public Task<Doctor?> GetByIdAsync(Guid id, Func<IQueryable<Doctor>, IQueryable<Doctor>>? included = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Doctor entity)
        {
            throw new NotImplementedException();
        }
    }
}
