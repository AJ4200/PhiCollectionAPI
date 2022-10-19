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
    public class StaffsController : ControllerBase
    {
        private readonly PhiCollectionContext _context;

        public StaffsController(PhiCollectionContext context)
        {
            _context = context;
        }

        // GET: api/Staffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetSaff()
        {
            if (_context.Staff == null)
            {
                return NotFound();
            }
            return await _context.Staff.Where(s => s.Active.Equals(true)).ToListAsync();
        }

        // GET: api/Staffs
        [HttpGet]
        [Route("Supervisors")]
        public async Task<ActionResult<IEnumerable<Supervisor>>> GetSupervisor()
        {
          if (_context.Supervisors == null)
          {
              return NotFound();
          }
            return await _context.Supervisors.ToListAsync();
        }

        // GET: api/Staffs
        [HttpGet]
        [Route("Drivers")]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
        {
            if (_context.Drivers == null)
            {
                return NotFound();
            }
            return await _context.Drivers.ToListAsync();
        }

        // GET: api/Staffs
        [HttpGet]
        [Route("Admins")]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            if (_context.Admins == null)
            {
                return NotFound();
            }
            return await _context.Admins.ToListAsync();
        }

        // GET: api/Staffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(string id)
        {
          if (_context.Staff == null)
          {
              return NotFound();
          }
            var staff = await _context.Staff.FindAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            return staff;
        }

        // GET: api/Staffs/5
        [HttpGet]
        [Route("Login/{email}/{password}")]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (_context.Staff == null)
            {
                return NotFound();
            }
            var staff = await _context.Staff.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();

            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }

        // PUT: api/Staffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(string id, Staff staff)
        {
            if (id != staff.StaffId)
            {
                return BadRequest();
            }

            if (staff.Dtype != "Driver")
            {
                staff.LicenceNumber = null;
            }

            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
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

        // POST: api/Staffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            if (_context.Staff == null)
            {
                return Problem("Entity set 'PhiCollectionContext.Staff'  is null.");
            }

            if(staff.Dtype != "Driver")
            {
                staff.LicenceNumber = null;
            }

            _context.Staff.Add(staff);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StaffExists(staff.StaffId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStaff", new { id = staff.StaffId }, staff);
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(string id)
        {
            if (_context.Staff == null)
            {
                return NotFound();
            }
            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            staff.Active = false;

            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
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

        private bool StaffExists(string id)
        {
            return (_context.Staff?.Any(e => e.StaffId == id)).GetValueOrDefault();
        }
    }
}
