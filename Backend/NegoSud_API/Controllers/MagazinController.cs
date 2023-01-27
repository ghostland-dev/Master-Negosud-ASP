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
    public class MagazinController : ControllerBase
    {
        private readonly NegosudDbContext _context;

        public MagazinController(NegosudDbContext context)
        {
            _context = context;
        }

        // GET: api/Magazin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Magazin>>> GetMagazins()
        {
          if (_context.Magazins == null)
          {
              return NotFound();
          }
            return await _context.Magazins.ToListAsync();
        }

        // GET: api/Magazin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Magazin>> GetMagazin(int id)
        {
          if (_context.Magazins == null)
          {
              return NotFound();
          }
            var magazin = await _context.Magazins.FindAsync(id);

            if (magazin == null)
            {
                return NotFound();
            }

            return magazin;
        }

        // PUT: api/Magazin/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagazin(int id, Magazin magazin)
        {
            if (id != magazin.Id)
            {
                return BadRequest();
            }

            _context.Entry(magazin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagazinExists(id))
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

        // POST: api/Magazin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Magazin>> PostMagazin(Magazin magazin)
        {
          if (_context.Magazins == null)
          {
              return Problem("Entity set 'NegosudDbContext.Magazins'  is null.");
          }
            _context.Magazins.Add(magazin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMagazin", new { id = magazin.Id }, magazin);
        }

        // DELETE: api/Magazin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMagazin(int id)
        {
            if (_context.Magazins == null)
            {
                return NotFound();
            }
            var magazin = await _context.Magazins.FindAsync(id);
            if (magazin == null)
            {
                return NotFound();
            }

            _context.Magazins.Remove(magazin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MagazinExists(int id)
        {
            return (_context.Magazins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
