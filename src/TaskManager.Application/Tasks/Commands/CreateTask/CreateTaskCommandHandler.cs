using AutoMapper;
using TaskManager.Application.Abstractions.Messaging;
using TaskManager.Domain.Abstractions.Repositories;
using TaskManager.Domain.Shared;

namespace TaskManager.Application.Tasks.Commands.CreateTask
{
    internal sealed class CreateTaskCommandHandler : ICommandHandler<CreateTaskCommand>
    {
        private readonly IRepository<Domain.Entities.Task> _taskRepository;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(
            IRepository<Domain.Entities.Task> taskRepository,
            IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Task>(request);
            
            await _taskRepository.AddAsync(entity);
            await _taskRepository.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
