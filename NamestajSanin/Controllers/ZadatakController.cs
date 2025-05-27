using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamestajSanin.Data;
using NamestajSanin.Models;
using NamestajSanin.Services;

namespace NamestajSanin.Controllers
{
    // Kontroler za upravljanje zadacima unutar faza
    [ApiController]
    [Route("api/[controller]")]
    public class ZadatakController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly StatusService _statusService;

        public ZadatakController(AppDbContext context, StatusService statusService)
        {
            _context = context;
            _statusService = statusService;
        }

        // Dobavlja sve zadatke
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zadatak>>> Get()
        {
            return await _context.Zadaci
                .Include(z => z.Faza)
                .Include(z => z.Zaposleni)
                .ToListAsync();
        }

        // Dobavlja sve zadatke po ID-u faze         
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

        // Postavljanje novog zadatka 
        [HttpPost]
        public async Task<ActionResult<Zadatak>> Create(Zadatak z)
        {
            _context.Zadaci.Add(z);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = z.Id }, z);
        }

        // Azuriranje statusa zadatka
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            var zadatak = await _context.Zadaci.FindAsync(id);
            if (zadatak == null) return NotFound();

            zadatak.Status = status;
            await _context.SaveChangesAsync();

            // Automatsko ažuriranje faze
            await AzurirajStatusFaze(zadatak.FazaId);

            return NoContent();
        }

        // Helper metoda za azuriranje statusa faze na osnovu zadataka + poziva servis za narudzbu
        private async Task AzurirajStatusFaze(int fazaId)
        {
            var faza = await _context.Faze
                .Include(f => f.Zadaci)
                .Include(f => f.Narudzba)
                .ThenInclude(n => n.Faze)
                .FirstOrDefaultAsync(f => f.Id == fazaId);

            if (faza == null || faza.Zadaci == null || !faza.Zadaci.Any())
                return;

            bool sveZavrsene = faza.Zadaci.All(z => z.Status == "zavrsena");
            bool nekaUToku = faza.Zadaci.Any(z => z.Status == "u_izradi");

            faza.Status = sveZavrsene ? "zavrsena" : nekaUToku ? "u_izradi" : "nije_poceto";

            await _context.SaveChangesAsync();

            // Ažuriraj status narudžbe preko servisa
            await _statusService.AzurirajStatusNarudzbeAsync(faza.NarudzbaId);
        }
    }
}
