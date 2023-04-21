using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace april2020.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoKlubovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoKlubovi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Police",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    oznaka = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    maxBrDVDs = table.Column<int>(type: "int", nullable: false),
                    trenutnoDVDs = table.Column<int>(type: "int", nullable: false),
                    mojiVKID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Police", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Police_VideoKlubovi_mojiVKID",
                        column: x => x.mojiVKID,
                        principalTable: "VideoKlubovi",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Police_mojiVKID",
                table: "Police",
                column: "mojiVKID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Police");

            migrationBuilder.DropTable(
                name: "VideoKlubovi");
        }
    }
}
