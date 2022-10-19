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
    public class LocationsController : ControllerBase
    {
        private readonly PhiCollectionContext _context;

        public LocationsController(PhiCollectionContext context)
        {
            _context = context;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            if (_context.Locations == null)
            {
                return NotFound();
            }
            return await _context.Locations.Where(l => l.Active.Equals(true)).ToListAsync();
        }

        // GET: api/Locations
        [HttpGet]
        [Route("ControlStations")]
        public async Task<ActionResult<IEnumerable<ControlStation>>> GetControlStations()
        {
            if (_context.ControlStations == null)
            {
                return NotFound();
            }
            return await _context.ControlStations.ToListAsync();
        }

        // GET: api/Locations
        [HttpGet]
        [Route("GardenSites")]
        public async Task<ActionResult<IEnumerable<GardenSite>>> GetGardenSites()
        {
            if (_context.GardenSites == null)
            {
                return NotFound();
            }
            return await _context.GardenSites.ToListAsync();
        }

        // GET: api/Locations
        [HttpGet]
        [Route("Landfills")]
        public async Task<ActionResult<IEnumerable<Landfill>>> GetLandfills()
        {
            if (_context.Landfills == null)
            {
                return NotFound();
            }
            return await _context.Landfills.ToListAsync();
        }

        // GET: api/Locations
        [HttpGet("Recyclers")]
        public async Task<ActionResult<IEnumerable<Recycler>>> GetRecyclers()
        {
            if (_context.Recyclers == null)
            {
                return NotFound();
            }
            return await _context.Recyclers.ToListAsync();
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(string id)
        {
            if (_context.Locations == null)
            {
                return NotFound();
            }
            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        // GET: api/Locations/5
        [HttpGet("Recycler/{id}")]
        public async Task<ActionResult<Recycler>> GetRecycler(string id)
        {
            if (_context.Recyclers == null)
            {
                return NotFound();
            }
            var recycler = await _context.Recyclers.FindAsync(id);

            if (recycler == null)
            {
                return NotFound();
            }

            return recycler;
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(string id, Location location)
        {
            if (id != location.LocationId)
            {
                return BadRequest();
            }

            if (location.Dtype != "Garden Site")
            {
                location.Supervisor = null;
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            if (_context.Locations == null)
            {
                return Problem("Entity set 'PhiCollectionContext.Locations'  is null.");
            }

            if (location.Dtype != "Garden Site")
            {
                location.Supervisor = null;
            }
            _context.Locations.Add(location);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LocationExists(location.LocationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLocation", new { id = location.LocationId }, location);
        }

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Recycler")]
        public async Task<ActionResult<Location>> PostRecycler(Recycler recycler)
        {
            if (_context.Recyclers == null)
            {
                return Problem("Entity set 'PhiCollectionContext.Locations'  is null.");
            }

            _context.Recyclers.Add(recycler);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LocationExists(recycler.RecyclerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRecycler", new { id = recycler.RecyclerId }, recycler);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(string id)
        {
            if (_context.Locations == null)
            {
                return NotFound();
            }
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            if (location.Dtype == "Recycler")
            {
                var recycler = await _context.Recyclers.FindAsync(id);
                if (recycler == null)
                {
                    return NotFound();
                }

                recycler.Active = false;
            }

            location.Active = false;
            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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

        private bool LocationExists(string id)
        {
            return (_context.Locations?.Any(e => e.LocationId == id)).GetValueOrDefault();
        }


    }
}
