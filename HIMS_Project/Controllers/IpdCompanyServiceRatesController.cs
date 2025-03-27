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
    public class IpdCompanyServiceRatesController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public IpdCompanyServiceRatesController(ProjectDBContext context)
        {
            _context = context;
        }

        [HttpGet("{companyid}")]
        public async Task<ActionResult> GetIpdCompanyServiceRates(int companyid)
        {
            IQueryable<dynamic> query = from S in _context.Ipdservices
                                        join ICS in _context.IpdCompanyServiceRates
                                            on new { ServiceId = S.Id, CompanyId = companyid } equals new { ServiceId = ICS.serviceid, CompanyId = ICS.companyid} into joined
                                        from ICS in joined.DefaultIfEmpty()
                                        join C in _context.Companies
                                            on ICS.companyid equals C.Id into companies
                                        from C in companies.DefaultIfEmpty()
                                        orderby S.Srno
                                        select new
                                        {
                                            Id = ICS.Id == null ? 0 : ICS.Id,
                                            serviceid = S.Id,                                            
                                            companyid = companyid,
                                            S.Ipdservicecategoryid,
                                            S.Name,
                                            S.Defaultrate,
                                            Rate = ICS != null ? ICS.rate : (double?)null  // If ICS is null, set rate to null
                                        };
            var result = await query.ToListAsync();
            return Ok(result);
        }

        [HttpPost("{companyid}")]
        public async Task<ActionResult> PostIpdCompanyServiceRate(int companyid, IpdCompanyServiceRate[] ipdCompanyServiceRates)
        {
            foreach (var ipdCompanyServiceRate in ipdCompanyServiceRates)
            {
                if(ipdCompanyServiceRate.Id == 0 && ipdCompanyServiceRate.rate != 0)
                {
                    _context.IpdCompanyServiceRates.Add(ipdCompanyServiceRate);                    
                }
                else if(ipdCompanyServiceRate.Id != 0 && ipdCompanyServiceRate.rate != 0)
                {
                    _context.Entry(ipdCompanyServiceRate).State = EntityState.Modified;
                }
                else if (ipdCompanyServiceRate.Id != 0 && ipdCompanyServiceRate.rate == 0)
                {
                    _context.IpdCompanyServiceRates.Remove(ipdCompanyServiceRate);
                }
            }
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
