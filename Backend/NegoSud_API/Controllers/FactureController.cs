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
    public class FactureController : ControllerBase
    {
        private readonly NegosudDbContext _context;

        public FactureController(NegosudDbContext context)
        {
            _context = context;
        }

        // GET: api/Facture
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facture>>> GetFactures()
        {
          if (_context.Factures == null)
          {
              return NotFound();
          }
            return await _context.Factures.ToListAsync();
        }

        // GET: api/Facture/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facture>> GetFacture(int id)
        {
          if (_context.Factures == null)
          {
              return NotFound();
          }
            var facture = await _context.Factures.FindAsync(id);

            if (facture == null)
            {
                return NotFound();
            }

            return facture;
        }

        // PUT: api/Facture/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacture(int id, Facture facture)
        {
            if (id != facture.Id)
            {
                return BadRequest();
            }

            _context.Entry(facture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactureExists(id))
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

        // POST: api/Facture
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Facture>> PostFacture(Facture facture)
        {
          if (_context.Factures == null)
          {
              return Problem("Entity set 'NegosudDbContext.Factures'  is null.");
          }
            _context.Factures.Add(facture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacture", new { id = facture.Id }, facture);
        }

        // DELETE: api/Facture/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacture(int id)
        {
            if (_context.Factures == null)
            {
                return NotFound();
            }
            var facture = await _context.Factures.FindAsync(id);
            if (facture == null)
            {
                return NotFound();
            }

            _context.Factures.Remove(facture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactureExists(int id)
        {
            return (_context.Factures?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
