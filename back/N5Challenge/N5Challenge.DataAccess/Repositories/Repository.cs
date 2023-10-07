using Microsoft.EntityFrameworkCore;
using N5Challenge.DataAccess.Interfaces;
using N5Challenge.Domain;
using System.Linq.Expressions;

namespace N5Challenge.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : DataEntity
    {
        protected readonly SqlDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(SqlDbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<T>();
        }

        public T? Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.IncludeAll().ToListAsync(cancellationToken);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FirstOrDefaultAsync(expression, cancellationToken);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Remove(T entity) => _context.Remove(entity);

        public T Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}