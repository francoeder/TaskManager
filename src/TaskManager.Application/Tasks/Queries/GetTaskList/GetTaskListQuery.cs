using TaskManager.Application.Abstractions.Messaging;

namespace TaskManager.Application.Tasks.Queries.GetTaskList
{
    public sealed record GetTaskListQuery(string? Title) : IQuery<List<TaskResponse>>;
}
