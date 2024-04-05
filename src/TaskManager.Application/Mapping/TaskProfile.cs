using AutoMapper;
using TaskManager.Application.Tasks.Commands.CreateTask;
using TaskManager.Application.Tasks.Queries.GetTaskList;

namespace TaskManager.Application.Mapping
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<CreateTaskCommand, Domain.Entities.Task>();
            CreateMap<Domain.Entities.Task, TaskResponse>();
        }
    }
}
