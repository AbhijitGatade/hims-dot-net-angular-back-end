using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HIMS_Project.Context;
using HIMS_Project.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using NuGet.Versioning;
using HIMS_Project.Services;

namespace HIMS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpdbillpaymentsController : ControllerBase
    {
        
        private readonly ProjectDBContext _context;
        public readonly IPatientService _patientService;

        public OpdbillpaymentsController(ProjectDBContext context, IPatientService patientService)
        {
            _context = context;
            _patientService = patientService;
        }


        // GET: api/Opdbillpayments/5
        [HttpGet("{billid}")]
        public  IActionResult GetOpdbillpayment(int billid)
        {
            //_patientService.CreateCalculation(billid);
            var opdbillpayments =  _context.Opdbillpayments
                                                .Where(op => op.Billid == billid)
                                                .ToList();
            
            return Ok(opdbillpayments);
           
        }

        [HttpGet("{billid}/{id}")]
        public async Task<ActionResult<List<Opdbillpayment>>> GetSingleOpdbillpayment(int billid,int id)
        {
            var singleopdbillpayments = await _context.Opdbillpayments
                                                .Where(op => op.Billid == billid && op.Id==id)
                                                .ToListAsync();
            return singleopdbillpayments;
        }



        
        [HttpPut("{paymentid}")]
        public async Task<IActionResult> PutOpdbillpayment(int paymentid, Opdbillpayment opdbillpayment)
        {
            if (paymentid != opdbillpayment.Id)
            {
                return BadRequest();
            }

            var billid = opdbillpayment.Billid;
            _context.Entry(opdbillpayment).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            _patientService.CreateCalculation(billid);
            return Ok(opdbillpayment);

            
        }


        [HttpPost]
            public async Task<ActionResult<Opdbillpayment>> PostOpdbillpayment(Opdbillpayment opdbillpayment)
             {
            try
            {
                opdbillpayment.Createdon = DateTime.Now;

                var billid = opdbillpayment.Billid;
                var billamount=opdbillpayment.BillAmount;
                _patientService.CreateCalculation(billid);
                _context.Opdbillpayments.Add(opdbillpayment);
                await _context.SaveChangesAsync();
                return Ok(opdbillpayment);
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
                return Ok(opdbillpayment);

        }


        // DELETE: api/Opdbillpayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpdbillpayment(int id)
        {
            
            var opdbillpayment = await _context.Opdbillpayments.FindAsync(id);
        
            if (opdbillpayment == null)
            {
                return NotFound();
            }
            var billid = opdbillpayment.Billid;
            
            _context.Opdbillpayments.Remove(opdbillpayment);
            await _context.SaveChangesAsync();
            _patientService.CreateCalculation(billid);
            return NoContent();

        }

   
    }
}
