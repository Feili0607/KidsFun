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

        [HttpGet(Name = "GetAssignments")]
        public async Task<IActionResult> GetAsync(int kidId)
        {
            var result = await _dbContext.Kids.ToListAsync();
            return Ok(result);
        }

        [HttpPost(Name = "GetAssignments")]
        public void Assign(TaskAssignmentDto assignment)
        {
            _dbContext.Kids.Add(new KidDetail
            {
                Name = "xiyan",
                Email = "xiyan@minjet.com.au"
            });
            _dbContext.SaveChanges();
        }

    }
}