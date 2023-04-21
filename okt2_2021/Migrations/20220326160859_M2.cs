using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace okt2_2021.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Prodavnice");

            migrationBuilder.AddColumn<int>(
                name: "Cena",
                table: "Proizvodi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Kolicina",
                table: "Proizvodi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tip",
                table: "Proizvodi",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Proizvodi");

            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "Proizvodi");

            migrationBuilder.DropColumn(
                name: "Tip",
                table: "Proizvodi");

            migrationBuilder.AddColumn<int>(
                name: "Cena",
                table: "Prodavnice",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
