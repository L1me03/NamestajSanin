using System.ComponentModel.DataAnnotations;
using NamestajSanin.Enums;

namespace NamestajSanin.Models
{
    public class Zaposleni
    {
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }

        public PozicijaTip Pozicija { get; set; }

        public List<Zadatak>? Zadaci { get; set; } = new();

    }
}
    