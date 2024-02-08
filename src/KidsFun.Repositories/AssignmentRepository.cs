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

        public Task AddAsync(TaskAssignment newAssignment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int assignmentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskAssignment>> LoadAsync(int kidId)
        {
            throw new NotImplementedException();
        }
    }
}

