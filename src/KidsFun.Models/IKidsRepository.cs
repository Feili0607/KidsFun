using System;
namespace KidsFun.Models
{
	public interface IKidsRepository
	{
		Task<KidDetail> GetAsync(int kidId);
	}
}

