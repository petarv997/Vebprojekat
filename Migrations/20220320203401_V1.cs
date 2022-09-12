using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekat.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supermarket",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grad = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supermarket", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Red",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategorija = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    supermarketID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Red", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Red_Supermarket_supermarketID",
                        column: x => x.supermarketID,
                        principalTable: "Supermarket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skladiste",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Velicina = table.Column<int>(type: "int", nullable: false),
                    supermarketID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skladiste", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Skladiste_Supermarket_supermarketID",
                        column: x => x.supermarketID,
                        principalTable: "Supermarket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    redID = table.Column<int>(type: "int", nullable: true),
                    skladisteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Proizvod_Red_redID",
                        column: x => x.redID,
                        principalTable: "Red",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proizvod_Skladiste_skladisteID",
                        column: x => x.skladisteID,
                        principalTable: "Skladiste",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_redID",
                table: "Proizvod",
                column: "redID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_skladisteID",
                table: "Proizvod",
                column: "skladisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Red_supermarketID",
                table: "Red",
                column: "supermarketID");

            migrationBuilder.CreateIndex(
                name: "IX_Skladiste_supermarketID",
                table: "Skladiste",
                column: "supermarketID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "Red");

            migrationBuilder.DropTable(
                name: "Skladiste");

            migrationBuilder.DropTable(
                name: "Supermarket");
        }
    }
}
