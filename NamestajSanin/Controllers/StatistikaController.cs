using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamestajSanin.Data;

namespace NamestajSanin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatistikaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StatistikaController(AppDbContext context)
        {
            _context = context;
        }

        // Prikaz svih preuzetih narudžbi
        [HttpGet("narudzbe")]
        public async Task<IActionResult> GetNarudzbe()
        {
            var podaci = await _context.Narudzbe
                .Select(n => new
                {
                    id = n.Id,
                    ime = n.KontaktIme,
                    telefon = n.Telefon,
                    vrstaNamestaja = n.VrstaNamestaja,
                    status = n.Status
                })
                .ToListAsync();

            return Ok(podaci);
        }

        // Učinak po zaposlenom (ime, pozicija, brojke)
        [HttpGet("zaposleni")]
        public async Task<IActionResult> GetStatistikaZaposlenih()
        {
            var statistike = await _context.StatistikaUcinak
                .Include(s => s.Zaposleni)
                .Select(s => new
                {
                    ime = s.Zaposleni.Ime,
                    pozicija = s.Zaposleni.Pozicija.ToString(),
                    zadaci = s.UkupnoZavrsenihZadataka,
                    narudzbi = s.BrojZavrsenihNarudzbi
                })
                .ToListAsync();

            return Ok(statistike);
        }
    }
}
