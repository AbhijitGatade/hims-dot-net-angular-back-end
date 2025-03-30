using Microsoft.AspNetCore.Mvc;
using HIMS_Project.Context;
using HIMS_Project.Models;
using HIMS_Project.DTOs;
using HIMS_Project.Services;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        public readonly IPatientService _patientService;

        public PatientsController(ProjectDBContext context, IPatientService patientService)
        {
            _context = context;
            _patientService = patientService;
        }


        // GET: api/Patients
        [HttpGet("{ptype}")]
        public async Task<ActionResult> GetPatients(string ptype)
        {
            if (ptype.Equals("ipd"))
            {
                var query = from IP in _context.Ipdpatients
                            join P in _context.Patients on IP.Patientid equals P.Id
                            join D in _context.Doctors on IP.Doctorid equals D.Id into docGroup
                            from D in docGroup.DefaultIfEmpty() // Left Join
                            join R in _context.Rooms on IP.Roomid equals R.Id into roomGroup
                            from R in roomGroup.DefaultIfEmpty()
                            join B in _context.Beds on IP.Bedid equals B.Id into bedGroup
                            from B in bedGroup.DefaultIfEmpty()
                            join RD in _context.Doctors on IP.Refdoctorid equals RD.Id into refDocGroup
                            from RD in refDocGroup.DefaultIfEmpty()
                            join T in _context.Towns on P.townid equals T.Id into townGroup
                            from T in townGroup.DefaultIfEmpty()
                            orderby IP.Admissiondate descending
                            select new
                            {
                                Ipdid = IP.Id,
                                IP.Patientid,
                                Name = P.Prefix + " " + P.Name,
                                P.Uidno,
                                P.Age,
                                P.Gender,
                                Mobileno = P.MobileNo,
                                P.address,
                                Townname = T != null ? T.Name : null,  // Handle NULL towns
                                Admissiondate = IP.Admissiondate,
                                IP.Admissiontime,
                                Doctorname = D != null ? D.Name : null,
                                IP.Dischargedas,
                                Roomname = R != null ? R.Name : null,
                                Bedname = B != null ? B.Name : null,
                                Billamount = IP.Billamount != null ? IP.Billamount : 0,
                                Paidamount = IP.Paidamount != null ? IP.Paidamount : 0,
                                Refdoctorname = RD != null ? RD.Name : null
                            };
                var result = await query.ToListAsync();
                return Ok(result);
            }
            else
            {
                var query = from OP in _context.Opdpatients
                            join P in _context.Patients on OP.Patientid equals P.Id
                            join D in _context.Doctors on OP.Doctorid equals D.Id into docGroup
                            from D in docGroup.DefaultIfEmpty() // Left Join
                            join T in _context.Towns on P.townid equals T.Id into townGroup
                            from T in townGroup.DefaultIfEmpty()
                            join RD in _context.Doctors on OP.Refdoctorid equals RD.Id into refDocGroup
                            from RD in refDocGroup.DefaultIfEmpty()
                            orderby OP.Opddate descending
                            select new
                            {
                                opdid = OP.Id,
                                patientid = OP.Patientid,
                                Name = P.Prefix + " " + P.Name,
                                P.Uidno,
                                Opddate = OP.Opddate,
                                P.Age,
                                P.Gender,
                                Mobileno = P.MobileNo,
                                P.address,
                                Townname = T != null ? T.Name : null,  // Handle NULL towns
                                Doctorname = D != null ? D.Name : null,
                                Refdoctorname = RD != null ? RD.Name : null
                            };
                var result = await query.ToListAsync();
                return Ok(result);
            }
        }


        [HttpPost]
        public async Task<IActionResult> PatientRegistration([FromBody] PatientDTO patientDTO)
        {
            Patient patient = new Patient();
            if (patientDTO.patientid == 0)
            {
                patient = new Patient()
                {
                    Id = 0,
                    Uidno = _patientService.GenerateUID(),
                    Prefix = patientDTO.patient.Prefix,
                    Name = patientDTO.patient.Name,
                    Birthdate = patientDTO.patient.Birthdate.Equals("") ? null : patientDTO.patient.Birthdate,
                    Age = patientDTO.patient.Age,
                    Gender = patientDTO.patient.Gender,
                    BloodGroup = patientDTO.patient.BloodGroup,
                    address = patientDTO.patient.address,
                    townid = patientDTO.patient.townid,
                    MobileNo = patientDTO.patient.MobileNo,
                    AltMobileNo = patientDTO.patient.AltMobileNo,
                    AadhaarNo = patientDTO.patient.AadhaarNo,
                    MaritalStatus = patientDTO.patient.MaritalStatus,
                    Occupation = patientDTO.patient.Occupation,
                    Createdby = patientDTO.patient.Createdby,
                    Createdon = DateTime.Now
                };
                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();
            }
            else
            {
                patient = await _context.Patients.FindAsync(patientDTO.patientid);
            }
            if (patientDTO.ptype.Equals("opd"))
            {
                Opdpatient opd = new Opdpatient()
                {
                    Patientid = patient.Id,
                    Opddate = patientDTO.opd.Opddate,
                    Opdtime = patientDTO.opd.Opdtime,
                    Height = patientDTO.opd.Height,
                    Weight = patientDTO.opd.Weight,
                    Doctorid = patientDTO.opd.Doctorid,
                    Refdoctorid = patientDTO.opd.Refdoctorid,
                    Createdby = patientDTO.patient.Createdby,
                    Createdon = DateTime.Now
                };
                _context.Opdpatients.Add(opd);
                await _context.SaveChangesAsync();
                return Ok(opd);
            }
            else
            {
                Ipdpatient ipd = new Ipdpatient()
                {
                    Patientid = patient.Id,
                    Admissiondate = patientDTO.ipd.Admissiondate,
                    Admissiontime = patientDTO.ipd.Admissiontime,
                    Doctorid = patientDTO.ipd.Doctorid,
                    Refdoctorid = patientDTO.ipd.Refdoctorid,
                    Roomid = patientDTO.ipd.Roomid,
                    Bedid = patientDTO.ipd.Bedid,
                    Companyid=patientDTO.ipd.Companyid,
                    Remark = patientDTO.ipd.Remark,
                    Createdby = patientDTO.patient.Createdby,
                    Createdon = DateTime.Now
                };
                _context.Ipdpatients.Add(ipd);
                await _context.SaveChangesAsync();
                return Ok(ipd);
            }
        }

        [HttpGet("patientid/{id}")]
        public async Task<IActionResult> GetPatientId(int id)
        {
            var Patients = await _context.Patients.FindAsync(id);

            if (Patients == null)
            {
                return NotFound();
            }

            return Ok(Patients);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            await _context.SaveChangesAsync();


            return Ok(patient);
        }

        [HttpGet("ipd/{ipdid}")]
        public async Task<IActionResult> GetIPDId(int ipdid)
        {
            var Ipdpatients = await (from ip in _context.Ipdpatients
                                     join p in _context.Patients on ip.Patientid equals p.Id
                                     where ip.Id == ipdid
                                     select new
                                     {
                                         Ip = ip,  
                                         p.Name, 
                                         p.Uidno,
                                         p.Prefix
                                     }).FirstOrDefaultAsync();

            return Ok(Ipdpatients); 
        }

        [HttpPut("ipd/{id}")]
        public async Task<IActionResult> PutIPDPatient(int id, Ipdpatient ipdpatient)
        {
        
            _context.Entry(ipdpatient).State = EntityState.Modified;

            await _context.SaveChangesAsync();


            return Ok(ipdpatient);
        }
    }
}