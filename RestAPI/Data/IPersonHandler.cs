using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using RestAPI.Models;

namespace RestAPI.Data
{
	public interface IPersonHandler
	{
		Task NewFamilyAsync(Family newFamily);
		Task RemoveFamilyAsync(string streetName, int houseNumber);
		Task<IList<Family>> GetFamiliesAsync();
		Task UpdateFamilyAsync(Family updatedFamily);
		bool Exists(Family family);

		//void NewAdult(Adult newAdult);
		//void RemoveAdult(int id);
		//Adult GetAdult(int id);
		//void UpdateAdult(Adult updatedAdult);
		//IList<Adult> LoadAdults();
	}
}