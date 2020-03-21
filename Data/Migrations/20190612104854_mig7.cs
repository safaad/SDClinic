using Microsoft.EntityFrameworkCore.Migrations;

namespace SDClinic.Data.Migrations
{
    public partial class mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Reports");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Reports",
                maxLength: 50,
                nullable: true);
        }
    }
}
