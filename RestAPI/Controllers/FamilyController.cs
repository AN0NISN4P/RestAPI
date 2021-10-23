using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Data;
using RestAPI.Models;

namespace RestAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FamilyController : ControllerBase
	{
		private IPersonHandler _personHandler;

		public FamilyController(IPersonHandler personHandler)
		{
			_personHandler = personHandler;
		}

		[HttpGet]
		public async Task<ActionResult<IList<Family>>> Get([FromQuery] string street, [FromQuery] int? houseNumber)
		{
			try
			{
				IList<Family> f;
				if (houseNumber == null)
				{
					f = _personHandler.GetFamily(street);
				}
				else
				{
					f = _personHandler.GetFamily(street, (int) houseNumber);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return StatusCode(500, e.Message);
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