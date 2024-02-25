using System;
using KidsFun.Models;
using Microsoft.EntityFrameworkCore;

namespace KidsFun.Repositories
{
    public class KidRepository : IKidsRepository
    {
        private readonly KidsFunContext _db;
        public KidRepository(KidsFunContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<IEnumerable<KidDetail>> GetAllAsync()
        {

            return await _db.Kids.ToListAsync();

         }


        public async Task<KidDetail> GetAsync(int kidId)
        {
            var kidDetail = await _db.Kids.FindAsync(kidId);
            if(kidDetail == default(KidDetail))
            {
                throw new ArgumentException($"Kid (Id={kidId}) can not be found.");
            }
            return await Task.FromResult(kidDetail);
        }


        public async Task<KidDetail> AddAsync(KidDetail kid)
        {
            if (kid == null)
            {
                throw new ArgumentNullException(nameof(kid));
            }

            var addedKid = _db.Kids.Add(kid);
            await _db.SaveChangesAsync();
            return addedKid.Entity;
        }


        public async Task UpdateAsync(KidDetail kid)
        {
            if (kid == null)
            {
                throw new ArgumentNullException(nameof(kid));
            }

            var existingKid = await _db.Kids.FindAsync(kid.Id);
            if (existingKid == null)
            {
                throw new ArgumentException($"Kid with {kid.Id} not found");
            }
            _db.Kids.Update(kid);
            await _db.SaveChangesAsync();

        }


        public async Task DeleteAsync(int kidId)
        {
            var kid = await _db.Kids.FindAsync(kidId);
            if (kid != null)
            {
                _db.Kids.Remove(kid);
                await _db.SaveChangesAsync();
            }

        }

       
    }
}

