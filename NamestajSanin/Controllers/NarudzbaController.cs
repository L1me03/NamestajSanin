using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamestajSanin.Data;
using NamestajSanin.Models;
using NamestajSanin.Models.DTOs;

namespace NamestajSanin.Controllers
{

    // API kontroler za upravljanje narudzbama (za klijenta i menadzera)
    [ApiController]
    [Route("api/[controller]")]
    public class NarudzbaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NarudzbaController(AppDbContext context)
        {
            _context = context;
        }

        // Pregled svih narudzbi sa fazama (za menadzera)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Narudzba>>> GetNarudzbe()
        {
            var narudzbe = await _context.Narudzbe.Include(n => n.Faze).ToListAsync();

            // Preračunaj status i dane do završetka
            foreach (var n in narudzbe)
                AzurirajStatusINarudzbe(n);

            return narudzbe;
        }

           
        // Dohvacanje jedne narudzbe za menadzera po ID-u 
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


        // Kreiranje narudzbe za klijente
        [HttpPost]
        public async Task<ActionResult<Narudzba>> Create(Narudzba narudzba)
        {
            _context.Narudzbe.Add(narudzba);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetNarudzba), new { id = narudzba.Id }, narudzba);
        }

        // Azuriranje statusa narudzbe uz pomoc faze, sinhronizacija statusa izmedju Faza.cs i Narudzba.cs
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


        // Pregled statusa narudzbe za klijente + poziv metode AzurirajStatusNarudzbe
        [HttpGet("Status/{id}")]
        public async Task<ActionResult<NarudzbaStatusDto>> GetStatus(int id)
        {
            var narudzba = await _context.Narudzbe
                .Include(n => n.Faze)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (narudzba == null)
                return NotFound();

            AzurirajStatusINarudzbe(narudzba);

            var result = new NarudzbaStatusDto
            {
                Status = narudzba.Status,
                DanaDoZavrsetka = narudzba.DanaDoZavrsetka
            };

            return Ok(result);
        }

    }
}

