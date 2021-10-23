using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using RestAPI.Models;

namespace RestAPI.Data
{
	public interface IPersonHandler
	{
		Task NewFamilyAsync(Family newFamily);
		Task RemoveFamilyAsync(string familyName);
		Task<Family> GetFamilyAsync(string streetName, int houseNumber);
		Task<IList<Family>> GetFamilyAsync(string streetName);
		Task UpdateFamilyAsync(Family updatedFamily);

		//void NewAdult(Adult newAdult);
		//void RemoveAdult(int id);
		//Adult GetAdult(int id);
		//void UpdateAdult(Adult updatedAdult);
		//IList<Adult> LoadAdults();
	}
}