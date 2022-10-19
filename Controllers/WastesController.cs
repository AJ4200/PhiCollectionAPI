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
    public class WastesController : ControllerBase
    {
        private readonly PhiCollectionContext _context;

        public WastesController(PhiCollectionContext context)
        {
            _context = context;
        }

        // GET: api/Wastes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Waste>>> GetWastes()
        {
          if (_context.Wastes == null)
          {
              return NotFound();
          }
            return await _context.Wastes.ToListAsync();
        }

        // GET: api/Wastes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Waste>> GetWaste(int id)
        {
          if (_context.Wastes == null)
          {
              return NotFound();
          }
            var waste = await _context.Wastes.FindAsync(id);

            if (waste == null)
            {
                return NotFound();
            }

            return waste;
        }

        // PUT: api/Wastes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaste(int id, Waste waste)
        {
            if (id != waste.WasteNumber)
            {
                return BadRequest();
            }

            _context.Entry(waste).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WasteExists(id))
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

        // POST: api/Wastes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Waste>> PostWaste(Waste waste)
        {
          if (_context.Wastes == null)
          {
              return Problem("Entity set 'PhiCollectionContext.Wastes'  is null.");
          }
            _context.Wastes.Add(waste);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaste", new { id = waste.WasteNumber }, waste);
        }

        // DELETE: api/Wastes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWaste(int id)
        {
            if (_context.Wastes == null)
            {
                return NotFound();
            }
            var waste = await _context.Wastes.FindAsync(id);
            if (waste == null)
            {
                return NotFound();
            }

            _context.Wastes.Remove(waste);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WasteExists(int id)
        {
            return (_context.Wastes?.Any(e => e.WasteNumber == id)).GetValueOrDefault();
        }
    }
}
