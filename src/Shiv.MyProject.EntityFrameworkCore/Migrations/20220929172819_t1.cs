using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shiv.MyProject.Migrations
{
    public partial class t1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "countries",
            columns: table => new
            {
                id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Country = table.Column<string>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_countries", x => x.id);
            });

            migrationBuilder.CreateTable(
           name: "states",
           columns: table => new
           {
               id = table.Column<int>(nullable: false)
                   .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
               State = table.Column<string>(nullable: true),
               cid = table.Column<int>(nullable: false)
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_states", x => x.id);
               table.ForeignKey("FK_countries", x => x.cid, "countries", "id", null);
           });
        }



        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
