using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Abstractions;
using TaskManager.Application.Tasks.Commands.CreateTask;
using TaskManager.Application.Tasks.Queries.GetTaskList;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ApiController
    {
        public TaskController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskCommand command, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(command);

            return response.IsSuccess ? Ok() : BadRequest(response.Error);
        }

        [HttpGet]
        public async Task<IActionResult> GetTaskList([FromQuery] GetTaskListQuery query)
        {
            var response = await Mediator.Send(query);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }
    }
}
