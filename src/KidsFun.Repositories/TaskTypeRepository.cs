using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KidsFun.Models;
using Microsoft.EntityFrameworkCore;

namespace KidsFun.Repositories
{
    public class TaskTypeRepository : ITaskTypeRepository
    {
        private readonly KidsFunContext _context;

        public TaskTypeRepository(KidsFunContext context)
        {
            _context = context;
        }

        public async Task<List<TaskType>> GetAllTaskTypes()
        {
            return await _context.TaskTypes.ToListAsync();
        }

        public async Task<TaskType> GetTaskTypeById(int id)
        {
            return await _context.TaskTypes.FindAsync(id);
        }

        public async Task AddTaskType(TaskType taskType)
        {
            _context.TaskTypes.Add(taskType);
            await _context.SaveChangesAsync();
        }
    }
}