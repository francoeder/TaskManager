using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManager.Infrastructure.Data.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Domain.Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Task> builder)
        {
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

            builder
                .Property(entity => entity.UserEmail)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
