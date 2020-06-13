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
    public class ButtonsController : ControllerBase
    {
        private readonly ButtonContext _context;

        public ButtonsController(ButtonContext context)
        {
            _context = context;
        }

        // GET: api/Buttons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Button>>> GetButtons([FromQuery] string category = null, string name = null)
        {
            var buttons = await _context.Buttons.ToListAsync();
            if (name != null)
            {
                buttons = buttons.Where(x => x.Name.Contains(name)).ToList();
            }

            if (category != null)
            {
                buttons = buttons.Where(x => x.Category.Contains(category)).ToList();
            }

            return buttons;
        }

        // GET: api/Buttons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Button>> GetButton(int id)
        {
            var button = await _context.Buttons.FindAsync(id);

            if (button == null)
            {
                return NotFound();
            }

            return button;
        }

        // PUT: api/Buttons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutButton(int id, Button button)
        {
            if (id != button.ID)
            {
                return BadRequest();
            }

            _context.Entry(button).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ButtonExists(id))
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

        // POST: api/Buttons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Button>> PostButton(Button button)
        {
            _context.Buttons.Add(button);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetButton", new { id = button.ID }, button);
        }

        // DELETE: api/Buttons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Button>> DeleteButton(int id)
        {
            var button = await _context.Buttons.FindAsync(id);
            if (button == null)
            {
                return NotFound();
            }

            _context.Buttons.Remove(button);
            await _context.SaveChangesAsync();

            return button;
        }

        private bool ButtonExists(int id)
        {
            return _context.Buttons.Any(e => e.ID == id);
        }
    }
}
