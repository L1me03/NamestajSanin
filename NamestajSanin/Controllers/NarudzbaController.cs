using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamestajSanin.Data;
using NamestajSanin.Models;

namespace NamestajSanin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NarudzbaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NarudzbaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Narudzba>>> GetNarudzbe()
        {
            var narudzbe = await _context.Narudzbe.Include(n => n.Faze).ToListAsync();

            // Preračunaj status i dane do završetka
            foreach (var n in narudzbe)
                AzurirajStatusINarudzbe(n);

            return narudzbe;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Narudzba>> GetNarudzba(int id)
        {
            var narudzba = await _context.Narudzbe.Include(n => n.Faze)
                                                  .FirstOrDefaultAsync(n => n.Id == id);
            if (narudzba == null)
                return NotFound();

            AzurirajStatusINarudzbe(narudzba);
            return narudzba;
        }

        [HttpPost]
        public async Task<ActionResult<Narudzba>> Create(Narudzba narudzba)
        {
            _context.Narudzbe.Add(narudzba);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetNarudzba), new { id = narudzba.Id }, narudzba);
        }

        private void AzurirajStatusINarudzbe(Narudzba narudzba)
        {
            if (narudzba.Faze == null || narudzba.Faze.Count == 0)
            {
                narudzba.Status = "nije_poceto";
                return;
            }

            bool sveZavrsene = narudzba.Faze.All(f => f.Status == "zavrsena");
            bool nekeUToku = narudzba.Faze.Any(f => f.Status == "u_toku");

            if (sveZavrsene)
                narudzba.Status = "zavrsena";
            else if (nekeUToku)
                narudzba.Status = "u_izradi";
            else
                narudzba.Status = "nije_poceto";

            _context.SaveChanges(); // ažurira bazu
        }
    }
}
