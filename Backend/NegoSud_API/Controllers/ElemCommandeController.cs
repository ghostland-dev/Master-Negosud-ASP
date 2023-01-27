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
    public class ElemCommandeController : ControllerBase
    {
        private readonly NegosudDbContext _context;

        public ElemCommandeController(NegosudDbContext context)
        {
            _context = context;
        }

        // GET: api/ElemCommande
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElemCommande>>> GetElemCommandes()
        {
          if (_context.ElemCommandes == null)
          {
              return NotFound();
          }
            return await _context.ElemCommandes.ToListAsync();
        }

        // GET: api/ElemCommande/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ElemCommande>> GetElemCommande(int id)
        {
          if (_context.ElemCommandes == null)
          {
              return NotFound();
          }
            var elemCommande = await _context.ElemCommandes.FindAsync(id);

            if (elemCommande == null)
            {
                return NotFound();
            }

            return elemCommande;
        }

        // PUT: api/ElemCommande/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElemCommande(int id, ElemCommande elemCommande)
        {
            if (id != elemCommande.Id)
            {
                return BadRequest();
            }

            _context.Entry(elemCommande).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElemCommandeExists(id))
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

        // POST: api/ElemCommande
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ElemCommande>> PostElemCommande(ElemCommande elemCommande)
        {
          if (_context.ElemCommandes == null)
          {
              return Problem("Entity set 'NegosudDbContext.ElemCommandes'  is null.");
          }
            _context.ElemCommandes.Add(elemCommande);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElemCommande", new { id = elemCommande.Id }, elemCommande);
        }

        // DELETE: api/ElemCommande/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElemCommande(int id)
        {
            if (_context.ElemCommandes == null)
            {
                return NotFound();
            }
            var elemCommande = await _context.ElemCommandes.FindAsync(id);
            if (elemCommande == null)
            {
                return NotFound();
            }

            _context.ElemCommandes.Remove(elemCommande);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElemCommandeExists(int id)
        {
            return (_context.ElemCommandes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
