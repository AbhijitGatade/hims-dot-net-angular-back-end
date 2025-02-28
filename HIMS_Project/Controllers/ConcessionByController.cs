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
    public class ConcessionByController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public ConcessionByController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/ConcessionBy
        [HttpGet]
        public async Task<IActionResult> GetConcessionBies()
        {
            return Ok(await _context.ConcessionBies.ToListAsync());
        }

        // GET: api/ConcessionBy/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetConcessionBy(int id)
        {
            var concessionBy = await _context.ConcessionBies.FindAsync(id);

            if (concessionBy == null)
            {
                return NotFound();
            }

            return Ok(concessionBy);
        }

        // PUT: api/ConcessionBy/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcessionBy(int id, ConcessionBy concessionBy)
        {
            if (id != concessionBy.Id)
            {
                return BadRequest();
            }

            _context.Entry(concessionBy).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(concessionBy);
        }

        // POST: api/ConcessionBy
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostConcessionBy(ConcessionBy concessionBy)
        {
            _context.ConcessionBies.Add(concessionBy);
            await _context.SaveChangesAsync();
            return Ok(concessionBy);
        }

        // DELETE: api/ConcessionBy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcessionBy(int id)
        {
            var concessionBy = await _context.ConcessionBies.FindAsync(id);
            if (concessionBy == null)
            {
                return NotFound();
            }

            _context.ConcessionBies.Remove(concessionBy);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
