using Microsoft.EntityFrameworkCore;
using NamestajSanin.Models;

namespace NamestajSanin.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //DB setovi
        public DbSet<Narudzba> Narudzbe { get; set; }
        public DbSet<Faza> Faze { get; set; }
        public DbSet<Zadatak> Zadaci { get; set; }
        public DbSet<Zaposleni> Zaposleni { get; set; }

        //Relacije
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Narudzba - Faza (1:N)
            modelBuilder.Entity<Faza>()
                .HasOne(f => f.Narudzba)
                .WithMany(n => n.Faze)
                .HasForeignKey(f => f.NarudzbaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Faza - Zadatak (1:N)
            modelBuilder.Entity<Zadatak>()
                .HasOne(z => z.Faza)
                .WithMany(f => f.Zadaci)
                .HasForeignKey(z => z.FazaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Zaposleni - Zadatak (1:N)
            modelBuilder.Entity<Zadatak>()
                .HasOne(z => z.Zaposleni)
                .WithMany(zp => zp.Zadaci)
                .HasForeignKey(z => z.ZaposleniId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
