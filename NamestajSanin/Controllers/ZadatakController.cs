using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamestajSanin.Data;
using NamestajSanin.Models;

namespace NamestajSanin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZadatakController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ZadatakController(AppDbContext context)
        {
            _context = context;
        }

        // GET svi zadaci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zadatak>>> Get()
        {
            return await _context.Zadaci
                .Include(z => z.Faza)
                .Include(z => z.Zaposleni)
                .ToListAsync();
        }

        // GET po ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Zadatak>> GetById(int id)
        {
            var zadatak = await _context.Zadaci
                .Include(z => z.Faza)
                .Include(z => z.Zaposleni)
                .FirstOrDefaultAsync(z => z.Id == id);

            if (zadatak == null) return NotFound();
            return zadatak;
        }

        // POST novi zadatak
        [HttpPost]
        public async Task<ActionResult<Zadatak>> Create(Zadatak z)
        {
            _context.Zadaci.Add(z);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = z.Id }, z);
        }

        // PATCH status ažuriranje
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            var zadatak = await _context.Zadaci.FindAsync(id);
            if (zadatak == null) return NotFound();

            zadatak.Status = status;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
