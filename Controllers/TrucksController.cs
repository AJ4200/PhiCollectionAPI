using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhiCollectionAPI.Data;
using PhiCollectionAPI.Models;

namespace PhiCollectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private readonly PhiCollectionContext _context;

        public TrucksController(PhiCollectionContext context)
        {
            _context = context;
        }

        // GET: api/Trucks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TruckView>>> GetTrucks()
        {
            if (_context.Trucks == null)
            {
                return NotFound();
            }
            return await _context.TruckViews.ToListAsync();
        }

        // GET: api/Trucks
        [HttpGet("TruckIssues")]
        public async Task<ActionResult<IEnumerable<TruckIssue>>> GetIssueTrucks()
        {
            if (_context.TruckIssues == null)
            {
                return NotFound();
            }
            return await _context.TruckIssues.ToListAsync();
        }

        // GET: api/Trucks
        [HttpGet("Queue")]
        public async Task<ActionResult<IEnumerable<TruckQueue>>> GetQueue()
        {
            if (_context.Trucks == null)
            {
                return NotFound();
            }
            return await _context.TruckQueues.ToListAsync();
        }

        // GET: api/Trucks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Truck>> GetTruck(string id)
        {
            if (_context.Trucks == null)
            {
                return NotFound();
            }
            var truck = await _context.Trucks.FindAsync(id);

            if (truck == null)
            {
                return NotFound();
            }

            return truck;
        }

        // PUT: api/Trucks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTruck(string id, Truck truck)
        {
            if (id != truck.TruckId)
            {
                return BadRequest();
            }

            _context.Entry(truck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TruckExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Trucks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Truck>> PostTruck(Truck truck)
        {
            if (_context.Trucks == null)
            {
                return Problem("Entity set 'PhiCollectionContext.Trucks'  is null.");
            }
            _context.Trucks.Add(truck);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TruckExists(truck.TruckId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTruck", new { id = truck.TruckId }, truck);
        }

        // DELETE: api/Trucks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTruck(string id)
        {
            if (_context.Trucks == null)
            {
                return NotFound();
            }
            var truck = await _context.Trucks.FindAsync(id);
            if (truck == null)
            {
                return NotFound();
            }

            truck.Active = false;
            _context.Entry(truck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TruckExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool TruckExists(string id)
        {
            return (_context.Trucks?.Any(e => e.TruckId == id)).GetValueOrDefault();
        }
    }
}
