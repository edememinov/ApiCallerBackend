using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ButtonDataService.Data.Concrete;
using ButtonDataService.Data.Models;

namespace ButtonDataService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanvasController : ControllerBase
    {
        private readonly ButtonContext _context;

        public CanvasController(ButtonContext context)
        {
            _context = context;
        }

        // GET: api/Canvas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Canvas>>> GetCanvases([FromQuery] string category=null, string name=null)
        {
            var canvases = await _context.Canvases.ToListAsync();
            if (name != null)
            {
                canvases = canvases.Where(x => x.Name.Contains(name)).ToList();
            }

            if(category != null)
            {
                canvases = canvases.Where(x => x.Category.Contains(category)).ToList();
            }

            return canvases;
        }

        // GET: api/Canvas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Canvas>> GetCanvas(int id)
        {
            var canvas = await _context.Canvases.FindAsync(id);

            if (canvas == null)
            {
                return NotFound();
            }

            return canvas;
        }

        // PUT: api/Canvas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCanvas(int id, Canvas canvas)
        {
            if (id != canvas.ID)
            {
                return BadRequest();
            }

            _context.Entry(canvas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CanvasExists(id))
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

        // POST: api/Canvas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Canvas>> PostCanvas(Canvas canvas)
        {
            _context.Canvases.Add(canvas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCanvas", new { id = canvas.ID }, canvas);
        }

        // DELETE: api/Canvas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Canvas>> DeleteCanvas(int id)
        {
            var canvas = await _context.Canvases.FindAsync(id);
            if (canvas == null)
            {
                return NotFound();
            }

            _context.Canvases.Remove(canvas);
            await _context.SaveChangesAsync();

            return canvas;
        }

        private bool CanvasExists(int id)
        {
            return _context.Canvases.Any(e => e.ID == id);
        }
    }
}
