using Microsoft.AspNetCore.Mvc;
using NamestajSanin.Data;
using NamestajSanin.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly AppDbContext _context;

    public LoginController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginDto dto)
    {
        var korisnik = _context.Zaposleni
            .FirstOrDefault(z =>
                z.Ime == dto.Ime &&
                z.Lozinka == dto.Lozinka &&
                z.IsMenadzer
            );

        if (korisnik == null)
            return Unauthorized(new { poruka = "Neispravno korisničko ime ili lozinka" });

        return Ok(new { poruka = "Uspješan login", ime = korisnik.Ime });
    }
}
