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
    public class ProduitController : ControllerBase
    {
        private readonly NegosudDbContext _context;

        public ProduitController(NegosudDbContext context)
        {
            _context = context;
        }

        // GET: api/Produit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produit>>> GetProduits()
        {
          if (_context.Produits == null)
          {
              return NotFound();
          }
            return await _context.Produits.ToListAsync();
        }

        // GET: api/Produit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produit>> GetProduit(int id)
        {
          if (_context.Produits == null)
          {
              return NotFound();
          }
            var produit = await _context.Produits.FindAsync(id);

            if (produit == null)
            {
                return NotFound();
            }

            return produit;
        }

        // PUT: api/Produit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduit(int id, Produit produit)
        {
            if (id != produit.Id)
            {
                return BadRequest();
            }

            _context.Entry(produit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduitExists(id))
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

        // POST: api/Produit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Produit>> PostProduit(Produit produit)
        {
          if (_context.Produits == null)
          {
              return Problem("Entity set 'NegosudDbContext.Produits'  is null.");
          }
            _context.Produits.Add(produit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduit", new { id = produit.Id }, produit);
        }

        // DELETE: api/Produit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduit(int id)
        {
            if (_context.Produits == null)
            {
                return NotFound();
            }
            var produit = await _context.Produits.FindAsync(id);
            if (produit == null)
            {
                return NotFound();
            }

            _context.Produits.Remove(produit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProduitExists(int id)
        {
            return (_context.Produits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
