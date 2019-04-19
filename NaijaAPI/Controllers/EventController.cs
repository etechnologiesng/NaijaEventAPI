using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NaijaEventAPI.Data;
using NaijaEventAPI.Models;

namespace NaijaEventAPI.Controllers
{

	[Route("api/[controller]")]
	public class EventController : Controller
	{

		EventContext _context;
		public EventController(EventContext context)
		{
			_context = context;
			//  _context.ChangeTracker.QueryTrackingBehavior=QueryTrackingBehavior.NoTracking;
		}


		// GET api/Trips
		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{

			var trips = await _context.Events
				.AsNoTracking()
				.ToListAsync();
			return Ok(trips);

		}

		// GET api/Trips/5
		[HttpGet("{id}")]
		public Event Get(int id)
		{
			return _context.Events.Find(id);
		}

		// POST api/Trips
		[HttpPost]
		public IActionResult Post([FromBody]Event value)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_context.Events.Add(value);
			_context.SaveChanges();

			return Ok();

		}

		// PUT api/Trips/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody]Event value)
		{

			if (!_context.Events.Any(t => t.Id == id))
			{
				return NotFound();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			//what about nulls?
			_context.Events.Update(value);
			await _context.SaveChangesAsync();

			return Ok();

		}

		// DELETE api/Trips/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{

			var myTrip = _context.Events.Find(id);

			if (myTrip == null)
			{
				return NotFound();
			}

			_context.Events.Remove(myTrip);
			_context.SaveChanges();

			// DELETE FROM Trips WHERE id=?

			return NoContent();

		}
	}
}
