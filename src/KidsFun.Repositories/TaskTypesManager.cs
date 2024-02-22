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

        public int CalculateRewardPoints(int taskId, int workingHours)
        {
            var taskType = _dbContext.Set<TaskType>().Find(taskId);
            if (taskType == null)
            {
                throw new ArgumentException("Invalid task ID", nameof(taskId));
            }

            // set the points
            int basePoints = taskType.rewardPoints;
            int extraPoints = 0;

            // get the different points from the different task type
            if (taskType.skillPractice == true)
            {
                // skillPractice = 7 points per 1 hour
                extraPoints += 7*workingHours;
            }

            if (taskType.homework == true)
            {
                // homework = 10 points per 1 hour
                extraPoints += 10*workingHours;
            }

            if (taskType.cleanUp == true)
            {
                // cleanUp = 5 points per 1 hour
                extraPoints += 5*workingHours;
            }

            // Calculate the total points
            int totalPoints = basePoints + extraPoints;

            return totalPoints;
        }
    }
}