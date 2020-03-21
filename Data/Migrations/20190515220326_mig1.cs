using Microsoft.EntityFrameworkCore.Migrations;

namespace SDClinic.Data.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Assistants");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Assistants");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Assistants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Assistants",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Assistants",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Assistants",
                maxLength: 15,
                nullable: true);
        }
    }
}
