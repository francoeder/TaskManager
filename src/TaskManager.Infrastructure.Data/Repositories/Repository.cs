namespace TaskManager.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : BaseRepository<TEntity, AppDbContext> where TEntity : class
    {
        public Repository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
