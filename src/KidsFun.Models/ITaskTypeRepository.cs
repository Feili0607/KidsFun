using System.Collections.Generic;
using System.Threading.Tasks;

namespace KidsFun.Models
{
    public interface ITaskTypeRepository
    {
        Task<List<TaskType>> GetAllTaskTypes();
        Task<TaskType> GetTaskTypeById(int id);
        Task AddTaskType(TaskType taskType);
    }
}
