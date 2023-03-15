using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesWebApp.Data.Migrations
{
    public partial class setupuserfinancialactivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFinancialActivity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    TransactionName = table.Column<string>(nullable: true),
                    TransactionType = table.Column<string>(nullable: true),
                    PostedDate = table.Column<string>(nullable: true),
                    Term = table.Column<string>(nullable: true),
                    Charge = table.Column<double>(nullable: false),
                    Payment = table.Column<double>(nullable: false),
                    Refund = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFinancialActivity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFinancialActivity");
        }
    }
}
