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
    public class OpdCompanyServiceRatesController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public OpdCompanyServiceRatesController(ProjectDBContext context)
        {
            _context = context;
        }

        [HttpGet("{companyid}/{doctorid}")]
        public async Task<ActionResult> GetOpdCompanyServiceRates(int companyid, int doctorid)
        {
            var query = from OS in _context.Opdservices
                        join OCS in _context.OpdCompanyServiceRates
                            on new { ServiceId = OS.Id, DoctorId = doctorid, CompanyId = companyid }
                            equals new { ServiceId = OCS.serviceid, DoctorId = OCS.doctorid, CompanyId = OCS.companyid }
                            into joined
                        from OCS in joined.DefaultIfEmpty()
                        join C in _context.Companies
                                           on OCS.companyid equals C.Id into companies
                        from C in companies.DefaultIfEmpty()
                        join D in _context.Doctors
                                           on OCS.doctorid equals D.Id into doctors
                        from D in doctors.DefaultIfEmpty()
                        orderby OS.Srno
                        select new
                        {
                            serviceid = OS.Id,
                            opdservicecategoryid = OS.Opdservicecategoryid,
                            doctorid = doctorid,
                            companyid = companyid,
                            OS.Name,
                            Defaultrate = OS.Rate,
                            Defaultfrate = OS.Frate,
                            Rate = OCS.rate == null ? (double?)0 : OCS.rate,
                            Frate = OCS.frate == null ? (double?)0 : OCS.frate,
                            OcsId = OCS != null ? OCS.Id : 0
                        };

            var result = await query.ToListAsync();
            return Ok(result);
        }

        [HttpPost("{companyid}/{doctorid}")]
        public async Task<ActionResult> PostIpdCompanyServiceRate(int companyid, int doctorid, OpdCompanyServiceRate[] opdCompanyServiceRates)
        {
            foreach (var opdCompanyServiceRate in opdCompanyServiceRates)
            {
                if (opdCompanyServiceRate.Id == 0 && opdCompanyServiceRate.rate != 0)
                {
                    _context.OpdCompanyServiceRates.Add(opdCompanyServiceRate);
                }
                else if (opdCompanyServiceRate.Id != 0 && opdCompanyServiceRate.rate != 0)
                {
                    _context.Entry(opdCompanyServiceRate).State = EntityState.Modified;
                }
                else if (opdCompanyServiceRate.Id != 0 && opdCompanyServiceRate.rate == 0)
                {
                    _context.OpdCompanyServiceRates.Remove(opdCompanyServiceRate);
                }
            }
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
