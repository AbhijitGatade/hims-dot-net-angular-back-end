using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HIMS_Project.Context;
using HIMS_Project.Models;
using System.Data;

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

        [HttpPost]
        public IActionResult PostRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return Ok(role);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            var role = _context.Roles.Find(id);
            _context.Roles.Remove(role);
            _context.SaveChanges();
            return Ok();
        }
        

        [HttpGet("menus/{roleid}")]
        public IActionResult GetRolesMenus(int roleid)
        {
            var result = from m in _context.Menus
                         join rm in _context.RoleMenus
                         on new { MenuId = m.Id, RoleId = roleid } equals new { MenuId = rm.Menuid, RoleId = rm.Roleid }
                         into roleMenusGroup // Left Join
                         from rm in roleMenusGroup.DefaultIfEmpty()
                         where m.Isparentmenu.Equals("true")
                         orderby m.Parentmenuid, m.Srno
                         select new
                         {
                             m,
                             RmId = rm != null ? rm.Id : 0
                         };

            return Ok(result);
        }

        [HttpPost("menu/{roleid}/{menuid}")]
        public IActionResult PostRoleMneu(int roleid, int menuid)
        {
            RoleMenu roleMenu = new RoleMenu() { Id = 0, Roleid = roleid, Menuid = menuid };
            _context.RoleMenus.Add(roleMenu);
            _context.SaveChanges();
            return Ok(roleMenu);
        }

        [HttpDelete("menu/{id}")]
        public IActionResult DeleteRoleMenu(int id)
        {
            var roleMenu = _context.RoleMenus.Find(id);
            if (roleMenu != null)
            {
                _context.RoleMenus.Remove(roleMenu);
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}
