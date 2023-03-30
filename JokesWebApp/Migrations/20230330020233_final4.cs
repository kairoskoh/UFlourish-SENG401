using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesWebApp.Migrations
{
    public partial class final4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "RefillPrescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    MedicineName = table.Column<string>(nullable: true),
                    RequestRefillDate = table.Column<DateTime>(nullable: false),
                    RefillDate = table.Column<string>(nullable: true),
                    PrescriptionReadyToPickup = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefillPrescriptions", x => x.Id);
                });

                
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Joke");

            migrationBuilder.DropTable(
                name: "RefillPrescriptions");

            migrationBuilder.DropTable(
                name: "Request_Mental_Health");

            migrationBuilder.DropTable(
                name: "UserFinancialActivity");

            migrationBuilder.DropTable(
                name: "UserInsurance");

            migrationBuilder.DropTable(
                name: "UserPayment");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserBasicInfoes");
        }
    }
}
