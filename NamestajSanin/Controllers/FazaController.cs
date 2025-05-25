using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamestajSanin.Data;
using NamestajSanin.Models;

namespace NamestajSanin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FazaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FazaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faza>>> GetFaze()
        {
            return await _context.Faze.ToListAsync();
        }

        [HttpGet("narudzba/{narudzbaId}")]
        public async Task<ActionResult<IEnumerable<Faza>>> GetFazeZaNarudzbu(int narudzbaId)
        {
            return await _context.Faze.Where(f => f.NarudzbaId == narudzbaId).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Faza>> Create(Faza faza)
        {
            _context.Faze.Add(faza);
            await _context.SaveChangesAsync();
            await AzurirajStatusNarudzbe(faza.NarudzbaId);
            return CreatedAtAction(nameof(GetFaze), new { id = faza.Id }, faza);
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            var faza = await _context.Faze.FindAsync(id);
            if (faza == null) return NotFound();

            faza.Status = status;
            await _context.SaveChangesAsync();
            await AzurirajStatusNarudzbe(faza.NarudzbaId);

            return NoContent();
        }

        private async Task AzurirajStatusNarudzbe(int narudzbaId)
        {
            var narudzba = await _context.Narudzbe.Include(n => n.Faze)
                                                  .FirstOrDefaultAsync(n => n.Id == narudzbaId);

            if (narudzba == null) return;

            bool sveZavrsene = narudzba.Faze.All(f => f.Status == "zavrsena");
            bool nekeUToku = narudzba.Faze.Any(f => f.Status == "u_toku");

            if (sveZavrsene)
                narudzba.Status = "zavrsena";
            else if (nekeUToku)
                narudzba.Status = "u_izradi";
            else
                narudzba.Status = "nije_poceto";

            await _context.SaveChangesAsync();
        }
    }
}
