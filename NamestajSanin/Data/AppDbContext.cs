using Microsoft.EntityFrameworkCore;
using NamestajSanin.Models;

namespace NamestajSanin.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Narudzba> Narudzbe { get; set; }
    }
}
