using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Abstractions.Repositories;

namespace TaskManager.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class where TContext : AppDbContext
    {
        private readonly Lazy<DbSet<TEntity>> _dbSet;
        protected readonly AppDbContext _appDbContext;

        public BaseRepository(AppDbContext appDbContext)
        {
            _dbSet = new Lazy<DbSet<TEntity>>(() => appDbContext.Set<TEntity>());
            _appDbContext = appDbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return (await _dbSet.Value.AddAsync(entity, cancellationToken)).Entity;
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> queryable = _dbSet.Value.AsQueryable();

            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }

            return await queryable.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetOrderedAsync<TField>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderDescending)
        {
            IQueryable<TEntity> queryable = _dbSet.Value.AsQueryable();

            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }

            if (orderByKeySelector != null)
            {
                queryable = orderDescending ?
                    queryable.OrderByDescending(orderByKeySelector) :
                    queryable.OrderBy(orderByKeySelector);
            }

            return await queryable.ToListAsync();
        }

        public TEntity Update(TEntity entity)
        {
            return _dbSet.Value.Update(entity).Entity;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Value.Remove(entity);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

    }
}
