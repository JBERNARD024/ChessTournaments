using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChessTournaments.Data;
using ChessTournaments.Models;

namespace ChessTournaments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipasJsonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EquipasJsonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EquipasJson
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipa>>> GetEquipa()
        {
          if (_context.Equipa == null)
          {
              return NotFound();
          }
            return await _context.Equipa.ToListAsync();
        }

        // GET: api/EquipasJson/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipa>> GetEquipa(int id)
        {
          if (_context.Equipa == null)
          {
              return NotFound();
          }
            var equipa = await _context.Equipa.FindAsync(id);

            if (equipa == null)
            {
                return NotFound();
            }

            return equipa;
        }

        // PUT: api/EquipasJson/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipa(int id, Equipa equipa)
        {
            if (id != equipa.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipaExists(id))
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

        // POST: api/EquipasJson
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equipa>> PostEquipa(Equipa equipa)
        {
          if (_context.Equipa == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Equipa'  is null.");
          }
            _context.Equipa.Add(equipa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipa", new { id = equipa.Id }, equipa);
        }

        // DELETE: api/EquipasJson/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipa(int id)
        {
            if (_context.Equipa == null)
            {
                return NotFound();
            }
            var equipa = await _context.Equipa.FindAsync(id);
            if (equipa == null)
            {
                return NotFound();
            }

            _context.Equipa.Remove(equipa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipaExists(int id)
        {
            return (_context.Equipa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
