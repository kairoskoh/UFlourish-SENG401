using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesWebApp.Data.Migrations
{
    public partial class UpdatePaymentModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPayment",
                table: "UserPayment");

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "UserPayment",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserPayment",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPayment",
                table: "UserPayment",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPayment",
                table: "UserPayment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserPayment");

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "UserPayment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPayment",
                table: "UserPayment",
                column: "CardNumber");
        }
    }
}
