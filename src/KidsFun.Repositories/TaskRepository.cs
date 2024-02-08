
using System;
using KidsFun.Models;

namespace KidsFun.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly KidsFunContext _db;
        public TaskRepository(KidsFunContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<TaskType> GetAsync(int taskId)
        {
            var taskType = _db.TaskTypes.FirstOrDefault(k => k.Id == taskId);
            if (taskType == default(TaskType))
            {
                throw new ArgumentException($"Task (Id={taskId}) can not be found.");
            }
            return await Task.FromResult(taskType);
        }
    }
}

