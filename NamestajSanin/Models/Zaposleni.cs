using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamestajSanin.Models
{
    public class Zaposleni
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Pozicija { get; set; }
        public string Smena { get; set; }

        public ICollection<Zadatak> Zadaci { get; set; }
    }
}