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
    public class FournisseurController : ControllerBase
    {
        private readonly NegosudDbContext _context;

        public FournisseurController(NegosudDbContext context)
        {
            _context = context;
        }

        // GET: api/Fournisseur
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fournisseur>>> GetFournisseurs()
        {
          if (_context.Fournisseurs == null)
          {
              return NotFound();
          }
            return await _context.Fournisseurs.ToListAsync();
        }

        // GET: api/Fournisseur/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fournisseur>> GetFournisseur(int id)
        {
          if (_context.Fournisseurs == null)
          {
              return NotFound();
          }
            var fournisseur = await _context.Fournisseurs.FindAsync(id);

            if (fournisseur == null)
            {
                return NotFound();
            }

            return fournisseur;
        }

        // PUT: api/Fournisseur/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFournisseur(int id, Fournisseur fournisseur)
        {
            if (id != fournisseur.Id)
            {
                return BadRequest();
            }

            _context.Entry(fournisseur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FournisseurExists(id))
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

        // POST: api/Fournisseur
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fournisseur>> PostFournisseur(Fournisseur fournisseur)
        {
          if (_context.Fournisseurs == null)
          {
              return Problem("Entity set 'NegosudDbContext.Fournisseurs'  is null.");
          }
            _context.Fournisseurs.Add(fournisseur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFournisseur", new { id = fournisseur.Id }, fournisseur);
        }

        // DELETE: api/Fournisseur/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFournisseur(int id)
        {
            if (_context.Fournisseurs == null)
            {
                return NotFound();
            }
            var fournisseur = await _context.Fournisseurs.FindAsync(id);
            if (fournisseur == null)
            {
                return NotFound();
            }

            _context.Fournisseurs.Remove(fournisseur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FournisseurExists(int id)
        {
            return (_context.Fournisseurs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
