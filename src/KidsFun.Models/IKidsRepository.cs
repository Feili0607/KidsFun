using System;
namespace KidsFun.Models

{
    public interface IKidsRepository
    {
        Task<IEnumerable<KidDetail>> GetAllAsync();
        Task<KidDetail> GetAsync(int kidId);
        Task AddAsync(KidDetail kid);
        Task UpdateAsync(KidDetail kid);
        Task DeleteAsync(int kid);
    }
}

