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
    public class BinsController : ControllerBase
    {
        private readonly PhiCollectionContext _context;

        public BinsController(PhiCollectionContext context)
        {
            _context = context;
        }

        // GET: api/Bins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bin>>> GetBins()
        {
            if (_context.Bins == null)
            {
                return NotFound();
            }
            return await _context.Bins.Where(b => b.Active.Equals(true)).ToListAsync();
        }

        // GET: api/Bins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bin>> GetBin(string id)
        {
            if (_context.Bins == null)
            {
                return NotFound();
            }
            var bin = await _context.Bins.FindAsync(id);

            if (bin == null)
            {
                return NotFound();
            }

            return bin;
        }

        // PUT: api/Bins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBin(string id, Bin bin)
        {
            if (id != bin.BinId)
            {
                return BadRequest();
            }

            _context.Entry(bin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BinExists(id))
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

        // POST: api/Bins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bin>> PostBin(Bin bin)
        {
            if (_context.Bins == null)
            {
                return Problem("Entity set 'PhiCollectionContext.Bins'  is null.");
            }
            _context.Bins.Add(bin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BinExists(bin.BinId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBin", new { id = bin.BinId }, bin);
        }

        // DELETE: api/Bins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBin(string id)
        {
            if (_context.Bins == null)
            {
                return NotFound();
            }
            var bin = await _context.Bins.FindAsync(id);
            if (bin == null)
            {
                return NotFound();
            }

            bin.Active = false;
            _context.Entry(bin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BinExists(id))
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

        private bool BinExists(string id)
        {
            return (_context.Bins?.Any(e => e.BinId == id)).GetValueOrDefault();
        }
    }
}
