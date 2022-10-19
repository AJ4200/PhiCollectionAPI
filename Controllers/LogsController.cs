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
    public class LogsController : ControllerBase
    {
        private readonly PhiCollectionContext _context;

        public LogsController(PhiCollectionContext context)
        {
            _context = context;
        }

        // GET: api/Collections
        [HttpGet("RequestLogs")]
        public async Task<ActionResult<IEnumerable<RequestLog>>> GetRequestLogs()
        {
            if (_context.RequestLogs == null)
            {
                return NotFound();
            }
            return await _context.RequestLogs.ToListAsync();
        }

        // GET: api/Collections
        [HttpGet("CollectionLogs")]
        public async Task<ActionResult<IEnumerable<CollectionLog>>> GetCollectionLogs()
        {
            if (_context.CollectionLogs == null)
            {
                return NotFound();
            }
            return await _context.CollectionLogs.ToListAsync();
        }

        // PUT: api/Collections/5
        [HttpPut("RequestLogs/{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request)
        {
            if (id != request.RequestNumber)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        // PUT: api/Collections/5
        [HttpPut("CollectionLogs/{id}")]
        public async Task<IActionResult> PutCollection(int id, Collection collection)
        {
            if (id != collection.CollectionNumber)
            {
                return BadRequest();
            }

            _context.Entry(collection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(id))
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

        private bool RequestExists(int id)
        {
            return (_context.Requests?.Any(e => e.RequestNumber == id)).GetValueOrDefault();
        }

        private bool CollectionExists(int id)
        {
            return (_context.Collections?.Any(e => e.CollectionNumber == id)).GetValueOrDefault();
        }
    }
}
