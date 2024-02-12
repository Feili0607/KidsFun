using System;
namespace KidsFun.Models
{ 
	public interface IKidManager
	{

       Task<IEnumerable<KidDetail>> GetKidsAsync();
       Task<KidDetail> GetKidAsync(int kidId);
       Task CreateKidAsync(KidDetail kid);
       Task UpdateKidAsync(int kidId, KidDetail updatedKid);
       Task DeleteKidAsync(int kidId);
        
    }
}

