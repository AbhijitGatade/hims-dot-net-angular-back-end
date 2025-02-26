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
    public class IpdbillpaymentsController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public IpdbillpaymentsController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Ipdbillpayments
        [HttpGet("{ipdpatientid}/{paymentmodeid}")]
        public async Task<IActionResult> GetIpdbillpayments(int ipdpatientid,int paymentmodeid)
        {
            //return Ok(await _context.Ipdbillpayments.ToListAsync());
            if (ipdpatientid != 0 && paymentmodeid != 0)
            {
                List<Ipdbillpayment> Ipdbillpayments = _context.Ipdbillpayments.Where(r => r.Ipdid == ipdpatientid && r.Paymentmethodid == paymentmodeid).ToList();
                return Ok(Ipdbillpayments);
            }
            else if (ipdpatientid != 0 && paymentmodeid == 0)
            {
                List<Ipdbillpayment> Ipdbillpayments = _context.Ipdbillpayments.Where(r => r.Ipdid == ipdpatientid).Include(r => r.Paymentmethod).ToList();
                return Ok(Ipdbillpayments);
            }
            else if (ipdpatientid == 0 && paymentmodeid != 0)
            {
                List<Ipdbillpayment> Ipdbillpayments = _context.Ipdbillpayments.Where(r => r.Paymentmethodid == paymentmodeid).Include(r => r.Ipd).ToList();
                return Ok(Ipdbillpayments);
            }
            else
            {
                List<Ipdbillpayment> Ipdbillpayments = _context.Ipdbillpayments.Include(r => r.Ipd).Include(r => r.Paymentmethod).ToList();
                return Ok(Ipdbillpayments);
            }
        }

        // GET: api/Ipdbillpayments/5
        [HttpGet("{ipdpatientid}/{paymentmodeid}/{id}")]
        public async Task<IActionResult> GetIpdbillpayment(int ipdpatientid, int paymentmodeid,int id)
        {
            var ipdbillpayment = await _context.Ipdbillpayments.FindAsync(id);

            if (ipdbillpayment == null)
            {
                return NotFound();
            }

            return Ok(ipdbillpayment);
        }

        // PUT: api/Ipdbillpayments/5
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpdbillpayment(int id, Ipdbillpayment ipdbillpayment)
        {
            if (id != ipdbillpayment.Id)
            {
                return BadRequest();
            }

            _context.Entry(ipdbillpayment).State = EntityState.Modified;

                await _context.SaveChangesAsync();


            return Ok(ipdbillpayment);
        }

        // POST: api/Ipdbillpayments
        
        [HttpPost]
        public async Task<IActionResult> PostIpdbillpayment(Ipdbillpayment ipdbillpayment)
        {
            _context.Ipdbillpayments.Add(ipdbillpayment);
            await _context.SaveChangesAsync();

            return Ok(ipdbillpayment);
        }

        // DELETE: api/Ipdbillpayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIpdbillpayment(int id)
        {
            var ipdbillpayment = await _context.Ipdbillpayments.FindAsync(id);
            if (ipdbillpayment == null)
            {
                return NotFound();
            }

            _context.Ipdbillpayments.Remove(ipdbillpayment);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
