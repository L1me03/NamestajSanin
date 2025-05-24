using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamestajSanin.Models
{
    public class Faza
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int TrajanjeMin { get; set; }
        public int Redosled { get; set; }

        public int NarudzbaId { get; set; }
        public Narudzba Narudzba { get; set; }

        public ICollection<Zadatak> Zadaci { get; set; }
    }
}