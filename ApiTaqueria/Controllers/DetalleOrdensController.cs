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
    public class DetalleOrdensController : ControllerBase
    {
        private readonly TaqueriaContext _context;

        public DetalleOrdensController(TaqueriaContext context)
        {
            _context = context;
        }

        // GET: api/DetalleOrdens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleOrden>>> GetDetalleOrden()
        {
            return await _context.DetalleOrden.ToListAsync();
        }

        // GET: api/DetalleOrdens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleOrden>> GetDetalleOrden(int id)
        {
            DetalleOrden detalleOrden = await _context.DetalleOrden.FindAsync(id);

            if (detalleOrden == null)
            {
                return NotFound();
            }

            return detalleOrden;
        }

        // PUT: api/DetalleOrdens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleOrden(int id, DetalleOrden detalleOrden)
        {
            if (id != detalleOrden.IdOrden)
            {
                return BadRequest();
            }

            _context.Entry(detalleOrden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleOrdenExists(id))
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

        // POST: api/DetalleOrdens
        [HttpPost]
        public async Task<ActionResult<DetalleOrden>> PostDetalleOrden(DetalleOrden detalleOrden)
        {
            _context.DetalleOrden.Add(detalleOrden);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DetalleOrdenExists(detalleOrden.IdOrden))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDetalleOrden", new { id = detalleOrden.IdOrden }, detalleOrden);
        }

        // DELETE: api/DetalleOrdens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalleOrden>> DeleteDetalleOrden(int id)
        {
            DetalleOrden detalleOrden = await _context.DetalleOrden.FindAsync(id);
            if (detalleOrden == null)
            {
                return NotFound();
            }

            _context.DetalleOrden.Remove(detalleOrden);
            await _context.SaveChangesAsync();

            return detalleOrden;
        }

        private bool DetalleOrdenExists(int id)
        {
            return _context.DetalleOrden.Any(e => e.IdOrden == id);
        }
    }
}
