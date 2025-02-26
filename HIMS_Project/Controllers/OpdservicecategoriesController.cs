using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HIMS_Project.Context;
using HIMS_Project.Models;

namespace HIMSProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpdservicecategoriesController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public OpdservicecategoriesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Opdservicecategories
        [HttpGet]
        public async Task<IActionResult> GetOpdservicecategories()
        {
            return Ok(await _context.Opdservicecategories.ToListAsync());
        }

        // GET: api/Opdservicecategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOpdservicecategory(int id)
        {
            var opdservicecategory = await _context.Opdservicecategories.FindAsync(id);

            if (opdservicecategory == null)
            {
                return NotFound();
            }

            return Ok(opdservicecategory);
        }

        // PUT: api/Opdservicecategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOpdservicecategory(int id, Opdservicecategory opdservicecategory)
        {
            if (id != opdservicecategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(opdservicecategory).State = EntityState.Modified;


            await _context.SaveChangesAsync();

            return Ok(opdservicecategory);
        }

        // POST: api/Opdservicecategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostOpdservicecategory(Opdservicecategory opdservicecategory)
        {
            _context.Opdservicecategories.Add(opdservicecategory);
            await _context.SaveChangesAsync();

            return Ok(opdservicecategory);
        }

        // DELETE: api/Opdservicecategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpdservicecategory(int id)
        {
            var opdservicecategory = await _context.Opdservicecategories.FindAsync(id);
            if (opdservicecategory == null)
            {
                return NotFound();
            }

            _context.Opdservicecategories.Remove(opdservicecategory);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}