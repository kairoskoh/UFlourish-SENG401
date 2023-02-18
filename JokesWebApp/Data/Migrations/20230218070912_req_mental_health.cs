using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesWebApp.Data.Migrations
{
    public partial class req_mental_health : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MentalHealth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentalHealth", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Request_Mental_Health",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request_Mental_Health", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MentalHealth");

            migrationBuilder.DropTable(
                name: "Request_Mental_Health");
        }
    }
}
