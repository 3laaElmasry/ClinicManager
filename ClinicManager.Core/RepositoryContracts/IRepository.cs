

using System.Linq.Expressions;

namespace ClinicManager.Core.RepositoryContracts
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T,bool>>? filter = null, string? includeProprties = null);

        Task<T?> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);

        Task AddAsync(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);

        Task Save();
    }
}
