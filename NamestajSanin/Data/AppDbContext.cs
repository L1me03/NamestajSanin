using Microsoft.EntityFrameworkCore;
using NamestajSanin.Models;
using NamestajSanin.Enums; // važno za enum PozicijaTip

namespace NamestajSanin.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Narudzba> Narudzbe { get; set; }
        public DbSet<Faza> Faze { get; set; }
        public DbSet<Zadatak> Zadaci { get; set; }
        public DbSet<Zaposleni> Zaposleni { get; set; }

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

            // Enum konverzija: Zaposleni.Pozicija (PozicijaTip enum)
            modelBuilder.Entity<Zaposleni>()
                .Property(z => z.Pozicija)
                .HasConversion<string>();
        }
    }
}
