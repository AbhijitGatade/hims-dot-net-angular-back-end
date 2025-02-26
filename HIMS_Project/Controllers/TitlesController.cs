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
    public class TitlesController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public TitlesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Titles
        [HttpGet]
        public async Task<IActionResult> GetTitles()
        {
            return Ok(await _context.Titles.ToListAsync());
        }

        // GET: api/Titles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTitle(int id)
        {
            var title = await _context.Titles.FindAsync(id);

            if (title == null)
            {
                return NotFound();
            }

            return Ok(title);
        }

        // PUT: api/Titles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitle(int id, Title title)
        {
            if (id != title.Id)
            {
                return BadRequest();
            }

            _context.Entry(title).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(title);
        }

        // POST: api/Titles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Title>> PostTitle(Title title)
        {
            _context.Titles.Add(title);
            await _context.SaveChangesAsync();
            return Ok(title);
        }

        // DELETE: api/Titles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitle(int id)
        {
            var title = await _context.Titles.FindAsync(id);
            if (title == null)
            {
                return NotFound();
            }

            _context.Titles.Remove(title);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}
