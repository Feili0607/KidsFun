using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using KidsFun.Models;

namespace KidsFun.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskTypeController : ControllerBase
    {
        private readonly List<TaskType> _taskTypes = new List<TaskType>
        {
            new TaskType { Id = 1, Name = "Homework", Category = TaskCategory.Homework, RewardPoints = 20, MinimumAge = 10 },
            new TaskType { Id = 2, Name = "Skill Practice", Category = TaskCategory.SkillPractice, RewardPoints = 10, MinimumAge = 10 },
            new TaskType { Id = 3, Name = "Room Cleaning", Category = TaskCategory.CleanUp, RewardPoints = 5, MinimumAge = 8 }
        };

        [HttpGet]
        public IActionResult GetAllTaskTypes()
        {
            return Ok(_taskTypes);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskTypeById(int id)
        {
            var taskType = _taskTypes.FirstOrDefault(tt => tt.Id == id);
            if (taskType == null)
                return NotFound();

            return Ok(taskType);
        }

        [HttpPost]
        public IActionResult CreateTaskType(TaskType taskType)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Check if the ID already exists
            if (_taskTypes.Any(tt => tt.Id == taskType.Id))
            {
                ModelState.AddModelError("Id", "ID already exists.");
                return BadRequest(ModelState);
            }

            // Add the taskType to the list of task types

            _taskTypes.Add(taskType);

            // Return a 201 Created response with the newly created taskType
            return CreatedAtAction(nameof(GetTaskTypeById), new { id = taskType.Id }, taskType);
        }
    }
}
