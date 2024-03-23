using TaskManager.Domain.Abstractions.Entities;

namespace TaskManager.Domain.Entities
{
    public class Task : Entity
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime DueDate { get; set; }
    }
}
