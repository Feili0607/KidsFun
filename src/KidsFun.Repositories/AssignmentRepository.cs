using System;
using KidsFun.Models;

namespace KidsFun.Repositories
{
	public class AssignmentRepository : IAssignmentRepository
	{
        private readonly KidsFunContext _db;
		public AssignmentRepository(KidsFunContext dbContext)
		{
            _db = dbContext;
		}

        public async Task<IEnumerable<TaskAssignment>> LoadAsync(int kidId)
        {
            var taskAssignment = _db.TaskAssignments.FirstOrDefault(k => k.KidId == kidId);
             if (taskAssignment == default(TaskAssignment))
            {
                throw new ArgumentException($"Kid (Id={kidId}) can not be found.");
            }
            return (IEnumerable<TaskAssignment>)await Task.FromResult(taskAssignment);

        }

        public async Task AddAsync(TaskAssignment newAssignment)
        {
            _db.TaskAssignments.Add(newAssignment);
            await _db.SaveChangesAsync();
        }


        public async Task DeleteAsync(int assignmentId)
        {
            var assignment = await _db.TaskAssignments.FindAsync(assignmentId);
            if (assignment != null)
            {
                _db.TaskAssignments.Remove(assignment);
                await _db.SaveChangesAsync();
            }
        }


    }
}

