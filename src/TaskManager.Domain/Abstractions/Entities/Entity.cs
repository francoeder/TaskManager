namespace TaskManager.Domain.Abstractions.Entities
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }

        protected Entity(Guid id)
        {
            Id = id;
        }

        protected Entity()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
