namespace TaskManager.Domain.Abstractions.Entities
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; protected set; }
    }
}
