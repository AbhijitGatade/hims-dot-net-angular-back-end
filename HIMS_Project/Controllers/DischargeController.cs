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
    public class DischargeController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public DischargeController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Discharge/Special-Instruction
        [HttpGet("Special-Instruction")]
        public async Task<IActionResult> GetDischargeSpecialInstruction()
        {
            return Ok(await _context.DischargeSpecialInstruction.ToListAsync());
        }

        // GET: api/Discharge/Special-Instruction/5
        [HttpGet("Special-Instruction/{id}")]
        public async Task<IActionResult> GetDischargeSpecialInstruction(int id)
        {
            var dischargeSpecialInstruction = await _context.DischargeSpecialInstruction.FindAsync(id);
            return Ok(dischargeSpecialInstruction);
        }

        // PUT: api/Discharge/Special-Instruction/5
        [HttpPut("Special-Instruction/{id}")]
        public async Task<IActionResult> PutDischargeSpecialInstruction(int id, DischargeSpecialInstruction dischargeSpecialInstruction)
        {
            _context.Entry(dischargeSpecialInstruction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(dischargeSpecialInstruction);
        }

        // POST: api/Discharge/Special-Instruction
        [HttpPost("Special-Instruction")]
        public async Task<IActionResult> PostDischargeSpecialInstruction(DischargeSpecialInstruction dischargeSpecialInstruction)
        {
            _context.DischargeSpecialInstruction.Add(dischargeSpecialInstruction);
            await _context.SaveChangesAsync();
            return Ok(dischargeSpecialInstruction);
        }

        // DELETE: api/Discharge/Special-Instruction/5
        [HttpDelete("Special-Instruction/{id}")]
        public async Task<IActionResult> DeleteDischargeSpecialInstruction(int id)
        {
            var dischargeSpecialInstruction = await _context.DischargeSpecialInstruction.FindAsync(id);
            _context.DischargeSpecialInstruction.Remove(dischargeSpecialInstruction);
            await _context.SaveChangesAsync();
            return Ok();
        }

//==========================================================API for diet===================================================

        // GET: api/Discharge/Diet
        [HttpGet("Diet")]
        public async Task<IActionResult> GetDischargeDiet()
        {
            return Ok(await _context.DischargeDiets.ToListAsync());
        }

        // GET: api/Discharge/Diet/5
        [HttpGet("Diet/{id}")]
        public async Task<IActionResult> GetDischargeDiet(int id)
        {
            var dischargeDiet = await _context.DischargeDiets.FindAsync(id);
            return Ok(dischargeDiet);
        }

        // PUT: api/Discharge/Diet/5
        [HttpPut("Diet/{id}")]
        public async Task<IActionResult> PutDiet(int id, DischargeDiet dischargeDiet)
        {
            _context.Entry(dischargeDiet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(dischargeDiet);
        }

        // POST: api/Discharge/Diet
        [HttpPost("Diet")]
        public async Task<IActionResult> PostDiet(DischargeDiet dischargeDiet)
        {
            _context.DischargeDiets.Add(dischargeDiet);
            await _context.SaveChangesAsync();
            return Ok(dischargeDiet);
        }

        // DELETE: api/Discharge/Diet/5
        [HttpDelete("Diet/{id}")]
        public async Task<IActionResult> DeleteDiet(int id)
        {
            var dischargeDiet = await _context.DischargeDiets.FindAsync(id);
            _context.DischargeDiets.Remove(dischargeDiet);
            await _context.SaveChangesAsync();
            return Ok();
        }


//========================================================== API for Emergency ===================================================

        // GET: api/Discharge/Emergency
        [HttpGet("Emergency")]
        public async Task<IActionResult> GetDischargeEmergency()
        {
            return Ok(await _context.DischargeEmergency.ToListAsync());
        }

        // GET: api/Discharge/Emergency/5
        [HttpGet("Emergency/{id}")]
        public async Task<IActionResult> GetDischargeEmergency(int id)
        {
            var dischargeEmergency = await _context.DischargeEmergency.FindAsync(id);
            return Ok(dischargeEmergency);
        }

        // PUT: api/Discharge/Emergency/5
        [HttpPut("Emergency/{id}")]
        public async Task<IActionResult> PutEmergency(int id, DischargeEmergency dischargeEmergency)
        {
            _context.Entry(dischargeEmergency).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(dischargeEmergency);
        }


        // POST: api/Discharge/Emergency
        [HttpPost("Emergency")]
        public async Task<IActionResult> PostEmergency(DischargeEmergency dischargeEmergency)
        {
            _context.DischargeEmergency.Add(dischargeEmergency);
            await _context.SaveChangesAsync();
            return Ok(dischargeEmergency);
        }

        // DELETE: api/Discharge/Emergency/5
        [HttpDelete("Emergency/{id}")]
        public async Task<IActionResult> DeleteEmergency(int id)
        {
            var dischargeEmergency = await _context.DischargeEmergency.FindAsync(id);
            _context.DischargeEmergency.Remove(dischargeEmergency);
            await _context.SaveChangesAsync();
            return Ok();
        }


        //========================================================== API for Exercise ===================================================
       
        // GET: api/Discharge/Exercises
        [HttpGet("Exercises")]
        public async Task<IActionResult> GetDischargeExercises()
        {
            return Ok(await _context.DischargeExercises.ToListAsync());
        }

        // GET: api/Discharge/Exercises/5
        [HttpGet("Exercises/{id}")]
        public async Task<IActionResult> GetDischargeExercises(int id)
        {
            var dischargeExercises = await _context.DischargeExercises.FindAsync(id);
            return Ok(dischargeExercises);
        }

        // PUT: api/Discharge/Exercises/5
        [HttpPut("Exercises/{id}")]
        public async Task<IActionResult> PutExercises(int id, DischargeExercise dischargeExercise)
        {
            _context.Entry(dischargeExercise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(dischargeExercise);
        }


        // POST: api/Discharge/Exercises
        [HttpPost("Exercises")]
        public async Task<IActionResult> PostExercises(DischargeExercise dischargeExercise)
        {
            _context.DischargeExercises.Add(dischargeExercise);
            await _context.SaveChangesAsync();
            return Ok(dischargeExercise);
        }

        // DELETE: api/Discharge/Exercises/5
        [HttpDelete("Exercises/{id}")]
        public async Task<IActionResult> DeleteExercises(int id)
        {
            var dischargeExercises = await _context.DischargeExercises.FindAsync(id);
            _context.DischargeExercises.Remove(dischargeExercises);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
