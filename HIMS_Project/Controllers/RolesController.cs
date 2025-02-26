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
    public class RolesController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public RolesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public IActionResult GetRoles()
        {
            return Ok(_context.Roles.ToList());
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public IActionResult GetRole(int id)
        {
            var role =_context.Roles.Find(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutRole(int id, Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            _context.Entry(role).State = EntityState.Modified;
               _context.SaveChanges();
            return Ok(role);
        }

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return Ok(role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            var role = _context.Roles.Find(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(role);
            _context.SaveChanges();
            return Ok();
        }

        //for rolemenus
        [HttpPost("menus")]
        public IActionResult PostRoleMenus(RoleMenu roleMenu)
        {
            _context.RoleMenus.Add(roleMenu);
            _context.SaveChanges();
            return Ok(roleMenu);
        }

        [HttpGet("menus/{roleid}/{menuid}")]
        public IActionResult GetRolesMenus(int roleid,int menuid)
        {
            
            if (roleid != 0 && menuid != 0)
            {
                List<RoleMenu> RoleMenus = _context.RoleMenus.Where(r => r.Roleid == roleid && r.Menuid == menuid).ToList();
                return Ok(RoleMenus);
            }
            else if (roleid != 0 && menuid == 0)
            {
                List<RoleMenu> RoleMenus = _context.RoleMenus.Where(r => r.Roleid == roleid).Include(r=> r.Menu).ToList();
                return Ok(RoleMenus);
            }
            else if (roleid == 0 && menuid != 0)
            {
                List<RoleMenu> RoleMenus = _context.RoleMenus.Where(r => r.Menuid == menuid).Include(r => r.Role).ToList();
                return Ok(RoleMenus);
            }
            else
            {
                List<RoleMenu> RoleMenus = _context.RoleMenus.Include(r => r.Menu).Include(r => r.Role).ToList();
                return Ok(RoleMenus);
            }

        }

        [HttpGet("menus/{roleid}/{menuid}/{id}")]
        public IActionResult GetRoleMenus(int roleid,int menuid,int id)
        {
            var roleMenu = _context.RoleMenus.Find(id);

            if (roleMenu == null)
            {
                return NotFound();
            }

            return Ok(roleMenu);
        }

        [HttpDelete("menus/{id}")]
        public IActionResult DeleteRoleMenus(int id)
        {
            var roleMenu = _context.RoleMenus.Find(id);
            if (roleMenu == null)
            {
                return NotFound();
            }

            _context.RoleMenus.Remove(roleMenu);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("menus/{id}")]
        public IActionResult PutRoleMenus(int id, RoleMenu roleMenu)
        {
            if (id != roleMenu.Id)
            {
                return BadRequest();
            }

            _context.Entry(roleMenu).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(roleMenu);
        }
    }
}
