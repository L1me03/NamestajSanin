using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamestajSanin.Models
{
    public class Narudzba
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string VrstaNamestaja { get; set; }
        public string Dimenzije { get; set; }
        public string Materijal { get; set; }
        public string? Boja { get; set; }
        public string KontaktIme { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }

        public ICollection<Faza> Faze { get; set; }
    }
}
