using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamestajSanin.Models
{
    public class Faza
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }
        [Range(1, 365, ErrorMessage = "Trajanje mora biti između 1 i 365 dana.")]
        public int Trajanje { get; set; } //u danima

        public int Redosled { get; set; } // Redosled faze u procesu

        public DateTime? Pocetak { get; set; } 

        [Required]
        public string Status { get; set; } = "nije_poceto"; // "nije_poceto", "u_toku", "zavrsena"

        // Relacija prema Narudzbi
        public int NarudzbaId { get; set; }
        public Narudzba? Narudzba { get; set; }

        public List<Zadatak>? Zadaci { get; set; } = new(); // Konekcija sa Zadatak modelom
    }
}
