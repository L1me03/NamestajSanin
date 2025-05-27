using System.ComponentModel.DataAnnotations.Schema;
using NamestajSanin.Models;
using NamestajSanin.Data;



namespace NamestajSanin.Models.DTOs

{
    public class NarudzbaStatusDto
    {
        public string Status { get; set; } = " ";
        public int? DanaDoZavrsetka { get; set; }
    }

}
    

