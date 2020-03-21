using Microsoft.EntityFrameworkCore.Migrations;

namespace SDClinic.Data.Migrations
{
    public partial class mig12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Insurance_Confirmation",
                table: "Consultations",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cost",
                table: "Consultations",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "BloodPressure",
                table: "Consultations",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Insurance_Confirmation",
                table: "Consultations",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cost",
                table: "Consultations",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "BloodPressure",
                table: "Consultations",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
