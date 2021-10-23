using System.Collections.Generic;
using Models;
using RestAPI.Models;

namespace RestAPI.Data
{
	public interface IPersonHandler
	{
		void NewFamily(Family newFamily);
		void RemoveFamily(string familyName);
		Family GetFamily(string streetName, int houseNumber);
		IList<Family> GetFamily(string streetName);
		void UpdateFamily(Family updatedFamily);

		//void NewAdult(Adult newAdult);
		//void RemoveAdult(int id);
		//Adult GetAdult(int id);
		//void UpdateAdult(Adult updatedAdult);
		//IList<Adult> LoadAdults();
	}
}