using Microsoft.EntityFrameworkCore.Migrations;

namespace SDClinic.Data.Migrations
{
    public partial class mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Consultations",
                newName: "DateCons");

            migrationBuilder.AlterColumn<string>(
                name: "Temp",
                table: "Consultations",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BloodPressure",
                table: "Consultations",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateCons",
                table: "Consultations",
                newName: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "Temp",
                table: "Consultations",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BloodPressure",
                table: "Consultations",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
