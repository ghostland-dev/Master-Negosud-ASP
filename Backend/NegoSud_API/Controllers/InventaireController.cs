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
    public class InventaireController : ControllerBase
    {
        private readonly NegosudDbContext _context;

        public InventaireController(NegosudDbContext context)
        {
            _context = context;
        }

        // GET: api/Inventaire
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventaire>>> GetInventaires()
        {
          if (_context.Inventaires == null)
          {
              return NotFound();
          }
            return await _context.Inventaires.ToListAsync();
        }

        // GET: api/Inventaire/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventaire>> GetInventaire(int id)
        {
          if (_context.Inventaires == null)
          {
              return NotFound();
          }
            var inventaire = await _context.Inventaires.FindAsync(id);

            if (inventaire == null)
            {
                return NotFound();
            }

            return inventaire;
        }

        // PUT: api/Inventaire/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventaire(int id, Inventaire inventaire)
        {
            if (id != inventaire.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventaireExists(id))
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

        // POST: api/Inventaire
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inventaire>> PostInventaire(Inventaire inventaire)
        {
          if (_context.Inventaires == null)
          {
              return Problem("Entity set 'NegosudDbContext.Inventaires'  is null.");
          }
            _context.Inventaires.Add(inventaire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventaire", new { id = inventaire.Id }, inventaire);
        }

        // DELETE: api/Inventaire/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventaire(int id)
        {
            if (_context.Inventaires == null)
            {
                return NotFound();
            }
            var inventaire = await _context.Inventaires.FindAsync(id);
            if (inventaire == null)
            {
                return NotFound();
            }

            _context.Inventaires.Remove(inventaire);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventaireExists(int id)
        {
            return (_context.Inventaires?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
