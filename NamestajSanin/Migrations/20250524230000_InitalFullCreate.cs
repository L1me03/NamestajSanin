using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NamestajSanin.Migrations
{
    /// <inheritdoc />
    public partial class InitalFullCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Kontakt",
                table: "Narudzbe",
                newName: "Telefon");

            migrationBuilder.RenameColumn(
                name: "DatumKreiranja",
                table: "Narudzbe",
                newName: "Datum");

            migrationBuilder.AddColumn<string>(
                name: "Boja",
                table: "Narudzbe",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Narudzbe",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "KontaktIme",
                table: "Narudzbe",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Narudzbe",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Faze",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TrajanjeMin = table.Column<int>(type: "int", nullable: false),
                    Redosled = table.Column<int>(type: "int", nullable: false),
                    NarudzbaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faze", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faze_Narudzbe_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Zaposleni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pozicija = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Smena = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposleni", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Zadaci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FazaId = table.Column<int>(type: "int", nullable: false),
                    ZaposleniId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zadaci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zadaci_Faze_FazaId",
                        column: x => x.FazaId,
                        principalTable: "Faze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zadaci_Zaposleni_ZaposleniId",
                        column: x => x.ZaposleniId,
                        principalTable: "Zaposleni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Faze_NarudzbaId",
                table: "Faze",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zadaci_FazaId",
                table: "Zadaci",
                column: "FazaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zadaci_ZaposleniId",
                table: "Zadaci",
                column: "ZaposleniId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zadaci");

            migrationBuilder.DropTable(
                name: "Faze");

            migrationBuilder.DropTable(
                name: "Zaposleni");

            migrationBuilder.DropColumn(
                name: "Boja",
                table: "Narudzbe");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Narudzbe");

            migrationBuilder.DropColumn(
                name: "KontaktIme",
                table: "Narudzbe");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Narudzbe");

            migrationBuilder.RenameColumn(
                name: "Telefon",
                table: "Narudzbe",
                newName: "Kontakt");

            migrationBuilder.RenameColumn(
                name: "Datum",
                table: "Narudzbe",
                newName: "DatumKreiranja");
        }
    }
}
