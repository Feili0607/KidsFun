using System;
namespace KidsFun.Models
{
	public interface IAssignmentRepository
	{
        Task<IEnumerable<TaskAssignment>> LoadAsync(int kidId);

        Task AddAsync(TaskAssignment newAssignment);//creat

        Task DeleteAsync(int assignmentId);//delete
    }
}

