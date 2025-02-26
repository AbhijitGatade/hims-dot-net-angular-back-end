using HIMS_Project.Context;
using HIMS_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpdservicesController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public IpdservicesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Ipdservices

        [HttpGet("{ipdservicecategoryid}")]
        public async Task<IActionResult> GetIpdservices(int ipdservicecategoryid)
        {
            //return Ok(await _context.Ipdservices.ToListAsync());
            if (ipdservicecategoryid == 0)
            {
                List<Ipdservice> Ipdservices = _context.Ipdservices.Include(r => r.Ipdservicecategory).ToList();
                return Ok(Ipdservices);
            }
            else
            {
                List<Ipdservice> Ipdservices = _context.Ipdservices.Where(r => r.Ipdservicecategoryid == ipdservicecategoryid).ToList();
                return Ok(Ipdservices);
            }
        }

        // GET: api/Ipdservices/5

        [HttpGet("{ipdservicecategoryid}/{id}")]
        public async Task<IActionResult> GetIpdservice(int ipdservicecategoryid,int id)
        {
            var ipdservice = await _context.Ipdservices.FindAsync(id);

            if (ipdservice == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ipdservice);
            }
        }

        // PUT: api/Ipdservices/5
     
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpdservice(int id, Ipdservice ipdservice)
        {
            if (id != ipdservice.Id)
            {
                return BadRequest();
            }

            _context.Entry(ipdservice).State = EntityState.Modified;


            return Ok(ipdservice);
        }

        // POST: api/Ipdservices
        
        [HttpPost]
        public async Task<ActionResult<Ipdservice>> PostIpdservice(Ipdservice ipdservice)
        {
            _context.Ipdservices.Add(ipdservice);
            await _context.SaveChangesAsync();

            return Ok(ipdservice);
        }

        // DELETE: api/Ipdservices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIpdservice(int id)
        {
            var ipdservice = await _context.Ipdservices.FindAsync(id);
            if (ipdservice == null)
            {
                return NotFound();
            }

            _context.Ipdservices.Remove(ipdservice);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
