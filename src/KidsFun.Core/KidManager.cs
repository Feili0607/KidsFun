using System;
using KidsFun.Models;

namespace KidsFun.Core
{
    public class KidManager : IKidManager

	{
		private readonly IKidsRepository _kidsRepository;
		public KidManager(IKidsRepository kidsRepository)
		{
            _kidsRepository = kidsRepository ??
            throw new ArgumentNullException(nameof(kidsRepository));
		}

        public async Task<IEnumerable<KidDetail>> GetKidsAsync()
        {
            return await _kidsRepository.GetAllAsync();
        }


        public async Task<KidDetail> GetKidAsync(int kidId)
        {
            return await _kidsRepository.GetAsync(kidId);
        }


        public async Task<KidDetail> CreateKidAsync(KidDetail kid)
        {
            if (kid == null)
            {
                throw new ArgumentNullException(nameof(kid));
            }

            return await _kidsRepository.AddAsync(kid);

        }


        public async Task UpdateKidAsync(int kidId, KidDetail updatedKid)
        {
            if (updatedKid == null)
            {
                throw new ArgumentNullException(nameof(updatedKid));
            }

 
            var existingKid = await _kidsRepository.GetAsync(kidId);
            if (existingKid == null)
            {
                throw new ArgumentException($"Kid with ID {kidId} not found.");
            }


            await _kidsRepository.UpdateAsync(updatedKid);
        }


        public async Task DeleteKidAsync(int kidId)
        {
            await _kidsRepository.DeleteAsync(kidId);
        }

    }
}

