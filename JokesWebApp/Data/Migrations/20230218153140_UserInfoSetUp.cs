using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesWebApp.Data.Migrations
{
    public partial class UserInfoSetUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInsurance_MyProperty_UserId",
                table: "UserInsurance");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPayment_MyProperty_UserId",
                table: "UserPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "UserBasicInfoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBasicInfoes",
                table: "UserBasicInfoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInsurance_UserBasicInfoes_UserId",
                table: "UserInsurance",
                column: "UserId",
                principalTable: "UserBasicInfoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPayment_UserBasicInfoes_UserId",
                table: "UserPayment",
                column: "UserId",
                principalTable: "UserBasicInfoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInsurance_UserBasicInfoes_UserId",
                table: "UserInsurance");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPayment_UserBasicInfoes_UserId",
                table: "UserPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBasicInfoes",
                table: "UserBasicInfoes");

            migrationBuilder.RenameTable(
                name: "UserBasicInfoes",
                newName: "MyProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInsurance_MyProperty_UserId",
                table: "UserInsurance",
                column: "UserId",
                principalTable: "MyProperty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPayment_MyProperty_UserId",
                table: "UserPayment",
                column: "UserId",
                principalTable: "MyProperty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
