using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NamestajSanin.Models
{
    public class Zadatak
    {
        public int Id { get; set; }
        public int FazaId { get; set; }
        public Faza Faza { get; set; }

        public int ZaposleniId { get; set; }
        public Zaposleni Zaposleni { get; set; }

        public string Status { get; set; }  // nije_poceto, u_toku, zavrseno
    }
}