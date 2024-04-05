using System.Linq.Expressions;
using AutoMapper;
using TaskManager.Application.Abstractions.Messaging;
using TaskManager.Domain.Abstractions.Repositories;
using TaskManager.Domain.Shared;

namespace TaskManager.Application.Tasks.Queries.GetTaskList
{
    internal class GetTaskListQueryHandler : IQueryHandler<GetTaskListQuery, List<TaskResponse>>
    {
        private readonly IRepository<Domain.Entities.Task> _taskRepository;
        private readonly IMapper _mapper;

        public GetTaskListQueryHandler(
            IRepository<Domain.Entities.Task> taskRepository,
            IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<TaskResponse>>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            // Get list of Task, filtering by request.Title
            Expression<Func<Domain.Entities.Task, bool>> predicate =
                task => string.IsNullOrWhiteSpace(request.Title) || task.Title.Contains(request.Title);

            var taskLlist = await _taskRepository.GetOrderedAsync(
                predicate,
                task => task.DueDate,
                true);

            // Map the list of Task to a list of TaskResponse
            var response = _mapper.Map<List<TaskResponse>>(taskLlist);

            // Return the list of TaskResponse
            return response;
        }
    }
}
