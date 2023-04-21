using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jan2021.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mesec",
                table: "Gradovi");

            migrationBuilder.AddColumn<int>(
                name: "Mesec",
                table: "Podaci",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mesec",
                table: "Podaci");

            migrationBuilder.AddColumn<int>(
                name: "Mesec",
                table: "Gradovi",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
