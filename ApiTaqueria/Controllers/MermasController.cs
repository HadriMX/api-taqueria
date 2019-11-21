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
    public class MermasController : ControllerBase
    {
        private readonly TaqueriaContext _context;

        public MermasController(TaqueriaContext context)
        {
            _context = context;
        }

        // GET: api/Mermas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mermas>>> GetMermas()
        {
            return await _context.Mermas.Include(x => x.IdProductoNavigation).ToListAsync();
        }

        // GET: api/Mermas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mermas>> GetMermas(int id)
        {
            Mermas mermas = await _context.Mermas.FindAsync(id);

            if (mermas == null)
            {
                return NotFound();
            }

            return mermas;
        }

        // PUT: api/Mermas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMermas(int id, Mermas mermas)
        {
            if (id != mermas.IdMerma)
            {
                return BadRequest();
            }

            _context.Entry(mermas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MermasExists(id))
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

        // POST: api/Mermas
        [HttpPost]
        public async Task<ActionResult<Mermas>> PostMermas(Mermas mermas)
        {
            _context.Mermas.Add(mermas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMermas", new { id = mermas.IdMerma }, mermas);
        }

        // DELETE: api/Mermas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mermas>> DeleteMermas(int id)
        {
            Mermas mermas = await _context.Mermas.FindAsync(id);
            if (mermas == null)
            {
                return NotFound();
            }

            _context.Mermas.Remove(mermas);
            await _context.SaveChangesAsync();

            return mermas;
        }

        private bool MermasExists(int id)
        {
            return _context.Mermas.Any(e => e.IdMerma == id);
        }
    }
}
