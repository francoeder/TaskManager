using System.Linq.Expressions;

namespace TaskManager.Domain.Abstractions.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetOrderedAsync<TField>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending);
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
