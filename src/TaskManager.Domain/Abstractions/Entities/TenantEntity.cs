namespace TaskManager.Domain.Abstractions.Entities
{
    public abstract class TenantEntity : Entity, ITenantEntity
    {
        public Guid TenantId { get; set; }
    }
}
