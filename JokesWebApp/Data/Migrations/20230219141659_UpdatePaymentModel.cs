using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesWebApp.Data.Migrations
{
    public partial class UpdatePaymentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPayment_UserBasicInfoes_UserId",
                table: "UserPayment");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserPayment",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPayment_UserBasicInfoes_UserId",
                table: "UserPayment",
                column: "UserId",
                principalTable: "UserBasicInfoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPayment_UserBasicInfoes_UserId",
                table: "UserPayment");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserPayment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UserPayment_UserBasicInfoes_UserId",
                table: "UserPayment",
                column: "UserId",
                principalTable: "UserBasicInfoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
