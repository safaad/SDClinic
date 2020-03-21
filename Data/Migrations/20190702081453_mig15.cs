using Microsoft.EntityFrameworkCore.Migrations;

namespace SDClinic.Data.Migrations
{
    public partial class mig15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_userId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_userId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_username",
                table: "Patients",
                column: "username");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_username",
                table: "Patients",
                column: "username",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_username",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_username",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Patients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_userId",
                table: "Patients",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_userId",
                table: "Patients",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
