

using System.Linq.Expressions;

namespace ClinicManager.Core.RepositoryContracts
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IQueryable<T>>? include = null,
            bool tracked = false);

        Task<T?> GetAsync(
            Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IQueryable<T>>? include = null,
            bool tracked = false);

        Task AddAsync(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);

        Task Save();
    }

}
