using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using KidsFun.Models;
using KidsFun.Repositories;

namespace KidsFun.WebApi.Controllers
{
    [ApiController]
    [Route("api/[tasktypes]")]
    public class TaskTypesController : ControllerBase
    {
        private readonly TaskTypesManager _taskTypesManager;

        public TaskTypesController(TaskTypesManager taskTypesManager)
        {
            _taskTypesManager = taskTypesManager;
        }

        [HttpGet]
        public IActionResult GetAllTaskTypes()
        {
            var taskTypes = _taskTypesManager.GetAllTaskTypes();
            return Ok(taskTypes);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskTypeById(int id)
        {
            var taskType = _taskTypesManager.GetTaskTypeById(id);
            if (taskType == null)
                return NotFound();

            return Ok(taskType);
        }
    }
}
