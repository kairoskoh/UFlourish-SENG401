using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesWebApp.Data.Migrations
{
    public partial class SpecifyForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInsurance_UserBasicInfoes_UserId",
                table: "UserInsurance");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserInsurance",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInsurance_UserBasicInfoes_UserId",
                table: "UserInsurance",
                column: "UserId",
                principalTable: "UserBasicInfoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInsurance_UserBasicInfoes_UserId",
                table: "UserInsurance");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserInsurance",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UserInsurance_UserBasicInfoes_UserId",
                table: "UserInsurance",
                column: "UserId",
                principalTable: "UserBasicInfoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
