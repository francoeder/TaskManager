namespace TaskManager.Domain.Abstractions.Entities
{
    public interface ITenantEntity : IEntity
    {
        public Guid TenantId { get; set; }
    }
}
