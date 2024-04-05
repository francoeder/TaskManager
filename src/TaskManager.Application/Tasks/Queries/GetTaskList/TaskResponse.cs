namespace TaskManager.Application.Tasks.Queries.GetTaskList
{
    public sealed record TaskResponse(Guid Id, string Title, DateTime DueDate);
}
