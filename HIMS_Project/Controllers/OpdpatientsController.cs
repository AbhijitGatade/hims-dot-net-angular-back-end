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
    public class OpdpatientsController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public OpdpatientsController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Opdpatients
        //[HttpGet("{patientid}/{doctorid}")]
        //public async Task<IActionResult> GetOpdpatients(int patientid,int doctorid)
        //{
        //    //return Ok(await _context.Opdpatients.ToListAsync());
           
        //    if (patientid != 0 && doctorid != 0)
        //    {
        //        List<Opdpatient> Opdpatients = _context.Opdpatients.Where(r => r.Patientid == patientid && r.Doctorid == doctorid).ToList();
        //        return Ok(Opdpatients);
        //    }
        //    else if (patientid != 0 && doctorid == 0)
        //    {
        //        List<Opdpatient> Opdpatients = _context.Opdpatients.Where(r => r.Patientid == patientid).Include(r => r.Doctor).ToList();
        //        return Ok(Opdpatients);
        //    }
        //    else if (patientid == 0 && doctorid != 0)
        //    {
        //        List<Opdpatient> Opdpatients = _context.Opdpatients.Where(r => r.Doctorid == doctorid).Include(r => r.Patient).ToList();
        //        return Ok(Opdpatients);
        //    }
        //    else
        //    {
        //        List<Opdpatient> Opdpatients = _context.Opdpatients.Include(r => r.Patient).Include(r => r.Doctor).ToList();
        //        return Ok(Opdpatients);
        //    }


        //}

        // GET: api/Opdpatients/5
        [HttpGet("{opdid}")]
        public async Task<IActionResult> GetOpdpatient(int opdid)
        {
            var OpdPatients = await (from op in _context.Opdpatients
                                     join p in _context.Patients on op.Patientid equals p.Id
                                     where op.Id == opdid
                                     join d in _context.Doctors on op.Doctorid equals d.Id
                                     where op.Doctorid == d.Id
                                     join rf in _context.Doctors on op.Refdoctorid equals rf.Id // Join for the referring doctor
                                     where op.Refdoctorid == rf.Id
                                     join c in _context.Companies on op.Companyid equals c.Id // Join for the referring doctor
                                     where op.Companyid == c.Id
                                     select new
                                     {
                                         Op = op,
                                         PatientName = p.Name,  // Renaming Patient's Name to PatientName
                                         p.Uidno,
                                         p.Prefix,
                                         p.address,
                                         p.MobileNo,
                                         CompanyName =c.Name,
                                         DoctorName = d.Name,  // Renaming Doctor's Name to DoctorName
                                         DoctorId = d.Id,
                                         ReferralDoctor = rf.Name,  // Renaming Referring Doctor's Name to ReferringDoctorName
                                         ReferralDoctorId = rf.Id
                                     }).FirstOrDefaultAsync();

            return Ok(OpdPatients);


        }

        // PUT: api/Opdpatients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOpdpatient(int id, Opdpatient opdpatient)
        //{
        //    if (id != opdpatient.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(opdpatient).State = EntityState.Modified;


        //    await _context.SaveChangesAsync();


        //    return Ok(opdpatient);
        //}

        // POST: api/Opdpatients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostOpdpatient(Opdpatient opdpatient)
        {
            _context.Opdpatients.Add(opdpatient);
            await _context.SaveChangesAsync();
            return Ok(opdpatient);
        }

        // DELETE: api/Opdpatients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpdpatient(int id)
        {
            var opdpatient = await _context.Opdpatients.FindAsync(id);
            if (opdpatient == null)
            {
                return NotFound();
            }

            _context.Opdpatients.Remove(opdpatient);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}