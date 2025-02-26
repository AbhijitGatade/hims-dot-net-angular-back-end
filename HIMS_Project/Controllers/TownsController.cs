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
    public class TownsController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public TownsController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Towns
        [HttpGet]
        public async Task<IActionResult> GetTowns()
        {
            return Ok(await _context.Towns.ToListAsync());
        }

        // GET: api/Towns/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTown(int id)
        {
            var town = await _context.Towns.FindAsync(id);

            if (town == null)
            {
                return NotFound();
            }

            return Ok(town);
        }

        // PUT: api/Towns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTown(int id, Town town)
        {
            if (id != town.Id)
            {
                return BadRequest();
            }

            _context.Entry(town).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            return Ok(town);
        }

        // POST: api/Towns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTown(Town town)
        {
            _context.Towns.Add(town);
            await _context.SaveChangesAsync();
            return Ok(town);
        }

        // DELETE: api/Towns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTown(int id)
        {
            var town = await _context.Towns.FindAsync(id);
            if (town == null)
            {
                return NotFound();
            }

            _context.Towns.Remove(town);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
