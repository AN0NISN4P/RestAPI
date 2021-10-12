using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestAPI.FileData;
using RestAPI.Models;

namespace RestAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FamilyController : ControllerBase
	{
		private FileContext _fileContext;
		private IList<Family> _families;

		public FamilyController()
		{
			_fileContext = new();
			Console.WriteLine(_fileContext.Families.Count);
		}

		[HttpGet]
		public async Task<ActionResult<IList<Family>>> Get([FromQuery] string street, [FromQuery] int? houseNumber)
		{
			try
			{
				// Set Family List to be all families
				_families = _fileContext.Families;

				// Check if Street Name has been set
				if (street != null)
				{
					// Remove all Families living on any other street
					_families = _families.Where(f => f.StreetName == street).ToList();
				}

				// Check if House Number has been set
				if (houseNumber != null)
				{
					// Remove all Families living in a different house number
					_families = _families.Where(f => f.HouseNumber == houseNumber).ToList();
				}

				return _families.Count == 0 ? NotFound(_families) : Ok(_families);
			}
			catch (Exception e)
			{
				Console.WriteLine($"Caught Exception {e.Message}");
				return Problem(e.Message);
			}
		}

		[HttpDelete]
		public async Task<ActionResult> Delete()
		{
			return Ok();
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromQuery] int? id)
		{
			return Ok();
		}

		[HttpPatch]
		public async Task<ActionResult> Patch([FromQuery] int? id)
		{
			return Ok();
		}

		[HttpPut]
		public async Task<ActionResult> Put([FromRoute] string street, [FromRoute] int houseNumber)
		{
			return Created("", null);
		}
	}
}