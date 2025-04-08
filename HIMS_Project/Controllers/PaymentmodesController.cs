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
    public class PaymentmodesController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public PaymentmodesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Paymentmodes
        [HttpGet]
        public async Task<IActionResult> GetPaymentmodes()
        {
            return Ok(await _context.Paymentmodes.ToListAsync());
        }

        // GET: api/Paymentmodes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentmode(int id)
        {
            var paymentmode = await _context.Paymentmodes.FindAsync(id);

            if (paymentmode == null)
            {
                return NotFound();
            }

            return Ok(paymentmode);
        }

        // PUT: api/Paymentmodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentmode(int id, Paymentmode paymentmode)
        {
            if (id != paymentmode.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentmode).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(paymentmode);
        }

        // POST: api/Paymentmodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostPaymentmode(Paymentmode paymentmode)
        {
            _context.Paymentmodes.Add(paymentmode);
            await _context.SaveChangesAsync();

            return Ok(paymentmode);
        }

        // DELETE: api/Paymentmodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentmode(int id)
        {
            var paymentmode = await _context.Paymentmodes.FindAsync(id);
            if (paymentmode == null)
            {
                return NotFound();
            }

            _context.Paymentmodes.Remove(paymentmode);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //OPDBillpayments Controller

        [HttpPost("OPDBillpayments")]
        public async Task<IActionResult> PostOpdbillpayment(Opdbillpayment opdbillpayment)
        {
            _context.Opdbillpayments.Add(opdbillpayment);
            await _context.SaveChangesAsync();

            return Ok(opdbillpayment);
        }

        //[HttpGet("OPDBillpayments/{billid}/{paymentmodeid}")]
        //public async Task<ActionResult<IEnumerable<Opdbillpayment>>> GetOpdbillpayments(int billid,int paymentmodeid)
        //{
        //    return Ok(await _context.Opdbillpayments.ToListAsync());
        //    if (billid != 0 && paymentmodeid != 0)
        //    {
        //        List<Opdbillpayment> Opdbillpayments = _context.Opdbillpayments.Where(r => r.Billid == billid && r.Paymentmodeid == paymentmodeid).ToList();
        //        return Ok(Opdbillpayments);
        //    }
        //    else if (billid != 0 && paymentmodeid == 0)
        //    {
        //        List<Opdbillpayment> Opdbillpayments = _context.Opdbillpayments.Where(r => r.Billid == billid).Include(r => r.Paymentmode).ToList();
        //        return Ok(Opdbillpayments);
        //    }
        //    else if (billid == 0 && paymentmodeid != 0)
        //    {
        //        List<Opdbillpayment> Opdbillpayments = _context.Opdbillpayments.Where(r => r.Paymentmodeid == paymentmodeid).Include(r => r.Bill).ToList();
        //        return Ok(Opdbillpayments);
        //    }
        //    else
        //    {
        //        List<Opdbillpayment> Opdbillpayments = _context.Opdbillpayments.Include(r => r.Bill).Include(r => r.Paymentmode).ToList();
        //        return Ok(Opdbillpayments);
        //    }
        //}

        // GET: api/Opdbillpayments/5
        [HttpGet("OPDBillpayments/{billid}/{paymentmodeid}/{id}")]
        public async Task<ActionResult<Opdbillpayment>> GetOpdbillpayment(int billid, int paymentmodeid,int id)
        {
            var opdbillpayment = await _context.Opdbillpayments.FindAsync(id);

            if (opdbillpayment == null)
            {
                return NotFound();
            }

            return Ok(opdbillpayment);
        }

        [HttpDelete("OPDBillpayments/{id}")]
        public async Task<IActionResult> DeleteOpdbillpayment(int id)
        {
            var opdbillpayment = await _context.Opdbillpayments.FindAsync(id);
            if (opdbillpayment == null)
            {
                return NotFound();
            }

            _context.Opdbillpayments.Remove(opdbillpayment);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("OPDBillpayments/{id}")]
        public async Task<IActionResult> PutOpdbillpayment(int id, Opdbillpayment opdbillpayment)
        {
            if (id != opdbillpayment.Id)
            {
                return BadRequest();
            }

            _context.Entry(opdbillpayment).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(opdbillpayment);
        }
    }
}