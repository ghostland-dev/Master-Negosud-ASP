using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NegoSud_API.Models;
using NegoSud_API.Data;

namespace NegoSud_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagasinController : ControllerBase
    {
        private readonly NegosudDbContext _context;

        public MagasinController(NegosudDbContext context)
        {
            _context = context;
        }

        // GET: api/Magasin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Magasin>>> GetMagasins()
        {
            if (_context.Magasins == null)
            {
                return NotFound();
            }
            return await _context.Magasins.ToListAsync();
        }

        // GET: api/Magasin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Magasin>> GetMagasin(int id)
        {
            if (_context.Magasins == null)
            {
                return NotFound();
            }
            var Magasin = await _context.Magasins.FindAsync(id);

            if (Magasin == null)
            {
                return NotFound();
            }

            return Magasin;
        }

        // PUT: api/Magasin/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagasin(int id, Magasin Magasin)
        {
            if (id != Magasin.Id)
            {
                return BadRequest();
            }

            _context.Entry(Magasin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagasinExists(id))
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

        // POST: api/Magasin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Magasin>> PostMagasin(Magasin Magasin)
        {
            if (_context.Magasins == null)
            {
                return Problem("Entity set 'NegosudDbContext.Magasins'  is null.");
            }
            _context.Magasins.Add(Magasin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMagasin", new { id = Magasin.Id }, Magasin);
        }

        // DELETE: api/Magasin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMagasin(int id)
        {
            if (_context.Magasins == null)
            {
                return NotFound();
            }
            var Magasin = await _context.Magasins.FindAsync(id);
            if (Magasin == null)
            {
                return NotFound();
            }

            _context.Magasins.Remove(Magasin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MagasinExists(int id)
        {
            return (_context.Magasins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
