using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NamestajSanin.Migrations
{
    /// <inheritdoc />
    public partial class PcMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Redosled",
                table: "Faze",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Narudzbe",
                columns: new[] { "Id", "Boja", "Datum", "Dimenzije", "Email", "KontaktIme", "Materijal", "Napomena", "Status", "Telefon", "VrstaNamestaja" },
                values: new object[] { 1, "Siva", new DateTime(2025, 5, 27, 10, 29, 33, 955, DateTimeKind.Utc).AddTicks(97), "250x180", "petar@example.com", "Petar Petrović", "Drvo, sunđer, platno", "Dostava do stana", "nije_poceto", "061111222", "Ugaona garnitura" });

            migrationBuilder.InsertData(
                table: "Zaposleni",
                columns: new[] { "Id", "Ime", "Pozicija" },
                values: new object[,]
                {
                    { 1, "Gile", "Stolar" },
                    { 2, "Sako", "Tapetar" }
                });

            migrationBuilder.InsertData(
                table: "Faze",
                columns: new[] { "Id", "NarudzbaId", "Naziv", "Pocetak", "Redosled", "Status", "Trajanje" },
                values: new object[,]
                {
                    { 1, 1, "Obrada drveta", null, 1, "nije_poceto", 2 },
                    { 2, 1, "Farbanje", null, 2, "nije_poceto", 1 },
                    { 3, 1, "Krojenje", null, 3, "nije_poceto", 1 },
                    { 4, 1, "Šivenje", null, 4, "nije_poceto", 2 },
                    { 5, 1, "Tapaciranje", null, 5, "nije_poceto", 2 },
                    { 6, 1, "Pakovanje", null, 6, "nije_poceto", 1 }
                });

            migrationBuilder.InsertData(
                table: "Zadaci",
                columns: new[] { "Id", "FazaId", "Opis", "Status", "ZaposleniId" },
                values: new object[,]
                {
                    { 1, 1, "Obrada rama", "nije_poceto", 1 },
                    { 2, 2, "Farbanje konstrukcije", "nije_poceto", 1 },
                    { 3, 3, "Krojenje materijala", "nije_poceto", 2 },
                    { 4, 4, "Šivenje jastuka", "nije_poceto", 2 },
                    { 5, 5, "Tapaciranje rama", "nije_poceto", 2 },
                    { 6, 6, "Pakovanje i zaštita", "nije_poceto", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Zadaci",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zadaci",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zadaci",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zadaci",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Zadaci",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Zadaci",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Faze",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faze",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Faze",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Faze",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Faze",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Faze",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Zaposleni",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zaposleni",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Narudzbe",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Redosled",
                table: "Faze");
        }
    }
}
