using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HIMS_Project.Context;
using HIMS_Project.Models;
using HIMS_Project.DTOs;

namespace HIMSProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpdbillsController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        private int Billid;
        private int Opdserviceid;

        public int Doctorid { get; private set; }

        private int Concdiscount;

        public double Billamount { get; private set; }

        private double? Discountamount;
        private double Totalamount;

        public OpdbillsController(ProjectDBContext context)
        {
            _context = context;
        }


        //// PUT: api/Opdbills/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOpdbill(int id, Opdbill opdbill)
        //{
        //    if (id != opdbill.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(opdbill).State = EntityState.Modified;


        //        await _context.SaveChangesAsync();

        //    return Ok(opdbill);
        //}


        // GET: api/Opdbills/5
        [HttpGet("{opdid}")]
        public async Task<IActionResult> GetOpdbill(int opdid)
        {
            List<Opdbill> opdbills = _context.Opdbills.Include(r => r.Concessionby).ToList();
            return Ok(opdbills);


        }

        [HttpGet("opdbillservices/{billid}")]
        public async Task<IActionResult> Getopdbillservices(int billid)
        {
            var opdbillservices = await _context.Opdbillservices.Include(o => o.Opdservice).Where(o => o.Billid == billid).ToListAsync();
            return Ok(opdbillservices);
        }

        [HttpGet("bills/{id}")]
        public async Task<IActionResult> Getbills(int id)
        {
            var Opdbill = await _context.Opdbills.FindAsync(id);
            return Ok(Opdbill);
        }

        [HttpPost]
        public async Task<IActionResult> PostOpdBill([FromBody] OpdBillDTO opdBillDTO)
        {
            try
            {
                var opdbill = new Opdbill()
                {
                    Id = 0,
                    Opdid = opdBillDTO.Opdbill.Opdid,
                    Totalamount = opdBillDTO.Opdbill.Totalamount,
                    Discountamount = opdBillDTO.Opdbill.Discountamount,
                    Billamount = opdBillDTO.Opdbill.Billamount,
                    Paidamount = opdBillDTO.Opdbill.Paidamount,
                    Pendingamount = opdBillDTO.Opdbill.Pendingamount,
                    Paymentmodeid = opdBillDTO.Opdbill.Paymentmodeid,
                    Status = opdBillDTO.Opdbill.Status,
                    Concessionbyid = opdBillDTO.Opdbill.Concessionbyid,
                    Createdby = opdBillDTO.Opdbill.Createdby,
                    Createdon = DateTime.Now
                };
                _context.Opdbills.Add(opdbill);
                await _context.SaveChangesAsync();

                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var Opdbillpayment = new Opdbillpayment()
                        {
                            Billid = opdbill.Id,
                            Paymentdate = opdBillDTO.Opdbillpayment.Paymentdate,
                            BillAmount = opdBillDTO.Opdbillpayment.BillAmount,
                            PaidAmount = opdBillDTO.Opdbillpayment.PaidAmount,
                            PendingAmount = opdBillDTO.Opdbillpayment.PendingAmount,
                            Paymentid = opdBillDTO.Opdbillpayment.Paymentid,
                            Remark = opdBillDTO.Opdbillpayment.Remark,
                            Createdby = opdBillDTO.Opdbill.Createdby,
                            Createdon = DateTime.Now
                        };
                        _context.Opdbillpayments.Add(Opdbillpayment);
                        await _context.SaveChangesAsync();

                    
                   
                         // Save OPD bill first to get the ID

                        List<Opdbillservice> opdbillservices = new List<Opdbillservice>();

                        foreach (var service in opdBillDTO.Opdbillservice)
                        {
                            var opdServiceExists = await _context.Opdservices
                                .AnyAsync(s => s.Id == service.Opdserviceid);

                            if (!opdServiceExists)
                            {
                                return BadRequest($"Opdservice with ID {service.Opdserviceid} does not exist.");
                            }

                            var opdbillservice = new Opdbillservice()
                            {
                                Billid = opdbill.Id,
                                Opdserviceid = service.Opdserviceid,
                                Doctorid = service.Doctorid,
                                Concdiscount = service.Concdiscount,
                                Billamount = service.Billamount,
                                Discountamount = service.Discountamount,
                                Totalamount = service.Totalamount
                            };

                            opdbillservices.Add(opdbillservice);
                        }
                        _context.Opdbillservices.AddRange(opdbillservices);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        return Ok(new { Bill = opdbill, Services = opdbillservices });
                    }

                    catch (DbUpdateException ex)
                    {
                        Console.WriteLine(ex.InnerException?.Message); // Log or inspect the inner exception message
                        await transaction.RollbackAsync();
                        return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Unhandled Error: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }


        }

    }
}


        // DELETE: api/Opdbills/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOpdbill(int id)
        //{
        //    var opdbill = await _context.Opdbills.FindAsync(id);
        //    if (opdbill == null)
        //    {
        //        return Ok(NotFound());
        //    }

//    _context.Opdbills.Remove(opdbill);
//    await _context.SaveChangesAsync();

//    return Ok();



//}


