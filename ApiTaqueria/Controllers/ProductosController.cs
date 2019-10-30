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
    public class ProductosController : ControllerBase
    {
        private readonly TaqueriaContext _context;

        public ProductosController(TaqueriaContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> GetProductos(int id)
        {
            Productos productos = await _context.Productos.FindAsync(id);

            if (productos == null)
            {
                return NotFound();
            }

            return productos;
        }

        // PUT: api/Productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductos(int id, Productos productos)
        {
            if (id != productos.IdProducto)
            {
                return BadRequest();
            }

            _context.Entry(productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosExists(id))
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

        // POST: api/Productos
        [HttpPost]
        public async Task<ActionResult<Productos>> PostProductos(Productos productos)
        {
            _context.Productos.Add(productos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductos", new { id = productos.IdProducto }, productos);
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Productos>> DeleteProductos(int id)
        {
            Productos productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(productos);
            await _context.SaveChangesAsync();

            return productos;
        }

        private bool ProductosExists(int id)
        {
            return _context.Productos.Any(e => e.IdProducto == id);
        }
    }
}
