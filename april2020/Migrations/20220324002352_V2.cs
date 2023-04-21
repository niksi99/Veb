using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace april2020.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "trenutnoDVDs",
                table: "Police",
                newName: "TrenutnoDVDs");

            migrationBuilder.RenameColumn(
                name: "oznaka",
                table: "Police",
                newName: "Oznaka");

            migrationBuilder.RenameColumn(
                name: "maxBrDVDs",
                table: "Police",
                newName: "MaxBrDVDs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrenutnoDVDs",
                table: "Police",
                newName: "trenutnoDVDs");

            migrationBuilder.RenameColumn(
                name: "Oznaka",
                table: "Police",
                newName: "oznaka");

            migrationBuilder.RenameColumn(
                name: "MaxBrDVDs",
                table: "Police",
                newName: "maxBrDVDs");
        }
    }
}
