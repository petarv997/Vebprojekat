using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekat.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Red_redID",
                table: "Proizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Skladiste_skladisteID",
                table: "Proizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_Red_Supermarket_supermarketID",
                table: "Red");

            migrationBuilder.DropForeignKey(
                name: "FK_Skladiste_Supermarket_supermarketID",
                table: "Skladiste");

            migrationBuilder.DropIndex(
                name: "IX_Proizvod_skladisteID",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "skladisteID",
                table: "Proizvod");

            migrationBuilder.RenameColumn(
                name: "supermarketID",
                table: "Skladiste",
                newName: "SupermarketID");

            migrationBuilder.RenameIndex(
                name: "IX_Skladiste_supermarketID",
                table: "Skladiste",
                newName: "IX_Skladiste_SupermarketID");

            migrationBuilder.RenameColumn(
                name: "supermarketID",
                table: "Red",
                newName: "SupermarketID");

            migrationBuilder.RenameIndex(
                name: "IX_Red_supermarketID",
                table: "Red",
                newName: "IX_Red_SupermarketID");

            migrationBuilder.RenameColumn(
                name: "redID",
                table: "Proizvod",
                newName: "RedID");

            migrationBuilder.RenameIndex(
                name: "IX_Proizvod_redID",
                table: "Proizvod",
                newName: "IX_Proizvod_RedID");

            migrationBuilder.AddColumn<int>(
                name: "Broj",
                table: "Skladiste",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Broj",
                table: "Red",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SProizvod",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    SkladisteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SProizvod", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SProizvod_Skladiste_SkladisteID",
                        column: x => x.SkladisteID,
                        principalTable: "Skladiste",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SProizvod_SkladisteID",
                table: "SProizvod",
                column: "SkladisteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_Red_RedID",
                table: "Proizvod",
                column: "RedID",
                principalTable: "Red",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Red_Supermarket_SupermarketID",
                table: "Red",
                column: "SupermarketID",
                principalTable: "Supermarket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skladiste_Supermarket_SupermarketID",
                table: "Skladiste",
                column: "SupermarketID",
                principalTable: "Supermarket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Red_RedID",
                table: "Proizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_Red_Supermarket_SupermarketID",
                table: "Red");

            migrationBuilder.DropForeignKey(
                name: "FK_Skladiste_Supermarket_SupermarketID",
                table: "Skladiste");

            migrationBuilder.DropTable(
                name: "SProizvod");

            migrationBuilder.DropColumn(
                name: "Broj",
                table: "Skladiste");

            migrationBuilder.DropColumn(
                name: "Broj",
                table: "Red");

            migrationBuilder.RenameColumn(
                name: "SupermarketID",
                table: "Skladiste",
                newName: "supermarketID");

            migrationBuilder.RenameIndex(
                name: "IX_Skladiste_SupermarketID",
                table: "Skladiste",
                newName: "IX_Skladiste_supermarketID");

            migrationBuilder.RenameColumn(
                name: "SupermarketID",
                table: "Red",
                newName: "supermarketID");

            migrationBuilder.RenameIndex(
                name: "IX_Red_SupermarketID",
                table: "Red",
                newName: "IX_Red_supermarketID");

            migrationBuilder.RenameColumn(
                name: "RedID",
                table: "Proizvod",
                newName: "redID");

            migrationBuilder.RenameIndex(
                name: "IX_Proizvod_RedID",
                table: "Proizvod",
                newName: "IX_Proizvod_redID");

            migrationBuilder.AddColumn<int>(
                name: "skladisteID",
                table: "Proizvod",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_skladisteID",
                table: "Proizvod",
                column: "skladisteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_Red_redID",
                table: "Proizvod",
                column: "redID",
                principalTable: "Red",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_Skladiste_skladisteID",
                table: "Proizvod",
                column: "skladisteID",
                principalTable: "Skladiste",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Red_Supermarket_supermarketID",
                table: "Red",
                column: "supermarketID",
                principalTable: "Supermarket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skladiste_Supermarket_supermarketID",
                table: "Skladiste",
                column: "supermarketID",
                principalTable: "Supermarket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
