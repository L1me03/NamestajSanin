using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamestajSanin.Data;
using NamestajSanin.Models;

namespace NamestajSanin.Controllers
{
    //Api kontroler za zaposlene
    [ApiController]
    [Route("api/[controller]")]
    public class ZaposleniController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ZaposleniController(AppDbContext context)
        {
            _context = context;
        }

        // Vraca sve zaposlene
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zaposleni>>> Get()
        {
            return await _context.Zaposleni.ToListAsync();
        }

        // Vraca zaposlenog po ID-u
        [HttpGet("{id}")]
        public async Task<ActionResult<Zaposleni>> GetById(int id)
        {
            var zaposleni = await _context.Zaposleni.FindAsync(id);
            if (zaposleni == null) return NotFound();
            return zaposleni;
        }

        // Dodaje novog zaposlenog
        [HttpPost]
        public async Task<ActionResult<Zaposleni>> Create(Zaposleni z)
        {
            _context.Zaposleni.Add(z);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = z.Id }, z);
        }

        // Modifikuje postojećeg zaposlenog
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Zaposleni z)
        {
            if (id != z.Id) return BadRequest();

            _context.Entry(z).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Brise zaposlenog iz sistema
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var zaposleni = await _context.Zaposleni.FindAsync(id);
            if (zaposleni == null) return NotFound();

            _context.Zaposleni.Remove(zaposleni);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
