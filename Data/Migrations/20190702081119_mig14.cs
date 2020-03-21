using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SDClinic.Data.Migrations
{
    public partial class mig14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Patients",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_dateTime",
                table: "Dates",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_dateTime",
                table: "Dates",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
