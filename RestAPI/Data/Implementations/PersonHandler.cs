using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

		public async Task NewFamilyAsync(Family newFamily)
		{
			_fileContext.Families.Add(newFamily);
			_fileContext.SaveChanges();
		}

		public async Task RemoveFamilyAsync(string streetName, int houseNumber)
		{
			Family f = _fileContext.Families.FirstOrDefault(f =>
				f.StreetName == streetName && f.HouseNumber == houseNumber);

			Console.WriteLine(f);
			if (f == null)
			{
				return;
			}

			_fileContext.Families.Remove(f);
			_fileContext.SaveChanges();
		}

		public async Task<IList<Family>> GetFamiliesAsync()
		{
			return _fileContext.Families;
		}


		public async Task UpdateFamilyAsync(Family updatedFamily)
		{
			// Get the old Family
			Family oldFamily = _fileContext.Families.FirstOrDefault(f =>
				f.StreetName == updatedFamily.StreetName && f.HouseNumber == updatedFamily.HouseNumber);
			// Get Index in list of Family
			int familyIdx = _fileContext.Families.IndexOf(oldFamily);
			// Remove old Family
			_fileContext.Families.RemoveAt(familyIdx);
			// Insert new Family
			_fileContext.Families.Insert(familyIdx, updatedFamily);
			_fileContext.SaveChanges();
		}

		public bool Exists(Family family)
		{
			Family v = _fileContext.Families.FirstOrDefault(f =>
				f.StreetName == family.StreetName && f.HouseNumber == family.HouseNumber);
			return v != null;
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