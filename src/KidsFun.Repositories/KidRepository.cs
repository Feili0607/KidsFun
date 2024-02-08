using System;
using KidsFun.Models;

namespace KidsFun.Repositories
{
	public class KidRepository : IKidsRepository
	{
        private readonly KidsFunContext _db;
		public KidRepository(KidsFunContext dbContext)
		{
            _db = dbContext;
		}

        public async Task<KidDetail> GetAsync(int kidId)
        {
            var kidDetail = _db.Kids.FirstOrDefault(k => k.Id == kidId);
            if(kidDetail == default(KidDetail))
            {
                throw new ArgumentException($"Kid (Id={kidId}) can not be found.");
            }
            return await Task.FromResult(kidDetail);
        }
    }
}

