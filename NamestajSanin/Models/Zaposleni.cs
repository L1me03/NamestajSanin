using System.ComponentModel.DataAnnotations;
using NamestajSanin.Enums;

namespace NamestajSanin.Models
{
    public class Zaposleni
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Ime { get; set; }
        [Required]
        public PozicijaTip Pozicija { get; set; } //koristi enum

        public List<Zadatak>? Zadaci { get; set; } = new();
        [Required]
        public bool IsMenadzer { get; set; } = false;

      
        public string? Lozinka { get; set; } 

    }
}
    