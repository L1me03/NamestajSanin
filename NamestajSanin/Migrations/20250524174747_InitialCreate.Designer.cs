﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NamestajSanin.Data;

#nullable disable

namespace NamestajSanin.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250524174747_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("NamestajSanin.Models.Narudzba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumKreiranja")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Dimenzije")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Kontakt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Materijal")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VrstaNamestaja")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Narudzbe");
                });
#pragma warning restore 612, 618
        }
    }
}
