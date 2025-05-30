﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NamestajSanin.Data;

#nullable disable

namespace NamestajSanin.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("NamestajSanin.Models.Faza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NarudzbaId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Pocetak")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Redosled")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Trajanje")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NarudzbaId");

                    b.ToTable("Faze");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NarudzbaId = 1,
                            Naziv = "Secenje",
                            Redosled = 1,
                            Status = "nije_poceto",
                            Trajanje = 2
                        },
                        new
                        {
                            Id = 2,
                            NarudzbaId = 1,
                            Naziv = "Lepljenje",
                            Redosled = 2,
                            Status = "nije_poceto",
                            Trajanje = 1
                        },
                        new
                        {
                            Id = 3,
                            NarudzbaId = 1,
                            Naziv = "Sklapanje konstrukcije",
                            Redosled = 3,
                            Status = "nije_poceto",
                            Trajanje = 2
                        },
                        new
                        {
                            Id = 4,
                            NarudzbaId = 1,
                            Naziv = "Farbanje",
                            Redosled = 4,
                            Status = "nije_poceto",
                            Trajanje = 1
                        },
                        new
                        {
                            Id = 5,
                            NarudzbaId = 1,
                            Naziv = "Krojenje",
                            Redosled = 5,
                            Status = "nije_poceto",
                            Trajanje = 1
                        },
                        new
                        {
                            Id = 6,
                            NarudzbaId = 1,
                            Naziv = "Šivenje",
                            Redosled = 6,
                            Status = "nije_poceto",
                            Trajanje = 2
                        },
                        new
                        {
                            Id = 7,
                            NarudzbaId = 1,
                            Naziv = "Tapaciranje",
                            Redosled = 7,
                            Status = "nije_poceto",
                            Trajanje = 2
                        },
                        new
                        {
                            Id = 8,
                            NarudzbaId = 1,
                            Naziv = "Pakovanje",
                            Redosled = 8,
                            Status = "nije_poceto",
                            Trajanje = 1
                        });
                });

            modelBuilder.Entity("NamestajSanin.Models.Narudzba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Boja")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Dimenzije")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("KontaktIme")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Materijal")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Napomena")
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VrstaNamestaja")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Narudzbe");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Boja = "Siva",
                            Datum = new DateTime(2025, 5, 27, 17, 7, 13, 979, DateTimeKind.Utc).AddTicks(9828),
                            Dimenzije = "250x180",
                            Email = "petar@example.com",
                            KontaktIme = "Petar Petrović",
                            Materijal = "Drvo, sunđer, platno",
                            Napomena = "Dostava do stana",
                            Status = "nije_poceto",
                            Telefon = "061111222",
                            VrstaNamestaja = "Ugaona garnitura"
                        });
                });

            modelBuilder.Entity("NamestajSanin.Models.StatistikaUcinak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrojZavrsenihNarudzbi")
                        .HasColumnType("int");

                    b.Property<int>("UkupnoZavrsenihZadataka")
                        .HasColumnType("int");

                    b.Property<int>("ZaposleniId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ZaposleniId");

                    b.ToTable("StatistikaUcinak");
                });

            modelBuilder.Entity("NamestajSanin.Models.Zadatak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FazaId")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ZaposleniId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FazaId");

                    b.HasIndex("ZaposleniId");

                    b.ToTable("Zadaci");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FazaId = 1,
                            Opis = "Secenje",
                            Status = "nije_poceto",
                            ZaposleniId = 2
                        },
                        new
                        {
                            Id = 2,
                            FazaId = 2,
                            Opis = "Lepljenje konstrukcije",
                            Status = "nije_poceto",
                            ZaposleniId = 3
                        },
                        new
                        {
                            Id = 3,
                            FazaId = 3,
                            Opis = "Sklapanje delova",
                            Status = "nije_poceto",
                            ZaposleniId = 2
                        },
                        new
                        {
                            Id = 4,
                            FazaId = 4,
                            Opis = "Farbanje konstrukcije",
                            Status = "nije_poceto",
                            ZaposleniId = 3
                        },
                        new
                        {
                            Id = 5,
                            FazaId = 5,
                            Opis = "Krojenje materijala",
                            Status = "nije_poceto",
                            ZaposleniId = 1
                        },
                        new
                        {
                            Id = 6,
                            FazaId = 6,
                            Opis = "Šivenje jastuka",
                            Status = "nije_poceto",
                            ZaposleniId = 4
                        },
                        new
                        {
                            Id = 7,
                            FazaId = 7,
                            Opis = "Tapaciranje nameštaja",
                            Status = "nije_poceto",
                            ZaposleniId = 5
                        },
                        new
                        {
                            Id = 8,
                            FazaId = 8,
                            Opis = "Pakovanje i zaštita",
                            Status = "nije_poceto",
                            ZaposleniId = 1
                        });
                });

            modelBuilder.Entity("NamestajSanin.Models.Zaposleni", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsMenadzer")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Lozinka")
                        .HasColumnType("longtext");

                    b.Property<string>("Pozicija")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Zaposleni");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ime = "Sako",
                            IsMenadzer = true,
                            Lozinka = "SakoNamestaj",
                            Pozicija = "Tapetar"
                        },
                        new
                        {
                            Id = 2,
                            Ime = "Gile",
                            IsMenadzer = true,
                            Lozinka = "GileNamestaj",
                            Pozicija = "Stolar"
                        },
                        new
                        {
                            Id = 3,
                            Ime = "Selver",
                            IsMenadzer = false,
                            Pozicija = "Stolar"
                        },
                        new
                        {
                            Id = 4,
                            Ime = "Mirzel",
                            IsMenadzer = false,
                            Pozicija = "Tapetar"
                        },
                        new
                        {
                            Id = 5,
                            Ime = "Mila",
                            IsMenadzer = false,
                            Pozicija = "Tapetar"
                        });
                });

            modelBuilder.Entity("NamestajSanin.Models.Faza", b =>
                {
                    b.HasOne("NamestajSanin.Models.Narudzba", "Narudzba")
                        .WithMany("Faze")
                        .HasForeignKey("NarudzbaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Narudzba");
                });

            modelBuilder.Entity("NamestajSanin.Models.StatistikaUcinak", b =>
                {
                    b.HasOne("NamestajSanin.Models.Zaposleni", "Zaposleni")
                        .WithMany()
                        .HasForeignKey("ZaposleniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zaposleni");
                });

            modelBuilder.Entity("NamestajSanin.Models.Zadatak", b =>
                {
                    b.HasOne("NamestajSanin.Models.Faza", "Faza")
                        .WithMany("Zadaci")
                        .HasForeignKey("FazaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NamestajSanin.Models.Zaposleni", "Zaposleni")
                        .WithMany("Zadaci")
                        .HasForeignKey("ZaposleniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faza");

                    b.Navigation("Zaposleni");
                });

            modelBuilder.Entity("NamestajSanin.Models.Faza", b =>
                {
                    b.Navigation("Zadaci");
                });

            modelBuilder.Entity("NamestajSanin.Models.Narudzba", b =>
                {
                    b.Navigation("Faze");
                });

            modelBuilder.Entity("NamestajSanin.Models.Zaposleni", b =>
                {
                    b.Navigation("Zadaci");
                });
#pragma warning restore 612, 618
        }
    }
}
