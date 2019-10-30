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
    public class DetallecomprasController : ControllerBase
    {
        private readonly TaqueriaContext _context;

        public DetallecomprasController(TaqueriaContext context)
        {
            _context = context;
        }

        // GET: api/Detallecompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detallecompra>>> GetDetallecompra()
        {
            return await _context.Detallecompra.ToListAsync();
        }

        // GET: api/Detallecompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Detallecompra>> GetDetallecompra(int id)
        {
            Detallecompra detallecompra = await _context.Detallecompra.FindAsync(id);

            if (detallecompra == null)
            {
                return NotFound();
            }

            return detallecompra;
        }

        // PUT: api/Detallecompras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallecompra(int id, Detallecompra detallecompra)
        {
            if (id != detallecompra.IdCompra)
            {
                return BadRequest();
            }

            _context.Entry(detallecompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallecompraExists(id))
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

        // POST: api/Detallecompras
        [HttpPost]
        public async Task<ActionResult<Detallecompra>> PostDetallecompra(Detallecompra detallecompra)
        {
            _context.Detallecompra.Add(detallecompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallecompra", new { id = detallecompra.IdCompra }, detallecompra);
        }

        // DELETE: api/Detallecompras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Detallecompra>> DeleteDetallecompra(int id)
        {
            Detallecompra detallecompra = await _context.Detallecompra.FindAsync(id);
            if (detallecompra == null)
            {
                return NotFound();
            }

            _context.Detallecompra.Remove(detallecompra);
            await _context.SaveChangesAsync();

            return detallecompra;
        }

        private bool DetallecompraExists(int id)
        {
            return _context.Detallecompra.Any(e => e.IdCompra == id);
        }
    }
}
