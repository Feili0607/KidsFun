using KidsFun.Models;
using KidsFun.Repositories;
using KidsFun.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace KidsFun.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly ILogger<AssignmentController> _logger;
        private readonly KidsFunContext _dbContext;

        public AssignmentController(KidsFunContext context, ILogger<AssignmentController> logger)
        {
            _dbContext = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(int kidId)
        {
            // TODO: to add the implementation
            throw new NotImplementedException();
        }

        [HttpPost]
        public void Assign(TaskAssignmentDto assignment)
        {
            // TODO: to add the implementation
            throw new NotImplementedException();
        }

    }
}