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
    public class HInformationsController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public HInformationsController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/HInformations
        [HttpGet]
        public async Task<IActionResult> GetHInformations()
        {
            return Ok(await _context.HInformations.ToListAsync());
        }

        // GET: api/HInformations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHInformation(int id)
        {
            var hInformation = await _context.HInformations.FindAsync(id);

            if (hInformation == null)
            {
                return NotFound();
            }

            return Ok(hInformation);
        }

        // PUT: api/HInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHInformation(int id, HInformation hInformation)
        {
            if (id != hInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(hInformation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(hInformation);
        }

        // POST: api/HInformations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostHInformation(HInformation hInformation)
        {
            _context.HInformations.Add(hInformation);
            await _context.SaveChangesAsync();
            return Ok(hInformation);
        }

        // DELETE: api/HInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHInformation(int id)
        {
            var hInformation = await _context.HInformations.FindAsync(id);
            if (hInformation == null)
            {
                return NotFound();
            }

            _context.HInformations.Remove(hInformation);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
