using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sustatron.Data;
using Sustatron.Models;

namespace SustatronAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommutesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Commutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commute>>> GetCommutes()
        {
          if (_context.Commutes == null)
          {
              return NotFound();
          }
            return await _context.Commutes.ToListAsync();
        }

        // GET: api/Commutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commute>> GetCommute(int id)
        {
          if (_context.Commutes == null)
          {
              return NotFound();
          }
            var commute = await _context.Commutes.FindAsync(id);

            if (commute == null)
            {
                return NotFound();
            }

            return commute;
        }

        // PUT: api/Commutes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommute(int id, Commute commute)
        {
            if (id != commute.Id)
            {
                return BadRequest();
            }

            _context.Entry(commute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommuteExists(id))
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

        // POST: api/Commutes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Commute>> PostCommute(Commute commute)
        {
          if (_context.Commutes == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Commutes'  is null.");
          }
            _context.Commutes.Add(commute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommute", new { id = commute.Id }, commute);
        }

        // DELETE: api/Commutes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommute(int id)
        {
            if (_context.Commutes == null)
            {
                return NotFound();
            }
            var commute = await _context.Commutes.FindAsync(id);
            if (commute == null)
            {
                return NotFound();
            }

            _context.Commutes.Remove(commute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommuteExists(int id)
        {
            return (_context.Commutes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
