using Microsoft.EntityFrameworkCore.Migrations;

namespace SDClinic.Data.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Reminder_Patients",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Reminder_Insurances",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Reminder_Doctors",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Reminder_Assistants",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Reminder_Admins",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Reminder_Patients",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Reminder_Insurances",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Reminder_Doctors",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Reminder_Assistants",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Reminder_Admins",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 12,
                oldNullable: true);
        }
    }
}
