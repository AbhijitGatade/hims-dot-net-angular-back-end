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
    public class OpdservicesController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public OpdservicesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Opdservices
        [HttpGet("{opdservicecategoryid}")]
        public async Task<IActionResult> GetOpdservices(int opdservicecategoryid)
        {
            //return Ok(await _context.Opdservices.ToListAsync());
            if (opdservicecategoryid == 0)
            {
                List<Opdservice> opdservices = _context.Opdservices.Include(r => r.Opdservicecategory).ToList();
                return Ok(opdservices);
            }
            else
            {
                List<Opdservice> opdservices = _context.Opdservices.Where(r => r.Opdservicecategoryid == opdservicecategoryid).ToList();
                return Ok(opdservices);
            }
        }

        // GET: api/Opdservices/5
        [HttpGet("{opdservicecategoryid}/{id}")]
        public async Task<IActionResult> GetOpdservice(int opdservicecategoryid,int id)
        {
            var opdservice = await _context.Opdservices.FindAsync(id);

            if (opdservice == null)
            {
                return NotFound();
            }

            return Ok(opdservice);
        }

        // PUT: api/Opdservices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOpdservice(int id, Opdservice opdservice)
        {
            if (id != opdservice.Id)
            {
                return BadRequest();
            }

            _context.Entry(opdservice).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(opdservice);
        }

        // POST: api/Opdservices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostOpdservice(Opdservice opdservice)
        {
            _context.Opdservices.Add(opdservice);
            await _context.SaveChangesAsync();

            return Ok(opdservice);
        }

        // DELETE: api/Opdservices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpdservice(int id)
        {
            var opdservice = await _context.Opdservices.FindAsync(id);
            if (opdservice == null)
            {
                return NotFound();
            }

            _context.Opdservices.Remove(opdservice);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //OPDBillservice Controller


        [HttpPost("Opdbillservices")]
        public async Task<IActionResult> PostOpdbillservice(Opdbillservice opdbillservice)
        {
            _context.Opdbillservices.Add(opdbillservice);
            await _context.SaveChangesAsync();

            return Ok(opdbillservice);
        }

        // GET: api/Opdbillservices
        [HttpGet("Opdbillservices/{billid}/{opdserviceid}")]
        public async Task<IActionResult> GetOpdbillservices(int billid,int opdserviceid)
        {
            //return Ok(await _context.Opdbillservices.ToListAsync());
            if (billid != 0 && opdserviceid != 0)
            {
                List<Opdbillservice> Opdbillservices = _context.Opdbillservices.Where(r => r.Billid == billid && r.Opdserviceid == opdserviceid).ToList();
                return Ok(Opdbillservices);
            }
            else if (billid != 0 && opdserviceid == 0)
            {
                List<Opdbillservice> Opdbillservices = _context.Opdbillservices.Where(r => r.Billid == billid).Include(r => r.Opdservice).ToList();
                return Ok(Opdbillservices);
            }
            else if (billid == 0 && opdserviceid != 0)
            {
                List<Opdbillservice> Opdbillservices = _context.Opdbillservices.Where(r => r.Opdserviceid == opdserviceid).Include(r => r.Bill).ToList();
                return Ok(Opdbillservices);
            }
            else
            {
                List<Opdbillservice> Opdbillservices = _context.Opdbillservices.Include(r => r.Bill).Include(r => r.Opdservice).ToList();
                return Ok(Opdbillservices);
            }
        }

        // GET: api/Opdbillservices/5
        [HttpGet("Opdbillservices/{billid}/{opdserviceid}/{id}")]
        public async Task<IActionResult> GetOpdbillservice(int billid,int opdserviceid, int id)
        {
            var opdbillservice = _context.Opdbillservices.FindAsync(id);

            if (opdbillservice == null)
            {
                return Ok();
            }

            return Ok(opdbillservice);
        }

        // DELETE: api/Opdbillservices/5
        [HttpDelete("Opdbillservices/{id}")]
        public async Task<IActionResult> DeleteOpdbillservice(int id)
        {
            var opdbillservice = await _context.Opdbillservices.FindAsync(id);
            if (opdbillservice == null)
            {
                return NotFound();
            }

            _context.Opdbillservices.Remove(opdbillservice);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Opdbillservices/{id}")]
        public async Task<IActionResult> PutOpdbillservice(int id, Opdbillservice opdbillservice)
        {
            if (id != opdbillservice.Id)
            {
                return BadRequest();
            }

            _context.Entry(opdbillservice).State = EntityState.Modified;


            await _context.SaveChangesAsync();

            return Ok(opdbillservice);
        }
    }
}