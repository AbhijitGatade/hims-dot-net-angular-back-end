using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HIMS_Project.Context;
using HIMS_Project.Models;

namespace HIMSProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpdbillsController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public OpdbillsController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Opdbills
        [HttpGet("{concessionbyid}/{opdpatientid}")]
        public async Task<IActionResult> GetOpdbills(int concessionbyid,int opdpatientid)
        {
            //return Ok(await _context.Opdbills.ToListAsync());
            if (concessionbyid != 0 && opdpatientid != 0)
            {
                List<Opdbill> Opdbills = _context.Opdbills.Where(r => r.Concessionbyid == concessionbyid && r.Opdid == opdpatientid).ToList();
                return Ok(Opdbills);
            }
            else if (concessionbyid != 0 && opdpatientid == 0)
            {
                List<Opdbill> Opdbills = _context.Opdbills.Where(r => r.Concessionbyid == concessionbyid).Include(r => r.Opd).ToList();
                return Ok(Opdbills);
            }

            else if (concessionbyid == 0 && opdpatientid != 0)
            {
                List<Opdbill> Opdbills = _context.Opdbills.Where(r => r.Opdid == opdpatientid).Include(r => r.Concessionby).ToList();
                return Ok(Opdbills);
            }
            else
            {
                List<Opdbill> Opdbills = _context.Opdbills.Include(r => r.Opd).Include(r => r.Concessionby).ToList();
                return Ok(Opdbills);
            }
        }

        // GET: api/Opdbills/5
        [HttpGet("{concessionbyid}/{opdpatientid}/{id}")]
        public async Task<IActionResult> GetOpdbill(int concessionbyid, int opdpatientid,int id)
        {
            var opdbill = await _context.Opdbills.FindAsync(id);

            if (opdbill == null)
            {
                return NotFound();
            }

            return Ok(opdbill);
        }

        // PUT: api/Opdbills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOpdbill(int id, Opdbill opdbill)
        {
            if (id != opdbill.Id)
            {
                return BadRequest();
            }

            _context.Entry(opdbill).State = EntityState.Modified;

          
                await _context.SaveChangesAsync();
            
            return Ok(opdbill);
        }

        // POST: api/Opdbills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostOpdbill(Opdbill opdbill)
        {
            _context.Opdbills.Add(opdbill);
            await _context.SaveChangesAsync();
            return Ok(opdbill);
        }

        // DELETE: api/Opdbills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpdbill(int id)
        {
            var opdbill = await _context.Opdbills.FindAsync(id);
            if (opdbill == null)
            {
                return Ok(NotFound());
            }

            _context.Opdbills.Remove(opdbill);
            await _context.SaveChangesAsync();

            return Ok();
        }

     
    }
}
