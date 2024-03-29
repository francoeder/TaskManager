using Microsoft.EntityFrameworkCore;

namespace TaskManager.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Domain.Entities.Task> Task { get; set; }

        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
