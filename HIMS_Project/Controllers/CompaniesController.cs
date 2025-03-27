using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HIMS_Project.Context;
using HIMS_Project.Models;

namespace HIMSHIMS_Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public CompaniesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            return Ok(await _context.Companies.ToListAsync());
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }
            _context.Entry(company).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return Ok(company);
        }

        // POST: api/Companies
     
        [HttpPost]
        public async Task<IActionResult> PostCompany(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return Ok(company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
