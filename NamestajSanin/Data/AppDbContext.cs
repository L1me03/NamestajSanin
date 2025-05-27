using Microsoft.EntityFrameworkCore;
using NamestajSanin.Models;
using NamestajSanin.Enums;

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

            // Relacija: Narudzba - Faza (1:N)
            modelBuilder.Entity<Faza>()
                .HasOne(f => f.Narudzba)
                .WithMany(n => n.Faze)
                .HasForeignKey(f => f.NarudzbaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacija: Faza - Zadatak (1:N)
            modelBuilder.Entity<Zadatak>()
                .HasOne(z => z.Faza)
                .WithMany(f => f.Zadaci)
                .HasForeignKey(z => z.FazaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacija: Zaposleni - Zadatak (1:N)
            modelBuilder.Entity<Zadatak>()
                .HasOne(z => z.Zaposleni)
                .WithMany(zp => zp.Zadaci)
                .HasForeignKey(z => z.ZaposleniId)
                .OnDelete(DeleteBehavior.Cascade);

            // Konverzija enum vrednosti (PozicijaTip) u string u bazi
            modelBuilder.Entity<Zaposleni>()
                .Property(z => z.Pozicija)
                .HasConversion<string>();

            // Seed podaci: zaposleni
            modelBuilder.Entity<Zaposleni>().HasData(
                new Zaposleni { Id = 1, Ime = "Gile", Pozicija = PozicijaTip.Stolar },
                new Zaposleni { Id = 2, Ime = "Sako", Pozicija = PozicijaTip.Tapetar }
            );

            // Seed podaci: narudzba
            modelBuilder.Entity<Narudzba>().HasData(
                new Narudzba
                {
                    Id = 1,
                    VrstaNamestaja = "Ugaona garnitura",
                    Dimenzije = "250x180",
                    Materijal = "Drvo, sunđer, platno",
                    Boja = "Siva",
                    KontaktIme = "Petar Petrović",
                    Telefon = "061111222",
                    Email = "petar@example.com",
                    Napomena = "Dostava do stana",
                    Status = "nije_poceto",
                    Datum = DateTime.UtcNow
                }
            );

            // Seed podaci: faze
            modelBuilder.Entity<Faza>().HasData(
                new Faza { Id = 1, Naziv = "Obrada drveta", Trajanje = 2, Redosled = 1, NarudzbaId = 1 },
                new Faza { Id = 2, Naziv = "Farbanje", Trajanje = 1, Redosled = 2, NarudzbaId = 1 },
                new Faza { Id = 3, Naziv = "Krojenje", Trajanje = 1, Redosled = 3, NarudzbaId = 1 },
                new Faza { Id = 4, Naziv = "Šivenje", Trajanje = 2, Redosled = 4, NarudzbaId = 1 },
                new Faza { Id = 5, Naziv = "Tapaciranje", Trajanje = 2, Redosled = 5, NarudzbaId = 1 },
                new Faza { Id = 6, Naziv = "Pakovanje", Trajanje = 1, Redosled = 6, NarudzbaId = 1 }
            );

            // Seed podaci: zadaci
            modelBuilder.Entity<Zadatak>().HasData(
                new Zadatak { Id = 1, Opis = "Obrada rama", Status = "nije_poceto", FazaId = 1, ZaposleniId = 1 },
                new Zadatak { Id = 2, Opis = "Farbanje konstrukcije", Status = "nije_poceto", FazaId = 2, ZaposleniId = 1 },
                new Zadatak { Id = 3, Opis = "Krojenje materijala", Status = "nije_poceto", FazaId = 3, ZaposleniId = 2 },
                new Zadatak { Id = 4, Opis = "Šivenje jastuka", Status = "nije_poceto", FazaId = 4, ZaposleniId = 2 },
                new Zadatak { Id = 5, Opis = "Tapaciranje rama", Status = "nije_poceto", FazaId = 5, ZaposleniId = 2 },
                new Zadatak { Id = 6, Opis = "Pakovanje i zaštita", Status = "nije_poceto", FazaId = 6, ZaposleniId = 2 }
            );
        }
    }
}
