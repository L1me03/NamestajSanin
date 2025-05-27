using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamestajSanin.Data;
using NamestajSanin.Models;
using NamestajSanin.Models.DTOs;
using NamestajSanin.Services;
using PdfSharpCore;

namespace NamestajSanin.Controllers
{
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

        // Pregled svih narudzbi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Narudzba>>> GetNarudzbe()
        {
            var narudzbe = await _context.Narudzbe.Include(n => n.Faze).ToListAsync();
            narudzbe.ForEach(n => _statusService.AzurirajStatusNarudzbe(n));

            return narudzbe;
        }

        // Pregled narudzbe po ID-u
        [HttpGet("{id}")]
        public async Task<ActionResult<Narudzba>> GetNarudzba(int id)
        {
            var narudzba = await _context.Narudzbe.Include(n => n.Faze)
                                                  .ThenInclude(f => f.Zadaci)
                                                  .ThenInclude(z => z.Zaposleni)
                                                  .FirstOrDefaultAsync(n => n.Id == id);
            if (narudzba == null)
                return NotFound();

            _statusService.AzurirajStatusNarudzbe(narudzba);

            if (narudzba.Status == "zavrsena")
                await AzurirajUcinakPoZaposlenima(narudzba.Id); // ✅ poziv nove metode

            return narudzba;
        }

        // Kreiranje nove narudzbe
        [HttpPost]
        public async Task<ActionResult<Narudzba>> Create(Narudzba narudzba)
        {
            _context.Narudzbe.Add(narudzba);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetNarudzba), new { id = narudzba.Id }, narudzba);
        }

        // Pregled statusa narudzbe
        [HttpGet("Status/{id}")]
        public async Task<ActionResult<NarudzbaStatusDto>> GetStatus(int id)
        {
            var narudzba = await _context.Narudzbe
                                         .Include(n => n.Faze)
                                         .ThenInclude(f => f.Zadaci)
                                         .ThenInclude(z => z.Zaposleni)
                                         .FirstOrDefaultAsync(n => n.Id == id);

            if (narudzba == null)
                return NotFound();

            _statusService.AzurirajStatusNarudzbe(narudzba);

            if (narudzba.Status == "zavrsena")
                await AzurirajUcinakPoZaposlenima(narudzba.Id); // ✅

            var result = new NarudzbaStatusDto
            {
                Status = narudzba.Status,
                DanaDoZavrsetka = narudzba.DanaDoZavrsetka
            };

            return Ok(result);
        }

        // Ažurira statistiku po zaposlenima
        private async Task AzurirajUcinakPoZaposlenima(int narudzbaId)
        {
            var zadaci = await _context.Zadaci
                .Include(z => z.Zaposleni)
                .Include(z => z.Faza)
                .Where(z => z.Faza.NarudzbaId == narudzbaId && z.Status == "zavrsena")
                .ToListAsync();

            var grupisanoPoZaposlenima = zadaci
                .GroupBy(z => z.ZaposleniId)
                .Select(g => new
                {
                    ZaposleniId = g.Key,
                    BrojZadataka = g.Count()
                });

            foreach (var grupa in grupisanoPoZaposlenima)
            {
                var statistika = await _context.StatistikaUcinak
                    .FirstOrDefaultAsync(s => s.ZaposleniId == grupa.ZaposleniId);

                if (statistika == null)
                {
                    statistika = new StatistikaUcinak
                    {
                        ZaposleniId = grupa.ZaposleniId,
                        UkupnoZavrsenihZadataka = 0,
                        BrojZavrsenihNarudzbi = 0
                    };
                    _context.StatistikaUcinak.Add(statistika);
                }

                statistika.UkupnoZavrsenihZadataka += grupa.BrojZadataka;
                statistika.BrojZavrsenihNarudzbi += 1;
            }

            await _context.SaveChangesAsync();
        }

        [HttpGet("{id}/pdf")]
        public IActionResult GetNarudzbaPdf(int id, [FromServices] PdfService pdfService, [FromServices] AppDbContext context)
        {
            var narudzba = context.Narudzbe.FirstOrDefault(n => n.Id == id);

            if (narudzba == null)
                return NotFound("Narudžba nije pronađena.");

            var pdfBytes = pdfService.GenerateNarudzbaPdf(narudzba);
            return File(pdfBytes, "application/pdf", $"Narudzba_{id}.pdf");
        }

    }
}
