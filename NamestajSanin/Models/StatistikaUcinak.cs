using NamestajSanin.Enums;

namespace NamestajSanin.Models
{
    public class StatistikaUcinak
    {
        public int Id { get; set; }

        // ✅ Veza sa Zaposleni
        public int ZaposleniId { get; set; }
        public Zaposleni Zaposleni { get; set; }

        public int UkupnoZavrsenihZadataka { get; set; }
        public int BrojZavrsenihNarudzbi { get; set; }
    }
}
