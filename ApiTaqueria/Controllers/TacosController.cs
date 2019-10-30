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
    public class TacosController : ControllerBase
    {
        private readonly TaqueriaContext _context;

        public TacosController(TaqueriaContext context)
        {
            _context = context;
        }

        // GET: api/Tacos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tacos>>> GetTacos()
        {
            return await _context.Tacos.ToListAsync();
        }

        // GET: api/Tacos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tacos>> GetTacos(int id)
        {
            Tacos tacos = await _context.Tacos.FindAsync(id);

            if (tacos == null)
            {
                return NotFound();
            }

            return tacos;
        }

        // PUT: api/Tacos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTacos(int id, Tacos tacos)
        {
            if (id != tacos.IdTacos)
            {
                return BadRequest();
            }

            _context.Entry(tacos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TacosExists(id))
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

        // POST: api/Tacos
        [HttpPost]
        public async Task<ActionResult<Tacos>> PostTacos(Tacos tacos)
        {
            _context.Tacos.Add(tacos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTacos", new { id = tacos.IdTacos }, tacos);
        }

        // DELETE: api/Tacos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tacos>> DeleteTacos(int id)
        {
            Tacos tacos = await _context.Tacos.FindAsync(id);
            if (tacos == null)
            {
                return NotFound();
            }

            _context.Tacos.Remove(tacos);
            await _context.SaveChangesAsync();

            return tacos;
        }

        private bool TacosExists(int id)
        {
            return _context.Tacos.Any(e => e.IdTacos == id);
        }
    }
}
