using Microsoft.EntityFrameworkCore.Migrations;

namespace SDClinic.Data.Migrations
{
    public partial class mig16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Insurance_Companies",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Doctors",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Assistants",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Admins",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_Companies_username",
                table: "Insurance_Companies",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_username",
                table: "Doctors",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "IX_Assistants_username",
                table: "Assistants",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_username",
                table: "Admins",
                column: "username");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AspNetUsers_username",
                table: "Admins",
                column: "username",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assistants_AspNetUsers_username",
                table: "Assistants",
                column: "username",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_username",
                table: "Doctors",
                column: "username",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Insurance_Companies_AspNetUsers_username",
                table: "Insurance_Companies",
                column: "username",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_AspNetUsers_username",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Assistants_AspNetUsers_username",
                table: "Assistants");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_username",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Insurance_Companies_AspNetUsers_username",
                table: "Insurance_Companies");

            migrationBuilder.DropIndex(
                name: "IX_Insurance_Companies_username",
                table: "Insurance_Companies");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_username",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Assistants_username",
                table: "Assistants");

            migrationBuilder.DropIndex(
                name: "IX_Admins_username",
                table: "Admins");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Insurance_Companies",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Doctors",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Assistants",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Admins",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
