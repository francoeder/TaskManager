using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Infrastructure.Data.Configurations.Base;
using TaskManager.Infrastructure.Http.Internal;

namespace TaskManager.Infrastructure.Data.Configurations
{
    public class TaskConfiguration : TenantEntityConfiguration<Domain.Entities.Task>
    {
        public TaskConfiguration(HttpContextProvider httpContextProvider)
            : base(httpContextProvider)
        {
        }

        public override void Configure(EntityTypeBuilder<Domain.Entities.Task> builder)
        {
            base.Configure(builder);

            builder
                .HasKey(entity => entity.Id);

            builder
                .Property(entity => entity.Title)
                .HasMaxLength(250)
                .IsRequired();

            builder
                .Property(entity => entity.Details)
                .HasMaxLength(1000);

            builder
                .Property(entity => entity.DueDate)
                .IsRequired();
        }
    }
}
