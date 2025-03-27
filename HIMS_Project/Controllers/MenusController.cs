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
    public class MenusController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public MenusController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Menus
        [HttpGet]
        public async Task<ActionResult> GetMenus()
        {
            return Ok(await _context.Menus.OrderBy(m=>m.Parentmenuid).OrderBy(m=>m.Srno).ToListAsync());
        }

        // GET: api/Menus/Childs/ParentMenuId
        [HttpGet("Childs/{parentmenuid}")]
        public async Task<ActionResult> GetChildMenus(int parentmenuid)
        {
            return Ok(await _context.Menus.Where(m => m.Parentmenuid == parentmenuid).OrderBy(m => m.Srno).ToListAsync());        
        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            return Ok(menu);
        }

        // PUT: api/Menus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu(int id, Menu menu)
        {
            if (id != menu.Id)
            {
                return BadRequest();
            }

            _context.Entry(menu).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(menu);
        }

        // POST: api/Menus
        [HttpPost]
        public async Task<ActionResult<Menu>> PostMenu(Menu menu)
        {
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();
            return Ok(menu);
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
