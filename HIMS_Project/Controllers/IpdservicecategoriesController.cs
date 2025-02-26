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
    public class IpdservicecategoriesController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public IpdservicecategoriesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Ipdservicecategories
        [HttpGet]
        public async Task<IActionResult> GetIpdservicecategories()
        {
            return Ok(await _context.Ipdservicecategories.ToListAsync());
        }

        // GET: api/Ipdservicecategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetIpdservicecategory(int id)
        {
            var ipdservicecategory = await _context.Ipdservicecategories.FindAsync(id);

            if (ipdservicecategory == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ipdservicecategory);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpdservicecategory(int id, Ipdservicecategory ipdservicecategory)
        {
            if (id != ipdservicecategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(ipdservicecategory).State = EntityState.Modified;

            return Ok(ipdservicecategory);
        }

        [HttpPost]
        public async Task<ActionResult> PostIpdservicecategory(Ipdservicecategory ipdservicecategory)
        {
            _context.Ipdservicecategories.Add(ipdservicecategory);
            await _context.SaveChangesAsync();

            return Ok(ipdservicecategory);
        }

        // DELETE: api/Ipdservicecategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIpdservicecategory(int id)
        {
            var ipdservicecategory = await _context.Ipdservicecategories.FindAsync(id);
            if (ipdservicecategory == null)
            {
                return NotFound();
            }

            _context.Ipdservicecategories.Remove(ipdservicecategory);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
