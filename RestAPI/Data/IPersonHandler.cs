using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using RestAPI.Models;

namespace RestAPI.Data
{
	public interface IPersonHandler
	{
		Task<bool> NewFamilyAsync(Family newFamily);
		Task RemoveFamilyAsync(string streetName, int houseNumber);
		Task<IList<Family>> GetFamiliesAsync();
		Task UpdateFamilyAsync(Family updatedFamily);
		bool Exists(Family family);

		//void NewAdult(Adult newAdult); // This would be dumb to implement, since an Adult can't be forced into a family
		Task<Adult> RemoveAdultAsync(int id);
		Task UpdateAdultAsync(Adult updatedAdult);
		Task<IList<Adult>> GetAdultsAsync();
	}
}