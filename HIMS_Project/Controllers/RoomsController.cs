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
    public class RoomsController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public RoomsController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public IActionResult GetRooms()
        {
            return Ok(_context.Rooms.ToList());
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var room = _context.Rooms.Find(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public IActionResult PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(room);
        }

        // POST: api/Rooms
        [HttpPost]
        public ActionResult PostRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return Ok(room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            _context.SaveChanges();
            return Ok();
        }



        //controller for beds

        [HttpPost("beds")]
        public IActionResult PostBed(Bed bed)
        {
            if (_context.Rooms.Find(bed.Roomid) == null)
            {
                return BadRequest("The specified room does not exist.");
            }

            _context.Beds.Add(bed);
            _context.SaveChanges();
            return Ok(bed);
        }

        [HttpGet("beds/{roomid}")]
        public IActionResult GetBeds(int roomid)
        {
            if (roomid == 0)
            {
                List<Bed> beds = _context.Beds.Include(r => r.Room).ToList();
                return Ok(beds);
            }
            else
            {
                List<Bed> beds = _context.Beds.Where(r => r.Roomid == roomid).ToList();
                return Ok(beds);
            }
            //return Ok(_context.Beds.ToList());
        }

        [HttpGet("beds/{roomid}/{id}")]
        public IActionResult GetBed(int roomid, int id)
        {
            var bed = _context.Beds.Find(id);

            if (bed == null)
            {
                return NotFound();
            }

            return Ok(bed);
        }


        [HttpDelete("beds/{id}")]
        public IActionResult DeleteBed(int id)
        {
            var bed =_context.Beds.Find(id);
            if (bed == null)
            {
                return NotFound();
            }

            _context.Beds.Remove(bed);
            _context.SaveChanges();
            return Ok();
        }


        [HttpPut("beds/{id}")]
        public async Task<IActionResult> PutBed(int id, Bed bed)
        {
            if (id != bed.Id)
            {
                return BadRequest();
            }
            try
            {
                _context.Entry(bed).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(bed);
              
                // Save changes to the context
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
            }
            return Ok(bed);
        }
    }
}
