using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NamestajSanin.Models
{
    public class Narudzba
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(50)]
        public string VrstaNamestaja { get; set; }

        [Required]
        [MaxLength(50)]
        public string Dimenzije { get; set; }

        [Required]
        [MaxLength(50)]
        public string Materijal { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string? Boja { get; set; }

        [Required]
        public string KontaktIme { get; set; }

        [Required]
        [Phone]
        public string Telefon { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Status { get; set; } = "nije_poceto"; // automatski ažuriran

        public string? Napomena { get; set; }

        public List<Faza>? Faze { get; set; } = new();

        // Automatski proračun dana do završetka
        [NotMapped]
        public int? DanaDoZavrsetka
        {
            get
            {
                if (Faze == null || !Faze.Any())
                    return null;

                var danas = DateTime.UtcNow;

                var krajnjiDatumi = Faze
                    .Where(f => f.Pocetak.HasValue)
                    .Select(f => f.Pocetak.Value.AddDays(f.Trajanje));

                if (!krajnjiDatumi.Any())
                    return null;

                var maxDatum = krajnjiDatumi.Max();
                var totalDays = (maxDatum - danas).TotalDays;

                return (int)Math.Ceiling(totalDays); 
            }
        }
    }
}
