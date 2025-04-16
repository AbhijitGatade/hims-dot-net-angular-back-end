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
    public class IpdBillsController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public IpdBillsController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/IpdBills
        [HttpGet("{ipdid}")]
        public async Task<ActionResult<IEnumerable<object>>> GetIpdBill(int ipdid)
        {
            var query = from s in _context.Ipdservices
                        join ic in _context.Ipdservicecategories on s.Ipdservicecategoryid equals ic.Id
                        join ics in _context.IpdCompanyServiceRates on s.Id equals ics.serviceid into icsGroup
                        from ics in icsGroup.DefaultIfEmpty()
                        join ib in _context.IpdBill.Where(b => b.Ipdid == ipdid)
                            on s.Id equals ib.Serviceid into ibGroup
                        from ib in ibGroup.DefaultIfEmpty()
                        orderby ic.Srno
                        select new
                                        {
                                            id= ib != null ? ib.Id : (int?)0,
                                            serviceid =s.Id,
                                            s.Name,
                                            IpdServiceCategoryName = ic.Name,
                                            Quantity = ib != null ? ib.Quantity : (int?)null,
                                            Remark = ib == null ? null : ib.Remark,
                                            Total = ib != null ? ib.Total : (double?)null,

                                            CompanyRate = ics != null ? ics.rate : (double?)null
                                        };



            var result = await query.ToListAsync();
            return Ok(result);
        }

        

        // PUT: api/IpdBills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpdBill(int id, IpdBill ipdBill)
        {
            if (id != ipdBill.Id)
            {
                return BadRequest();
            }

            _context.Entry(ipdBill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpdBillExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/IpdBills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IpdBill>> PostIpdBill(IpdBill[]? ipdBills)
        {
            try
            {
                foreach (var ipdBill in ipdBills)
                {
                    if (ipdBill.Id == 0  && ipdBill.Total != null && ipdBill.Quantity != null)
                    {
                        _context.IpdBill.Add(ipdBill);
                    }
                    else if (ipdBill.Id != 0   && ipdBill.Total != null && ipdBill.Quantity != null)
                    {
                        _context.Entry(ipdBill).State = EntityState.Modified;
                    }
                    //else if (ipdCompanyServiceRate.Id != 0 && ipdCompanyServiceRate.rate == 0)
                    //{
                    //    _context.IpdCompanyServiceRates.Remove(ipdCompanyServiceRate);
                    //}
                }
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                Console.WriteLine(ex);
            }
                return Ok();
            
        }

        // DELETE: api/IpdBills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIpdBill(int id)
        {
            var ipdBill = await _context.IpdBill.FindAsync(id);
            if (ipdBill == null)
            {
                return NotFound();
            }

            _context.IpdBill.Remove(ipdBill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IpdBillExists(int id)
        {
            return _context.IpdBill.Any(e => e.Id == id);
        }
    }
}
