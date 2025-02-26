using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HIMS_Project.Context;
using HIMS_Project.Models;

namespace HIMSHIMS_Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpdcompaniesController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public IpdcompaniesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Ipdcompanies
        [HttpGet]
        public async Task<IActionResult> GetIpdcompanies()
        {
            return Ok(await _context.Ipdcompanies.ToListAsync());
        }

        // GET: api/Ipdcompanies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIpdcompany(int id)
        {
            var ipdcompany = await _context.Ipdcompanies.FindAsync(id);

            if (ipdcompany == null)
            {
                return NotFound();
            }

            return Ok(ipdcompany);
        }

        // PUT: api/Ipdcompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpdcompany(int id, Ipdcompany ipdcompany)
        {
            if (id != ipdcompany.Id)
            {
                return BadRequest();
            }

            _context.Entry(ipdcompany).State = EntityState.Modified;

            return Ok(ipdcompany);
        }

        // POST: api/Ipdcompanies
     
        [HttpPost]
        public async Task<IActionResult> PostIpdcompany(Ipdcompany ipdcompany)
        {
            _context.Ipdcompanies.Add(ipdcompany);
            await _context.SaveChangesAsync();

            return Ok(ipdcompany);
        }

        // DELETE: api/Ipdcompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIpdcompany(int id)
        {
            var ipdcompany = await _context.Ipdcompanies.FindAsync(id);
            if (ipdcompany == null)
            {
                return NotFound();
            }

            _context.Ipdcompanies.Remove(ipdcompany);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
