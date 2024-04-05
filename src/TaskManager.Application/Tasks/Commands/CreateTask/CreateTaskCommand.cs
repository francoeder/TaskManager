using TaskManager.Application.Abstractions.Messaging;

namespace TaskManager.Application.Tasks.Commands.CreateTask
{
    public sealed record CreateTaskCommand(
        string Title,
        string Details,
        DateTime DueDate) : ICommand
    {
    }
}
