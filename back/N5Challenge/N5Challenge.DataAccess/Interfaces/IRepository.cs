using System.Linq.Expressions;

namespace N5Challenge.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        #region Get
        T? Get(Expression<Func<T, bool>> expression);
        Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        #endregion

        Task<T> AddAsync(T entity);
        void Remove(T entity);
        T Update(T entity);
    }
}