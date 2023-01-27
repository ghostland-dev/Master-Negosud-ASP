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
    public class ProducteurController : ControllerBase
    {
        private readonly NegosudDbContext _context;

        public ProducteurController(NegosudDbContext context)
        {
            _context = context;
        }

        // GET: api/Producteur
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producteur>>> GetProducteurs()
        {
          if (_context.Producteurs == null)
          {
              return NotFound();
          }
            return await _context.Producteurs.ToListAsync();
        }

        // GET: api/Producteur/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producteur>> GetProducteur(int id)
        {
          if (_context.Producteurs == null)
          {
              return NotFound();
          }
            var producteur = await _context.Producteurs.FindAsync(id);

            if (producteur == null)
            {
                return NotFound();
            }

            return producteur;
        }

        // PUT: api/Producteur/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducteur(int id, Producteur producteur)
        {
            if (id != producteur.Id)
            {
                return BadRequest();
            }

            _context.Entry(producteur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProducteurExists(id))
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

        // POST: api/Producteur
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producteur>> PostProducteur(Producteur producteur)
        {
          if (_context.Producteurs == null)
          {
              return Problem("Entity set 'NegosudDbContext.Producteurs'  is null.");
          }
            _context.Producteurs.Add(producteur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducteur", new { id = producteur.Id }, producteur);
        }

        // DELETE: api/Producteur/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducteur(int id)
        {
            if (_context.Producteurs == null)
            {
                return NotFound();
            }
            var producteur = await _context.Producteurs.FindAsync(id);
            if (producteur == null)
            {
                return NotFound();
            }

            _context.Producteurs.Remove(producteur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProducteurExists(int id)
        {
            return (_context.Producteurs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
