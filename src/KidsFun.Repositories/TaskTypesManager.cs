using System;
using KidsFun.Models;

namespace KidsFun.Repositories
{ 
    public class TaskTypesManager
    {
        private readonly KidsFunContext _dbContext;

        public TaskTypesManager(KidsFunContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TaskType> GetAllTaskTypes()
        {
            return _dbContext.Set<TaskType>().ToList();
        }

        public TaskType GetTaskTypeById(int id)
        {
            return _dbContext.Set<TaskType>().Find(id);
        }

        // Implement other CRUD methods as needed
    }
}