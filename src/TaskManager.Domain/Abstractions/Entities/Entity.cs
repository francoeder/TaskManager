namespace TaskManager.Domain.Abstractions.Entities
{
    public abstract class Entity
    {
        protected Entity(Guid id) => Id = id;

        protected Entity() { }

        public Guid Id { get; set; }
        public DateTime CreatedDate { get; protected set; }
    }
}
