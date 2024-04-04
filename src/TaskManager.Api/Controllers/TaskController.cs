using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TaskManager.Domain.Abstractions.Repositories;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IRepository<Domain.Entities.Task> _taskRepository;

        public TaskController(
            IRepository<Domain.Entities.Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _taskRepository.GetOrderedAsync<object>(default, task => task.DueDate, false);

            return Ok(result);
        }
    }
}
