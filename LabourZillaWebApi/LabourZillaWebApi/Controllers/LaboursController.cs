using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabourZillaWebApi.Models;

namespace LabourZillaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboursController : ControllerBase
    {
        private readonly LabourZillaZoneContext _context;

        public LaboursController(LabourZillaZoneContext context)
        {
            _context = context;
        }

        // GET: api/Labours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Labour>>> GetLabour()
        {
            return await _context.Labour.ToListAsync();
        }

        // GET: api/Labours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Labour>> GetLabour(int id)
        {
            var labour = await _context.Labour.FindAsync(id);

            if (labour == null)
            {
                return NotFound();
            }

            return labour;
        }

        // PUT: api/Labours/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLabour(int id, Labour labour)
        {
            if (id != labour.Id)
            {
                return BadRequest();
            }

            _context.Entry(labour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabourExists(id))
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

        // POST: api/Labours
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Labour>> PostLabour(Labour labour)
        {
            _context.Labour.Add(labour);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLabour", new { id = labour.Id }, labour);
        }

        // DELETE: api/Labours/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Labour>> DeleteLabour(int id)
        {
            var labour = await _context.Labour.FindAsync(id);
            if (labour == null)
            {
                return NotFound();
            }

            _context.Labour.Remove(labour);
            await _context.SaveChangesAsync();

            return labour;
        }

        private bool LabourExists(int id)
        {
            return _context.Labour.Any(e => e.Id == id);
        }
    }
}
