using System;
namespace KidsFun.Models
{
	public interface ITaskRepository
    {
        Task<TaskType> GetAsync(int taskId);
    }
}

