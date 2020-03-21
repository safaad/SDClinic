using Microsoft.EntityFrameworkCore.Migrations;

namespace SDClinic.Data.Migrations
{
    public partial class mig10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Admins",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "username",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "username",
                table: "Admins");
        }
    }
}
