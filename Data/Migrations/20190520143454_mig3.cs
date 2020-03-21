using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SDClinic.Data.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Reminder_Patients");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Reminder_Insurances");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Reminder_Doctors");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Reminder_Assistants");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Reminder_Admins");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Reminder_Patients",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Reminder_Insurances",
                newName: "DateTimw");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Reminder_Doctors",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Reminder_Assistants",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Reminder_Admins",
                newName: "DateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Reminder_Patients",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "DateTimw",
                table: "Reminder_Insurances",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Reminder_Doctors",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Reminder_Assistants",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Reminder_Admins",
                newName: "Date");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Reminder_Patients",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Reminder_Insurances",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Reminder_Doctors",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Reminder_Assistants",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Reminder_Admins",
                nullable: true);
        }
    }
}
