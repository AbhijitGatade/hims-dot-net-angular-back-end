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
        [HttpGet("{ipdid}")]
        public async Task<IActionResult> GetIpdpatient(int ipdid)
        {
                var IpdPatients = await (from ip in _context.Ipdpatients
                                         join p in _context.Patients on ip.Patientid equals p.Id
                                         where ip.Id == ipdid
                                         join d in _context.Doctors on ip.Doctorid equals d.Id
                                         where ip.Doctorid == d.Id
                                         join rf in _context.Doctors on ip.Refdoctorid equals rf.Id // Join for the referring doctor
                                         where ip.Refdoctorid == rf.Id
                                         join c in _context.Companies on ip.Companyid equals c.Id // Join for the referring doctor
                                         where ip.Companyid == c.Id
                                         select new
                                         {
                                             Ip = ip,
                                             PatientName = p.Name,  // Renaming Patient's Name to PatientName
                                             p.Uidno,
                                             p.Prefix,
                                             p.address,
                                             p.MobileNo,
                                             CompanyName = c.Name,
                                             DoctorName = d.Name,  // Renaming Doctor's Name to DoctorName
                                             DoctorId = d.Id,
                                             ReferralDoctor = rf.Name,  // Renaming Referring Doctor's Name to ReferringDoctorName
                                             ReferralDoctorId = rf.Id
                                         }).FirstOrDefaultAsync();

                return Ok(IpdPatients);


            
        }

        // PUT: api/Ipdpatients/5
       
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutIpdpatient(int id, Ipdpatient ipdpatient)
        //{
        //    if (id != ipdpatient.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(ipdpatient).State = EntityState.Modified;

        //        await _context.SaveChangesAsync();

        //    return Ok(ipdpatient);
        //}

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
