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
    public class AdresseController : ControllerBase
    {
        private readonly NegosudDbContext _context;

        public AdresseController(NegosudDbContext context)
        {
            _context = context;
        }

        // GET: api/Adresse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adresse>>> GetAdresses()
        {
          if (_context.Adresses == null)
          {
              return NotFound();
          }
            return await _context.Adresses.ToListAsync();
        }

        // GET: api/Adresse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adresse>> GetAdresse(int id)
        {
          if (_context.Adresses == null)
          {
              return NotFound();
          }
            var adresse = await _context.Adresses.FindAsync(id);

            if (adresse == null)
            {
                return NotFound();
            }

            return adresse;
        }

        // PUT: api/Adresse/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdresse(int id, Adresse adresse)
        {
            if (id != adresse.Id)
            {
                return BadRequest();
            }

            _context.Entry(adresse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdresseExists(id))
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

        // POST: api/Adresse
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adresse>> PostAdresse(Adresse adresse)
        {
          if (_context.Adresses == null)
          {
              return Problem("Entity set 'NegosudDbContext.Adresses'  is null.");
          }
            _context.Adresses.Add(adresse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdresse", new { id = adresse.Id }, adresse);
        }

        // DELETE: api/Adresse/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdresse(int id)
        {
            if (_context.Adresses == null)
            {
                return NotFound();
            }
            var adresse = await _context.Adresses.FindAsync(id);
            if (adresse == null)
            {
                return NotFound();
            }

            _context.Adresses.Remove(adresse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdresseExists(int id)
        {
            return (_context.Adresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
