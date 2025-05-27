using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NamestajSanin.Migrations
{
    /// <inheritdoc />
    public partial class NullableLozinkaForZaposleni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMenadzer",
                table: "Zaposleni",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Lozinka",
                table: "Zaposleni",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Narudzbe",
                keyColumn: "Id",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 5, 27, 14, 31, 33, 662, DateTimeKind.Utc).AddTicks(4209));

            migrationBuilder.UpdateData(
                table: "Zaposleni",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsMenadzer", "Lozinka" },
                values: new object[] { true, "SakoNamestaj" });

            migrationBuilder.UpdateData(
                table: "Zaposleni",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsMenadzer", "Lozinka" },
                values: new object[] { true, "GileNamestaj" });

            migrationBuilder.UpdateData(
                table: "Zaposleni",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsMenadzer", "Lozinka" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Zaposleni",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsMenadzer", "Lozinka" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Zaposleni",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IsMenadzer", "Lozinka" },
                values: new object[] { false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMenadzer",
                table: "Zaposleni");

            migrationBuilder.DropColumn(
                name: "Lozinka",
                table: "Zaposleni");

            migrationBuilder.UpdateData(
                table: "Narudzbe",
                keyColumn: "Id",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 5, 27, 13, 34, 51, 447, DateTimeKind.Utc).AddTicks(1036));
        }
    }
}
