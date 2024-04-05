using MediatR;
using TaskManager.Domain.Shared;

namespace TaskManager.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
