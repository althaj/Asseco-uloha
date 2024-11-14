using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabazaOsob.Model.Migrations
{
    /// <inheritdoc />
    public partial class InitialModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Narodnost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Hodnota = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narodnost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Hodnota = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypKontaktu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Hodnota = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypKontaktu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bydliste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ulice = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Mesto = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PSC = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    StatId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bydliste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bydliste_Stat_StatId",
                        column: x => x.StatId,
                        principalTable: "Stat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Osoba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Jmeno = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Prijmeni = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    RodnePrijmeni = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    RodneCislo = table.Column<string>(type: "TEXT", nullable: true),
                    DatumNarozeni = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NarodnostId = table.Column<int>(type: "INTEGER", nullable: false),
                    BydlisteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Osoba_Bydliste_BydlisteId",
                        column: x => x.BydlisteId,
                        principalTable: "Bydliste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Osoba_Narodnost_NarodnostId",
                        column: x => x.NarodnostId,
                        principalTable: "Narodnost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kontakt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypKontaktuId = table.Column<int>(type: "INTEGER", nullable: false),
                    Hodnota = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    OsobaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontakt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kontakt_Osoba_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osoba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kontakt_TypKontaktu_TypKontaktuId",
                        column: x => x.TypKontaktuId,
                        principalTable: "TypKontaktu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bydliste_StatId",
                table: "Bydliste",
                column: "StatId");

            migrationBuilder.CreateIndex(
                name: "IX_Kontakt_OsobaId",
                table: "Kontakt",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kontakt_TypKontaktuId",
                table: "Kontakt",
                column: "TypKontaktuId");

            migrationBuilder.CreateIndex(
                name: "IX_Osoba_BydlisteId",
                table: "Osoba",
                column: "BydlisteId");

            migrationBuilder.CreateIndex(
                name: "IX_Osoba_NarodnostId",
                table: "Osoba",
                column: "NarodnostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kontakt");

            migrationBuilder.DropTable(
                name: "Osoba");

            migrationBuilder.DropTable(
                name: "TypKontaktu");

            migrationBuilder.DropTable(
                name: "Bydliste");

            migrationBuilder.DropTable(
                name: "Narodnost");

            migrationBuilder.DropTable(
                name: "Stat");
        }
    }
}
