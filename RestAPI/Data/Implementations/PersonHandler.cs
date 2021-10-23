using System.Collections.Generic;
using System.Linq;
using Models;
using RestAPI.FileData;
using RestAPI.Models;

namespace RestAPI.Data.Implementations
{
	public class PersonHandler : IPersonHandler
	{
		private static FileContext _fileContext;

		public PersonHandler()
		{
			_fileContext = new();
		}

		public void NewFamily(Family newFamily)
		{
			_fileContext.Families.Add(newFamily);
			_fileContext.SaveChanges();
		}

		public void RemoveFamily(string familyName)
		{
			Family family = _fileContext.Families.FirstOrDefault(f => f.Adults.First( ).LastName == familyName);
			if (family == null)
			{
				return;
			}

			_fileContext.Families.Remove(family);
			_fileContext.SaveChanges();
		}

		public Family GetFamily(string streetName, int houseNumber)
		{
			Family family = _fileContext.Families.FirstOrDefault(f => f.StreetName == streetName && f.HouseNumber == houseNumber);
			return family;
		}

		public IList<Family> GetFamily(string streetName)
		{
			IList<Family> families = _fileContext.Families.Where(f => f.StreetName == streetName).ToList();
			return families;
		}
		public void UpdateFamily(Family updatedFamily)
		{
			// Get the old Family
			Family oldFamily = GetFamily(updatedFamily.StreetName, updatedFamily.HouseNumber);
			// Get Index in list of Family
			int familyIdx = _fileContext.Families.IndexOf(oldFamily);
			// Remove old Family
			_fileContext.Families.RemoveAt(familyIdx);
			// Insert new Family
			_fileContext.Families.Insert(familyIdx, updatedFamily);
			_fileContext.SaveChanges();
		}



		//public void NewAdult(Adult newAdult)
		//{
		//	int id = _fileContext.Adults.Max(adult => adult.Id);
		//	newAdult.Id = ++id;
		//	_fileContext.Adults.Add(newAdult);
		//	_fileContext.SaveChanges();
		//}

		//public void RemoveAdult(int id)
		//{
		//	Adult adultToRemove = _fileContext.Adults.First(adult => adult.Id == id);
		//	int idx = _fileContext.Adults.IndexOf(adultToRemove);
		//	_fileContext.Adults.RemoveAt(idx);
		//	_fileContext.SaveChanges();
		//}

		//public Adult GetAdult(int id)
		//{
		//	Adult a = _fileContext.Adults.FirstOrDefault(adult => adult.Id == id);
		//	return a;
		//}

		//public void UpdateAdult(Adult updatedAdult)
		//{
		//	Adult a = GetAdult(updatedAdult.Id);
		//	int idx = _fileContext.Adults.IndexOf(a);
		//	_fileContext.Adults.RemoveAt(idx);
		//	_fileContext.Adults.Insert(idx, updatedAdult);
		//	_fileContext.SaveChanges();
		//}

		//public IList<Adult> LoadAdults()
		//{
		//	return _fileContext.Adults;
		//}
	}
}