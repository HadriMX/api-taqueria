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
    public class ProductosProveedoresController : ControllerBase
    {
        private readonly TaqueriaContext _context;

        public ProductosProveedoresController(TaqueriaContext context)
        {
            _context = context;
        }

        // GET: api/ProductosProveedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductosProveedores>>> GetProductosProveedores()
        {
            return await _context.ProductosProveedores.ToListAsync();
        }

        // GET: api/ProductosProveedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductosProveedores>> GetProductosProveedores(int id)
        {
            ProductosProveedores productosProveedores = await _context.ProductosProveedores.FindAsync(id);

            if (productosProveedores == null)
            {
                return NotFound();
            }

            return productosProveedores;
        }

        // PUT: api/ProductosProveedores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductosProveedores(int id, ProductosProveedores productosProveedores)
        {
            if (id != productosProveedores.IdProveedor)
            {
                return BadRequest();
            }

            _context.Entry(productosProveedores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosProveedoresExists(id))
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

        // POST: api/ProductosProveedores
        [HttpPost]
        public async Task<ActionResult<ProductosProveedores>> PostProductosProveedores(ProductosProveedores productosProveedores)
        {
            _context.ProductosProveedores.Add(productosProveedores);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductosProveedoresExists(productosProveedores.IdProveedor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductosProveedores", new { id = productosProveedores.IdProveedor }, productosProveedores);
        }

        // DELETE: api/ProductosProveedores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductosProveedores>> DeleteProductosProveedores(int id)
        {
            ProductosProveedores productosProveedores = await _context.ProductosProveedores.FindAsync(id);
            if (productosProveedores == null)
            {
                return NotFound();
            }

            _context.ProductosProveedores.Remove(productosProveedores);
            await _context.SaveChangesAsync();

            return productosProveedores;
        }

        private bool ProductosProveedoresExists(int id)
        {
            return _context.ProductosProveedores.Any(e => e.IdProveedor == id);
        }
    }
}
