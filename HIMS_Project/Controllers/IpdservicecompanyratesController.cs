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
    public class IpdservicecompanyratesController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public IpdservicecompanyratesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Ipdservicecompanyrates


        [HttpGet("{companyid}/{ipdserviceid}")]
        public async Task<IActionResult> GetIpdservicecompanyrates(int companyid,int ipdserviceid)
        {
            //return Ok(await _context.Ipdservicecompanyrates.ToListAsync());
            if (companyid != 0 && ipdserviceid != 0)
            {
                List<Ipdservicecompanyrate> Ipdservicecompanyrates = _context.Ipdservicecompanyrates.Where(r => r.Companyid == companyid && r.Ipdserviceid == ipdserviceid).ToList();
                return Ok(Ipdservicecompanyrates);
            }
            else if (companyid != 0 && ipdserviceid == 0)
            {
                List<Ipdservicecompanyrate> Ipdservicecompanyrates = _context.Ipdservicecompanyrates.Where(r => r.Companyid == companyid).Include(r => r.Ipdservice).ToList();
                return Ok(Ipdservicecompanyrates);
            }
            else if (companyid == 0 && ipdserviceid != 0)
            {
                List<Ipdservicecompanyrate> Ipdservicecompanyrates = _context.Ipdservicecompanyrates.Where(r => r.Ipdserviceid == ipdserviceid).Include(r => r.Company).ToList();
                return Ok(Ipdservicecompanyrates);
            }
            else
            {
                List<Ipdservicecompanyrate> Ipdservicecompanyrates = _context.Ipdservicecompanyrates.Include(r => r.Company).Include(r => r.Ipdservice).ToList();
                return Ok(Ipdservicecompanyrates);
            }
        }

        // GET: api/Ipdservicecompanyrates/5

        [HttpGet("{companyid}/{ipdserviceid}/{id}")]
        public async Task<IActionResult> GetIpdservicecompanyrate(int companyid, int ipdserviceid,int id)
        {
            var ipdservicecompanyrate = await _context.Ipdservicecompanyrates.FindAsync(id);

            if (ipdservicecompanyrate == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ipdservicecompanyrate);
            }
        }

        // PUT: api/Ipdservicecompanyrates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpdservicecompanyrate(int id, Ipdservicecompanyrate ipdservicecompanyrate)
        {
            if (id != ipdservicecompanyrate.Id)
            {
                return BadRequest();
            }

            _context.Entry(ipdservicecompanyrate).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(ipdservicecompanyrate);
        }

        // POST: api/Ipdservicecompanyrates
        [HttpPost]
        public async Task<IActionResult> PostIpdservicecompanyrate(Ipdservicecompanyrate ipdservicecompanyrate)
        {
            _context.Ipdservicecompanyrates.Add(ipdservicecompanyrate);
            await _context.SaveChangesAsync();

            return Ok(ipdservicecompanyrate);
        }

        // DELETE: api/Ipdservicecompanyrates/5

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIpdservicecompanyrate(int id)
        {
            var ipdservicecompanyrate = await _context.Ipdservicecompanyrates.FindAsync(id);
            if (ipdservicecompanyrate == null)
            {
                return NotFound();
            }

            _context.Ipdservicecompanyrates.Remove(ipdservicecompanyrate);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}


