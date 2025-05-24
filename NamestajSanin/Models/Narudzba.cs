using System;

namespace NamestajSanin.Models
{
    public class Narudzba
    {
        public int Id { get; set; }
        public string VrstaNamestaja { get; set; }
        public string Materijal { get; set; }
        public string Dimenzije { get; set; }
        public string Kontakt { get; set; }
        public DateTime DatumKreiranja { get; set; } = DateTime.Now;
    }
}
