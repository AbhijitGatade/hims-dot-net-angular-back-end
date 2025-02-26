using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HIMS_Project.Context;
using HIMS_Project.Models;

namespace HIMS2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpdpatientsController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public IpdpatientsController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Ipdpatients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ipdpatient>>> GetIpdpatients()
        {
            return await _context.Ipdpatients.ToListAsync();
            //if (patientid != 0 && doctorid != 0 && concessionbyid != 0 && roomid != 0 && bedid != 0)
            //{
            //    List<Ipdpatient> Ipdpatients = _context.Ipdpatients.Where(r => r.Patientid == patientid && r.Doctorid== doctorid && r.Concessionbyid == concessionbyid && r.Roomid == roomid && r.Bedid == bedid).ToList();
            //    return Ok(Ipdpatients);
            //}
            //else if (roleid != 0 && menuid == 0)
            //{
            //    List<RoleMenu> RoleMenus = _context.RoleMenus.Where(r => r.Roleid == roleid).Include(r => r.Menu).ToList();
            //    return Ok(RoleMenus);
            //}
            //else if (roleid == 0 && menuid != 0)
            //{
            //    List<RoleMenu> RoleMenus = _context.RoleMenus.Where(r => r.Menuid == menuid).Include(r => r.Role).ToList();
            //    return Ok(RoleMenus);
            //}
            //else
            //{
            //    List<Ipdpatient> Ipdpatients = _context.Ipdpatients.Include(r => r.Patient).Include(r => r.Doctor).Include(r => r.Concessionby).Include(r => r.Room).Include(r => r.Bed).ToList();
            //    return Ok(Ipdpatients);
            //}
        }

        // GET: api/Ipdpatients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIpdpatient(int id)
        {
            var ipdpatient = await _context.Ipdpatients.FindAsync(id);

            if (ipdpatient == null)
            {
                return NotFound();
            }

            return Ok(ipdpatient);
        }

        // PUT: api/Ipdpatients/5
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpdpatient(int id, Ipdpatient ipdpatient)
        {
            if (id != ipdpatient.Id)
            {
                return BadRequest();
            }

            _context.Entry(ipdpatient).State = EntityState.Modified;

                await _context.SaveChangesAsync();

            return Ok(ipdpatient);
        }

        // POST: api/Ipdpatients
        
        [HttpPost]
        public async Task<IActionResult> PostIpdpatient(Ipdpatient ipdpatient)
        {
            _context.Ipdpatients.Add(ipdpatient);
            await _context.SaveChangesAsync();

            return Ok(ipdpatient);
        }

        // DELETE: api/Ipdpatients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIpdpatient(int id)
        {
            var ipdpatient = await _context.Ipdpatients.FindAsync(id);
            if (ipdpatient == null)
            {
                return NotFound();
            }

            _context.Ipdpatients.Remove(ipdpatient);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
