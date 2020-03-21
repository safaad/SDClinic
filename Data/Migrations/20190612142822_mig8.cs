using Microsoft.EntityFrameworkCore.Migrations;

namespace SDClinic.Data.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_Insurances_Insurance_Companies_Insurance_CompanyId1_Insurance_CompanyName",
                table: "Reminder_Insurances");

            migrationBuilder.DropIndex(
                name: "IX_Reminder_Insurances_Insurance_CompanyId1_Insurance_CompanyName",
                table: "Reminder_Insurances");

            migrationBuilder.DropColumn(
                name: "Insurance_CompanyId1",
                table: "Reminder_Insurances");

            migrationBuilder.AlterColumn<string>(
                name: "Insurance_CompanyName",
                table: "Reminder_Insurances",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Insurance_CompanyId",
                table: "Reminder_Insurances",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Insurance_CompanyName1",
                table: "Reminder_Insurances",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_Insurances_Insurance_CompanyId_Insurance_CompanyName1",
                table: "Reminder_Insurances",
                columns: new[] { "Insurance_CompanyId", "Insurance_CompanyName1" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_Insurances_Insurance_Companies_Insurance_CompanyId_Insurance_CompanyName1",
                table: "Reminder_Insurances",
                columns: new[] { "Insurance_CompanyId", "Insurance_CompanyName1" },
                principalTable: "Insurance_Companies",
                principalColumns: new[] { "Id", "Name" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_Insurances_Insurance_Companies_Insurance_CompanyId_Insurance_CompanyName1",
                table: "Reminder_Insurances");

            migrationBuilder.DropIndex(
                name: "IX_Reminder_Insurances_Insurance_CompanyId_Insurance_CompanyName1",
                table: "Reminder_Insurances");

            migrationBuilder.DropColumn(
                name: "Insurance_CompanyName1",
                table: "Reminder_Insurances");

            migrationBuilder.AlterColumn<string>(
                name: "Insurance_CompanyName",
                table: "Reminder_Insurances",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Insurance_CompanyId",
                table: "Reminder_Insurances",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Insurance_CompanyId1",
                table: "Reminder_Insurances",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_Insurances_Insurance_CompanyId1_Insurance_CompanyName",
                table: "Reminder_Insurances",
                columns: new[] { "Insurance_CompanyId1", "Insurance_CompanyName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_Insurances_Insurance_Companies_Insurance_CompanyId1_Insurance_CompanyName",
                table: "Reminder_Insurances",
                columns: new[] { "Insurance_CompanyId1", "Insurance_CompanyName" },
                principalTable: "Insurance_Companies",
                principalColumns: new[] { "Id", "Name" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
