using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NamestajSanin.Migrations
{
    /// <inheritdoc />
    public partial class NovaMigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Narudzbe",
                keyColumn: "Id",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 5, 27, 17, 7, 13, 979, DateTimeKind.Utc).AddTicks(9828));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Narudzbe",
                keyColumn: "Id",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 5, 27, 14, 31, 33, 662, DateTimeKind.Utc).AddTicks(4209));
        }
    }
}
