using Microsoft.EntityFrameworkCore;
using NamestajSanin.Data;
using NamestajSanin.Models;

namespace NamestajSanin.Services
{
    public class StatusService
    {
        private readonly AppDbContext _context;

        public StatusService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AzurirajStatusNarudzbeAsync(int narudzbaId)
        {
            var narudzba = await _context.Narudzbe.Include(n => n.Faze)
                                                 .FirstOrDefaultAsync(n => n.Id == narudzbaId);
            if (narudzba == null || narudzba.Faze == null) return;

            narudzba.Status = IzracunajStatus(narudzba.Faze.Select(f => f.Status));
            await _context.SaveChangesAsync();
        }

        public void AzurirajStatusNarudzbe(Narudzba narudzba)
        {
            if (narudzba.Faze == null || narudzba.Faze.Count == 0)
            {
                narudzba.Status = "nije_poceto";
                return;
            }

            narudzba.Status = IzracunajStatus(narudzba.Faze.Select(f => f.Status));
        }

        private string IzracunajStatus(IEnumerable<string> statusi)
        {
            if (statusi.All(s => s == "zavrsena")) return "zavrsena";
            if (statusi.Any(s => s == "u_izradi")) return "u_izradi";
            return "nije_poceto";
        }
    }
}
