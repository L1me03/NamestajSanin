using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NamestajSanin.Migrations
{
    /// <inheritdoc />
    public partial class LaptopMigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Smena",
                table: "Zaposleni");

            migrationBuilder.DropColumn(
                name: "Redosled",
                table: "Faze");

            migrationBuilder.RenameColumn(
                name: "TrajanjeMin",
                table: "Faze",
                newName: "Trajanje");

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Zadaci",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Narudzbe",
                keyColumn: "Boja",
                keyValue: null,
                column: "Boja",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Boja",
                table: "Narudzbe",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Napomena",
                table: "Narudzbe",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "Pocetak",
                table: "Faze",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Faze",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Zadaci");

            migrationBuilder.DropColumn(
                name: "Napomena",
                table: "Narudzbe");

            migrationBuilder.DropColumn(
                name: "Pocetak",
                table: "Faze");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Faze");

            migrationBuilder.RenameColumn(
                name: "Trajanje",
                table: "Faze",
                newName: "TrajanjeMin");

            migrationBuilder.AddColumn<string>(
                name: "Smena",
                table: "Zaposleni",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Boja",
                table: "Narudzbe",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Redosled",
                table: "Faze",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
