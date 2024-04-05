using MediatR;
using TaskManager.Domain.Shared;

namespace TaskManager.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface  ICommand<TResponse> : IRequest<Result<TResponse>>
    {
        
    }
}
