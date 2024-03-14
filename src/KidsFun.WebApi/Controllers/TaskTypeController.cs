using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using KidsFun.Models;
using KidsFun.Repositories;

namespace KidsFun.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskTypeController : ControllerBase
    {
        private readonly ITaskTypeRepository _taskTypeRepository;

        public TaskTypeController(ITaskTypeRepository taskTypeRepository)
        {
            _taskTypeRepository = taskTypeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTaskTypes()
        {
            var taskTypes = await _taskTypeRepository.GetAllTaskTypes();
            return Ok(taskTypes);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskTypeById(int id)
        {
            var taskType = await _taskTypeRepository.GetTaskTypeById(id);
            if (taskType == null)
                return NotFound();

            return Ok(taskType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskType(TaskType taskType)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Add the taskType to the list of task types
            await _taskTypeRepository.AddTaskType(taskType);

            // Return a 201 Created response with the newly created taskType
            return CreatedAtAction(nameof(GetTaskTypeById), new { id = taskType.Id }, taskType);
        }
    }
}
