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
        public DbSet<StatistikaUcinak> StatistikaUcinak { get; set; }

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

            // Relacija : Zaposleni - StatistikaUcinak (1:N)
            modelBuilder.Entity<StatistikaUcinak>()
                .HasOne(s => s.Zaposleni)
                .WithMany()
                .HasForeignKey(s => s.ZaposleniId)
                .OnDelete(DeleteBehavior.Cascade);

            // Konverzija enum vrednosti (PozicijaTip) u string u bazi
            modelBuilder.Entity<Zaposleni>()
                .Property(z => z.Pozicija)
                .HasConversion<string>();

            // Seed podaci: zaposleni
            modelBuilder.Entity<Zaposleni>().HasData(
                new Zaposleni { Id = 1, Ime = "Sako", Pozicija = PozicijaTip.Tapetar, IsMenadzer = true, Lozinka = "SakoNamestaj" },
                new Zaposleni { Id = 2, Ime = "Gile", Pozicija = PozicijaTip.Stolar , IsMenadzer = true, Lozinka = "GileNamestaj" },
                new Zaposleni { Id = 3, Ime = "Selver", Pozicija = PozicijaTip.Stolar , IsMenadzer = false},
                new Zaposleni { Id = 4, Ime = "Mirzel", Pozicija = PozicijaTip.Tapetar ,IsMenadzer = false },
                new Zaposleni { Id = 5, Ime = "Mila", Pozicija = PozicijaTip.Tapetar ,IsMenadzer = false }

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
                new Faza { Id = 1, Naziv = "Secenje", Trajanje = 2, Redosled = 1, NarudzbaId = 1 },
                new Faza { Id = 2, Naziv = "Lepljenje", Trajanje = 1, Redosled = 2, NarudzbaId = 1 },
                new Faza { Id = 3, Naziv = "Sklapanje konstrukcije", Trajanje = 2, Redosled = 3, NarudzbaId = 1 },
                new Faza { Id = 4, Naziv = "Farbanje", Trajanje = 1, Redosled = 4, NarudzbaId = 1 },
                new Faza { Id = 5, Naziv = "Krojenje", Trajanje = 1, Redosled = 5, NarudzbaId = 1 },
                new Faza { Id = 6, Naziv = "Šivenje", Trajanje = 2, Redosled = 6, NarudzbaId = 1 },
                new Faza { Id = 7, Naziv = "Tapaciranje", Trajanje = 2, Redosled = 7, NarudzbaId = 1 },
                new Faza { Id = 8, Naziv = "Pakovanje", Trajanje = 1, Redosled = 8, NarudzbaId = 1 }
            );

            // Seed podaci: zadaci
            modelBuilder.Entity<Zadatak>().HasData(
                // STOLARI (Gile - 2, Selver - 3)
                new Zadatak { Id = 1, Opis = "Secenje", Status = "nije_poceto", FazaId = 1, ZaposleniId = 2 },
                new Zadatak { Id = 2, Opis = "Lepljenje konstrukcije", Status = "nije_poceto", FazaId = 2, ZaposleniId = 3 },
                new Zadatak { Id = 3, Opis = "Sklapanje delova", Status = "nije_poceto", FazaId = 3, ZaposleniId = 2 },
                new Zadatak { Id = 4, Opis = "Farbanje konstrukcije", Status = "nije_poceto", FazaId = 4, ZaposleniId = 3 },

                // TAPETARI (Sako - 1, Mirzel - 4, Mila - 5)
                new Zadatak { Id = 5, Opis = "Krojenje materijala", Status = "nije_poceto", FazaId = 5, ZaposleniId = 1 },
                new Zadatak { Id = 6, Opis = "Šivenje jastuka", Status = "nije_poceto", FazaId = 6, ZaposleniId = 4 },
                new Zadatak { Id = 7, Opis = "Tapaciranje nameštaja", Status = "nije_poceto", FazaId = 7, ZaposleniId = 5 },
                new Zadatak { Id = 8, Opis = "Pakovanje i zaštita", Status = "nije_poceto", FazaId = 8, ZaposleniId = 1 }
            );

        }
    }
}
