

using ClinicManager.Core.RepositoryContracts;
using ClinicManager.Core.ServiceContracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Core.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public GenericService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>,IQueryable<T>>? included = null,
            bool tracked = false)
        {
            return await _repository.GetAllAsync(filter, included, tracked);
        }

        public async Task<T?> GetByIdAsync(Guid id, Func<IQueryable<T>, IQueryable<T>>? included = null, bool tracked = false)
        {
            return await _repository.GetAsync(e => EF.Property<Guid>(e, "Id") == id, included, tracked);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _repository.Save();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _repository.Save();
        }

        public async Task DeleteAsync(T entity)
        {
            _repository.Remove(entity);
            await _repository.Save();
        }
    }

}
