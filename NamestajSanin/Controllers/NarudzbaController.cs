using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamestajSanin.Data;
using NamestajSanin.Models;
using NamestajSanin.Models.DTOs;
using NamestajSanin.Services;

namespace NamestajSanin.Controllers
{
    // API kontroler za upravljanje narudzbama (za klijenta i menadzera)
    [ApiController]
    [Route("api/[controller]")]
    public class NarudzbaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly StatusService _statusService;

        public NarudzbaController(AppDbContext context, StatusService statusService)
        {
            _context = context;
            _statusService = statusService;
        }

        // Pregled svih narudzbi sa fazama (za menadzera)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Narudzba>>> GetNarudzbe()
        {
            var narudzbe = await _context.Narudzbe.Include(n => n.Faze).ToListAsync();

            // Preračunaj status i dane do završetka
            narudzbe.ForEach(n => _statusService.AzurirajStatusNarudzbe(n));

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

            _statusService.AzurirajStatusNarudzbe(narudzba);
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

        // Pregled statusa narudzbe za klijente + poziv metode StatusService
        [HttpGet("Status/{id}")]
        public async Task<ActionResult<NarudzbaStatusDto>> GetStatus(int id)
        {
            var narudzba = await _context.Narudzbe.Include(n => n.Faze)
                                                  .FirstOrDefaultAsync(n => n.Id == id);

            if (narudzba == null)
                return NotFound();

            _statusService.AzurirajStatusNarudzbe(narudzba);

            var result = new NarudzbaStatusDto
            {
                Status = narudzba.Status,
                DanaDoZavrsetka = narudzba.DanaDoZavrsetka
            };

            return Ok(result);
        }
    }
}
