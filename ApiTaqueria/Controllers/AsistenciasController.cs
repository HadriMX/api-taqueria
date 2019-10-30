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
    public class AsistenciasController : ControllerBase
    {
        private readonly TaqueriaContext _context;

        public AsistenciasController(TaqueriaContext context)
        {
            _context = context;
        }

        // GET: api/Asistencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asistencias>>> GetAsistencias()
        {
            return await _context.Asistencias.ToListAsync();
        }

        // GET: api/Asistencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asistencias>> GetAsistencias(int id)
        {
            Asistencias asistencias = await _context.Asistencias.FindAsync(id);

            if (asistencias == null)
            {
                return NotFound();
            }

            return asistencias;
        }

        // PUT: api/Asistencias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsistencias(int id, Asistencias asistencias)
        {
            if (id != asistencias.IdAsistencia)
            {
                return BadRequest();
            }

            _context.Entry(asistencias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsistenciasExists(id))
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

        // POST: api/Asistencias
        [HttpPost]
        public async Task<ActionResult<Asistencias>> PostAsistencias(Asistencias asistencias)
        {
            _context.Asistencias.Add(asistencias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsistencias", new { id = asistencias.IdAsistencia }, asistencias);
        }

        // DELETE: api/Asistencias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Asistencias>> DeleteAsistencias(int id)
        {
            Asistencias asistencias = await _context.Asistencias.FindAsync(id);
            if (asistencias == null)
            {
                return NotFound();
            }

            _context.Asistencias.Remove(asistencias);
            await _context.SaveChangesAsync();

            return asistencias;
        }

        private bool AsistenciasExists(int id)
        {
            return _context.Asistencias.Any(e => e.IdAsistencia == id);
        }
    }
}
