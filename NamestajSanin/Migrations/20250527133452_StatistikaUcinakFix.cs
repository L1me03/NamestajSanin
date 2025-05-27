using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NamestajSanin.Migrations
{
    /// <inheritdoc />
    public partial class StatistikaUcinakFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Narudzbe",
                keyColumn: "Id",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 5, 27, 13, 34, 51, 447, DateTimeKind.Utc).AddTicks(1036));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Narudzbe",
                keyColumn: "Id",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 5, 27, 13, 23, 50, 260, DateTimeKind.Utc).AddTicks(7396));
        }
    }
}
