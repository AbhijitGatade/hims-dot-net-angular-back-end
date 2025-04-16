using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HIMS_Project.Context;
using HIMS_Project.Models;

namespace HIMS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DischargeSummariesController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public DischargeSummariesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/DischargeSummaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DischargeSummaries>>> GetDischargeSummaries()
        {
            return await _context.DischargeSummaries.ToListAsync();
        }

        // GET: api/DischargeSummaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DischargeSummaries>> GetDischargeSummaries(int id)
        {
            var dischargeSummaries = await _context.DischargeSummaries.FindAsync(id);

            if (dischargeSummaries == null)
            {
                return NotFound();
            }

            return dischargeSummaries;
        }

        // PUT: api/DischargeSummaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDischargeSummaries(int id, DischargeSummaries dischargeSummaries)
        {
            if (id != dischargeSummaries.id)
            {
                return BadRequest();
            }

            _context.Entry(dischargeSummaries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DischargeSummariesExists(id))
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

        // POST: api/DischargeSummaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DischargeSummaries>> PostDischargeSummaries(DischargeSummaries dischargeSummaries)
        {
            _context.DischargeSummaries.Add(dischargeSummaries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDischargeSummaries", new { id = dischargeSummaries.id }, dischargeSummaries);
        }

        // DELETE: api/DischargeSummaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDischargeSummaries(int id)
        {
            var dischargeSummaries = await _context.DischargeSummaries.FindAsync(id);
            if (dischargeSummaries == null)
            {
                return NotFound();
            }

            _context.DischargeSummaries.Remove(dischargeSummaries);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DischargeSummariesExists(int id)
        {
            return _context.DischargeSummaries.Any(e => e.id == id);
        }
    }
}
