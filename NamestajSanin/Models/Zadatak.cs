using System.ComponentModel.DataAnnotations;

namespace NamestajSanin.Models
{
    public class Zadatak
    {
        public int Id { get; set; }

        public string? Opis { get; set; }

        public string Status { get; set; } = "nije_poceto"; // "nije_poceto", "u_izradi", "zavrsena"

        // Relacije
        public int FazaId { get; set; }
        public Faza? Faza { get; set; }

        public int ZaposleniId { get; set; }
        public Zaposleni? Zaposleni { get; set; }
    }
}
