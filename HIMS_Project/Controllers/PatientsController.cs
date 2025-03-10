using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HIMS_Project.Context;
using HIMS_Project.Models;
using HIMS_Project.DTOs;
using Newtonsoft.Json;
using Humanizer;

namespace HIMS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public PatientsController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _context.Patients
                .Select(p => new
                {
                    PatientId = p.Id,
                    Name = p.Name ?? "Unknown",  
                    Age = p.Age ?? 0,
                    Prefix = p.Prefix ?? "Unknown",
                    //Name = p.Name,
                    Uidno = p.Uidno ?? "Unknown",
                    //Birthdate = p.Birthdate?.ToString("yyyy-MM-dd") ?? "Unknown",
                    Gender = p.Gender ?? "Unknown",
                    BloodGroup = p.BloodGroup ?? "Unknown",
                    //Address=p.address??"unknown",
                    //Townid=p.townid,
                    MobileNo = p.MobileNo ?? "Unknown",
                    AltMobileNo = p.AltMobileNo ?? "Unknown",
                    MaritalStatus = p.MaritalStatus ?? "Unknown",
                    Occupation = p.Occupation ?? "Unknown",
                    AadhaarNo = p.AadhaarNo ?? "Unknown",
                    Createdby = p.Createdby ?? 0,

                })
                .ToListAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSinglePatient(int id)
        {
            var patient = await _context.Patients
                .Where(p => p.Id == id)  
                .Select(p => new
                {
                    PatientId = p.Id,
                    Name = p.Name ?? "Unknown",        
                    Age = p.Age ?? 0,                             

                    Prefix = p.Prefix ?? "Unknown",             
                    Uidno = p.Uidno ?? "Unknown",               
                    Gender = p.Gender ?? "Unknown",        
                    BloodGroup = p.BloodGroup ?? "Unknown", 
                    MobileNo = p.MobileNo ?? "Unknown",       
                    AltMobileNo = p.AltMobileNo ?? "Unknown",
                    Address = p.address ?? "unknown",
                    Townid = p.townid,                            
                    MaritalStatus = p.MaritalStatus ?? "Unknown",  
                    Occupation = p.Occupation ?? "Unknown",        
                    AadhaarNo = p.AadhaarNo ?? "Unknown",  
                    Createdby = p.Createdby ?? 0,  
                })
                .FirstOrDefaultAsync();  

            if (patient == null)
            {
                return NotFound();  
            }

            return Ok(patient);  
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


        [HttpGet("opd/{patientid}/{doctorid}")]
        public async Task<IActionResult> GetOpdpatients(int patientid, int doctorid)
        {
            var opdpatientsQuery = _context.Opdpatients.AsQueryable();

            // Apply filtering based on patientid and doctorid
            if (patientid != 0)
            {

                opdpatientsQuery = opdpatientsQuery.Where(p => p.Patientid == patientid).Include(p => p.Patient).OrderByDescending(o => o.Opddate); 
            }

            if (doctorid != 0)
            {
                opdpatientsQuery = opdpatientsQuery.Where(p => p.Doctorid == doctorid).Include(p => p.Patient).OrderByDescending(o => o.Opddate);
              


            }
            var opdpatients = await opdpatientsQuery.ToListAsync();
            return Ok(opdpatients);
        }

        [HttpGet("ipd/{patientid}/{doctorid}")]
        public async Task<ActionResult<IEnumerable<Ipdpatient>>> GetIpdpatients(int patientid,int doctorid)
        {
            var ipdpatientsQuery = _context.Ipdpatients.AsQueryable();
            if (patientid != 0)
            {
                ipdpatientsQuery = ipdpatientsQuery.Where(p => p.Patientid == patientid).OrderBy(p => p.Admissiondate);
            }
            if (doctorid != 0)
            {
                ipdpatientsQuery = ipdpatientsQuery.Where(p => p.Doctorid == doctorid).OrderBy(p => p.Admissiondate);
            }
            return Ok(ipdpatientsQuery);

        }


        [HttpPost]
        public async Task<IActionResult> CreateFullPatientRecord([FromBody] ipdOpdPatientDTO dto)
        {
            try
            {
                // Check if the Patients list is null or empty
                if (dto.Patient == null || dto.Patient.Count == 0)
                {
                    return BadRequest("No patients provided.");
                }

                // Loop through the list of patients
                foreach (var patientDto in dto.Patient)
                {
                    var patient = new Patient
                    {
                        Prefix = patientDto.Prefix,
                        Name = patientDto.Name,
                        Uidno = patientDto.Uidno,
                        Birthdate = patientDto.Birthdate,
                        Age = patientDto.Age,
                        address = patientDto.address,
                        townid = patientDto.townid,
                        Gender = patientDto.Gender,
                        BloodGroup = patientDto.BloodGroup,
                        MobileNo = patientDto.MobileNo,
                        AltMobileNo = patientDto.AltMobileNo,
                        MaritalStatus = patientDto.MaritalStatus,
                        Occupation = patientDto.Occupation,
                        AadhaarNo = patientDto.AadhaarNo,
                        Createdby = patientDto.Createdby,
                        Createdon = DateTime.UtcNow,
                        Updatedby = patientDto.Updatedby,
                        Updatedon = DateTime.UtcNow
                    };

                    // Add the Patient to the context
                    _context.Patients.Add(patient);
                    await _context.SaveChangesAsync();
                    Console.WriteLine($"Patient ID: {patient.Id}");

                    // Check if there are related entities like OPD or IPD data and add them
                    if (dto.Opdpatient != null && dto.Opdpatient.Count > 0)
                    {
                        foreach (var opdDto in dto.Opdpatient)
                        {
                            // Only add if the patient ID matches
                            if (opdDto.Height != 0 &&
                                  opdDto.Weight != 0 &&
                                  !string.IsNullOrEmpty(opdDto.Remark) &&
                                  !string.Equals(opdDto.Opdtime, "00:00") &&
                                  opdDto.opdcreatedby != 0 &&
                                  opdDto.opddoctorid != 0)
                            {
                                var opdPatient = new Opdpatient
                                {
                                    Patientid = patient.Id,  // Link the OPD Patient to the created Patient
                                    Doctorid = opdDto.opddoctorid,
                                    Opddate = opdDto.Opddate,
                                    Opdtime = opdDto.AdmissionTimeConverted,
                                    Height = opdDto.Height,
                                    Weight = opdDto.Weight,
                                    Remark = opdDto.Remark,
                                    opdcreatedby = opdDto.opdcreatedby,
                                    Updatedby = opdDto.opdupdateddby,
                                    Createdon = opdDto.OnCreatedon,
                                    Updatedon = opdDto.OnUpdatedon
                                };
                                _context.Opdpatients.Add(opdPatient);
                                await _context.SaveChangesAsync();
                            }

                        }
                    }
                    if (dto.Ipdpatient != null && dto.Opdpatient.Count > 0)
                    {
                        foreach (var ipdDto in dto.Ipdpatient)
                        {
                            if (ipdDto.Bedid != 0 &&
                                ipdDto.Roomid != 0 &&
                                //ipdDto.Concessionbyid != 0 &&
                                !string.IsNullOrEmpty(ipdDto.Status) &&
                                !string.Equals(ipdDto.Admissiontime, "00:00") &&
                                //!string.IsNullOrEmpty(ipdDto.Dischargedas) &&
                                ipdDto.ipddoctorid != 0)
                            {
                                var ipdPatient = new Ipdpatient
                                {
                                    Patientid = patient.Id,  // Link the IPD Patient to the created Patient
                                    Admissiondate = ipdDto.Admissiondate,
                                    Admissiontime = ipdDto.AdmissiontimeConverted,
                                    Status = ipdDto.Status,
                                    Doctorid = ipdDto.ipddoctorid,
                                    Dischargedate = ipdDto.Dischargedate,
                                    Dischargetime = ipdDto.DischargeTimeConverted,
                                    Dischargedas = ipdDto.Dischargedas,
                                    Roomid = ipdDto.Roomid,
                                    Bedid = ipdDto.Bedid,
                                    Totalamount = ipdDto.Totalamount,
                                    Discountamount = ipdDto.Discountamount,
                                    Billamount = ipdDto.Billamount,
                                    Paidamount = ipdDto.Paidamount,
                                    Concessionbyid = ipdDto.Concessionbyid
                                };
                                _context.Ipdpatients.Add(ipdPatient);
                                await _context.SaveChangesAsync();
                            }
                        }

                    }

                }

                // Return the list of patients as a response
                return Ok(dto.Patient);
            }
            catch (Exception ex)
            {
                // Log the full exception details for debugging
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                return BadRequest("An error occurred while processing the request. Please try again later.");
            }
        }



        [HttpPost("opd/{patientid}")]
        public async Task<IActionResult> postOPDPatient([FromBody] OpdpatientDTO opdDto, int patientid)
        {
            try
            {
                if (opdDto != null)
                {
                   
                        // Only add if the patient ID matches
                        if (opdDto.Height != 0 &&
                              opdDto.Weight != 0 &&
                              !string.IsNullOrEmpty(opdDto.Remark) &&
                              !string.Equals(opdDto.Opdtime, "00:00") &&
                              opdDto.opdcreatedby != 0 &&
                              opdDto.opddoctorid != 0)
                        {
                            var opdPatient = new Opdpatient
                            {
                                Patientid = patientid,  // Link the OPD Patient to the created Patient
                                Doctorid = opdDto.opddoctorid,
                                Opddate = opdDto.Opddate,
                                Opdtime = opdDto.AdmissionTimeConverted,
                                Height = opdDto.Height,
                                Weight = opdDto.Weight,
                                Remark = opdDto.Remark,
                                opdcreatedby = opdDto.opdcreatedby,
                                Updatedby = opdDto.opdupdateddby,
                                Createdon = opdDto.OnCreatedon,
                                Updatedon = opdDto.OnUpdatedon
                            };
                            _context.Opdpatients.Add(opdPatient);
                            await _context.SaveChangesAsync();
                        }

                    }
                
                
                return Ok(opdDto);

            }
            catch (Exception ex)
            {
                // Log the full exception details for debugging
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                return BadRequest("An error occurred while processing the request. Please try again later.");
            }

        }



        [HttpPost("ipd/{patientid}")]
        public async Task<IActionResult> postIPDPatient([FromBody] IpdpatientDTO ipdDto, int patientid)
        {
            try
            {
                if (ipdDto != null)
                {
                   
                        if (ipdDto.Bedid != 0 &&
                            ipdDto.Roomid != 0 &&
                            //ipdDto.Concessionbyid != 0 &&
                            !string.IsNullOrEmpty(ipdDto.Status) &&
                            !string.Equals(ipdDto.Admissiontime, "00:00") &&
                            //!string.IsNullOrEmpty(ipdDto.Dischargedas) &&
                            ipdDto.ipddoctorid != 0)
                        {
                            var ipdPatient = new Ipdpatient
                            {
                                Patientid = patientid,  // Link the IPD Patient to the created Patient
                                Admissiondate = ipdDto.Admissiondate,
                                Admissiontime = ipdDto.AdmissiontimeConverted,
                                Status = ipdDto.Status,
                                Doctorid = ipdDto.ipddoctorid,
                                Dischargedate = ipdDto.Dischargedate,
                                Dischargetime = ipdDto.DischargeTimeConverted,
                                Dischargedas = ipdDto.Dischargedas,
                                Roomid = ipdDto.Roomid,
                                Bedid = ipdDto.Bedid,
                                Totalamount = ipdDto.Totalamount,
                                Discountamount = ipdDto.Discountamount,
                                Billamount = ipdDto.Billamount,
                                Paidamount = ipdDto.Paidamount,
                                Concessionbyid = ipdDto.Concessionbyid
                            };
                            _context.Ipdpatients.Add(ipdPatient);
                            await _context.SaveChangesAsync();
                        }
                    }
                return Ok(ipdDto);
                
            }
            catch (Exception ex)
            {
                // Log the full exception details for debugging
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                return BadRequest("An error occurred while processing the request. Please try again later.");
            }

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}