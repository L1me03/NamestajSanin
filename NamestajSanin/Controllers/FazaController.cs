using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamestajSanin.Data;
using NamestajSanin.Models;
using NamestajSanin.Services;

namespace NamestajSanin.Controllers
{
    // Kontroler za upravljanje fazama proizvodnje unutar narudzbi
    [ApiController]
    [Route("api/[controller]")]
    public class FazaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly StatusService _statusService;

        public FazaController(AppDbContext context, StatusService statusService)
        {
            _context = context;
            _statusService = statusService;
        }

        // Dohvatanje svih faza u sistemu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faza>>> GetFaze()
        {
            return await _context.Faze.ToListAsync();
        }

        // Dohvatanje faza u sistemu po ID-u narudzbe, koje pripadaju toj narudzbi
        [HttpGet("narudzba/{narudzbaId}")]
        public async Task<ActionResult<IEnumerable<Faza>>> GetFazeZaNarudzbu(int narudzbaId)
        {
            return await _context.Faze.Where(f => f.NarudzbaId == narudzbaId).ToListAsync();
        }

        // Kreiranje nove faze (nakon što menadžer pokrene izradu narudžbe)
        // Nakon dodavanja faze, automatski se ažurira status narudžbe kojoj pripada
        [HttpPost]
        public async Task<ActionResult<Faza>> Create(Faza faza)
        {
            _context.Faze.Add(faza);
            await _context.SaveChangesAsync();
            await _statusService.AzurirajStatusNarudzbeAsync(faza.NarudzbaId);
            return CreatedAtAction(nameof(GetFaze), new { id = faza.Id }, faza);
        }

        // Azuriranje statusa konkretne faze koja se automatski posle azurira u narudzbi
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            var faza = await _context.Faze.FindAsync(id);
            if (faza == null) return NotFound();

            faza.Status = status;
            await _context.SaveChangesAsync();
            await _statusService.AzurirajStatusNarudzbeAsync(faza.NarudzbaId);

            return NoContent();
        }
    }
}
