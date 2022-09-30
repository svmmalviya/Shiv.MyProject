using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shiv.MyProject.Migrations
{
    public partial class t4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "states");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.CreateTable(
                name: "Mycountries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mycountries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Mystates",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Countriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mystates", x => x.id);
                    table.ForeignKey(
                        name: "FK_Mystates_Mycountries_Countriesid",
                        column: x => x.Countriesid,
                        principalTable: "Mycountries",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mystates_Countriesid",
                table: "Mystates",
                column: "Countriesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mystates");

            migrationBuilder.DropTable(
                name: "Mycountries");

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Countryid = table.Column<int>(type: "int", nullable: true),
                    cid = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.id);
                    table.ForeignKey(
                        name: "FK_states_countries_Countryid",
                        column: x => x.Countryid,
                        principalTable: "countries",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_states_Countryid",
                table: "states",
                column: "Countryid");
        }
    }
}
