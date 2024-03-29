using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Abstractions.Entities;

namespace TaskManager.Infrastructure.Data.Configurations.Base
{
    public class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
