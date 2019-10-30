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
    public class ComprasController : ControllerBase
    {
        private readonly TaqueriaContext _context;

        public ComprasController(TaqueriaContext context)
        {
            _context = context;
        }

        // GET: api/Compras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compras>>> GetCompras()
        {
            return await _context.Compras.ToListAsync();
        }

        // GET: api/Compras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compras>> GetCompras(int id)
        {
            Compras compras = await _context.Compras.FindAsync(id);

            if (compras == null)
            {
                return NotFound();
            }

            return compras;
        }

        // PUT: api/Compras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompras(int id, Compras compras)
        {
            if (id != compras.IdCompra)
            {
                return BadRequest();
            }

            _context.Entry(compras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComprasExists(id))
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

        // POST: api/Compras
        [HttpPost]
        public async Task<ActionResult<Compras>> PostCompras(Compras compras)
        {
            _context.Compras.Add(compras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompras", new { id = compras.IdCompra }, compras);
        }

        // DELETE: api/Compras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Compras>> DeleteCompras(int id)
        {
            Compras compras = await _context.Compras.FindAsync(id);
            if (compras == null)
            {
                return NotFound();
            }

            _context.Compras.Remove(compras);
            await _context.SaveChangesAsync();

            return compras;
        }

        private bool ComprasExists(int id)
        {
            return _context.Compras.Any(e => e.IdCompra == id);
        }
    }
}
