using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Abstractions.Entities;
using TaskManager.Infrastructure.Http.Internal;

namespace TaskManager.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly HttpContextProvider _httpContextProvider;
        private readonly Guid _tenantId;

        public AppDbContext(
            DbContextOptions options,
            HttpContextProvider httpContextProvider)
            : base(options)
        {
            _httpContextProvider = httpContextProvider;
            _tenantId = _httpContextProvider.GetTenantId();
        }

        public DbSet<Domain.Entities.Task> Task { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<Domain.Entities.Task>(builder =>
            {
                builder.HasQueryFilter(t => t.TenantId == _tenantId);
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<TenantEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.TenantId = _tenantId;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
