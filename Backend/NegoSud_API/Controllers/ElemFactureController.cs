using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NegoSud_API.Models;

namespace NegoSud_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElemFactureController : ControllerBase
    {
        private readonly NegosudDbContext _context;

        public ElemFactureController(NegosudDbContext context)
        {
            _context = context;
        }

        // GET: api/ElemFacture
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElemFacture>>> GetElemFactures()
        {
          if (_context.ElemFactures == null)
          {
              return NotFound();
          }
            return await _context.ElemFactures.ToListAsync();
        }

        // GET: api/ElemFacture/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ElemFacture>> GetElemFacture(int id)
        {
          if (_context.ElemFactures == null)
          {
              return NotFound();
          }
            var elemFacture = await _context.ElemFactures.FindAsync(id);

            if (elemFacture == null)
            {
                return NotFound();
            }

            return elemFacture;
        }

        // PUT: api/ElemFacture/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElemFacture(int id, ElemFacture elemFacture)
        {
            if (id != elemFacture.Id)
            {
                return BadRequest();
            }

            _context.Entry(elemFacture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElemFactureExists(id))
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

        // POST: api/ElemFacture
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ElemFacture>> PostElemFacture(ElemFacture elemFacture)
        {
          if (_context.ElemFactures == null)
          {
              return Problem("Entity set 'NegosudDbContext.ElemFactures'  is null.");
          }
            _context.ElemFactures.Add(elemFacture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElemFacture", new { id = elemFacture.Id }, elemFacture);
        }

        // DELETE: api/ElemFacture/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElemFacture(int id)
        {
            if (_context.ElemFactures == null)
            {
                return NotFound();
            }
            var elemFacture = await _context.ElemFactures.FindAsync(id);
            if (elemFacture == null)
            {
                return NotFound();
            }

            _context.ElemFactures.Remove(elemFacture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElemFactureExists(int id)
        {
            return (_context.ElemFactures?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
