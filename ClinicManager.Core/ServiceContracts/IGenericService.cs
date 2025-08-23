

using System.Linq.Expressions;

namespace ClinicManager.Core.ServiceContracts
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IQueryable<T>>? included = null,
            bool tracked = false);

        Task<T?> GetByIdAsync(Guid id,Func<IQueryable<T>,IQueryable<T>>? included = null, bool tracked = false);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }

}
