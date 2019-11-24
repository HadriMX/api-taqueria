using ApiTaqueria.Persistence;
using ApiTaqueria.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTaqueria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly TaqueriaContext _context;

        public OrdenesController(TaqueriaContext context)
        {
            _context = context;
        }

        // GET: api/Ordenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordenes>>> GetOrdenes()
        {
            return await _context.Ordenes
                .Include(x => x.DetalleOrden).ThenInclude(x => x.IdTacoNavigation)
                .Where(x => x.Estatus == "A")
                .ToListAsync();
        }

        // GET: api/Ordenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ordenes>> GetOrdenes(int id)
        {
            Ordenes ordenes = await _context.Ordenes.FindAsync(id);

            if (ordenes == null)
            {
                return NotFound();
            }

            return ordenes;
        }

        // PUT: api/Ordenes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenes(int id, Ordenes ordenes)
        {
            if (id != ordenes.IdOrden)
            {
                return BadRequest();
            }

            _context.Entry(ordenes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenesExists(id))
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

        // POST: api/Ordenes
        [HttpPost]
        public async Task<ActionResult<Ordenes>> PostOrdenes(Ordenes ordenes)
        {
            _context.Ordenes.Add(ordenes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenes", new { id = ordenes.IdOrden }, ordenes);
        }

        // DELETE: api/Ordenes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ordenes>> DeleteOrdenes(int id)
        {
            Ordenes ordenes = await _context.Ordenes.FindAsync(id);
            if (ordenes == null)
            {
                return NotFound();
            }

            _context.Ordenes.Remove(ordenes);
            await _context.SaveChangesAsync();

            return ordenes;
        }

        private bool OrdenesExists(int id)
        {
            return _context.Ordenes.Any(e => e.IdOrden == id);
        }
    }
}
