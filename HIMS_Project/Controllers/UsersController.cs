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
    public class UsersController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public UsersController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet("{roleid}")]
        public async Task<ActionResult> GetUsers(int roleid)
        {
            if (roleid == 0)
            {
                List<User> users = _context.Users.Include(r => r.Role).OrderBy(r => r.Name).ToList();
                return Ok(users);
            }
            else
            {
                List<User> users = _context.Users.Where(r => r.Roleid == roleid).OrderBy(r => r.Name).ToList();
                return Ok(users);
            }
            //return Ok(await _context.Users.ToListAsync());
        }

        // GET: api/Users/5
        [HttpGet("{roleid}/{id}")]
        public async Task<ActionResult> GetUser(int roleid,int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
