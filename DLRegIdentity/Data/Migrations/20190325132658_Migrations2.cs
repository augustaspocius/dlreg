using Microsoft.EntityFrameworkCore.Migrations;

namespace DLRegIdentity.Data.Migrations
{
    public partial class Migrations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WORKPLACE",
                table: "workers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WORKPLACE",
                table: "workers");
        }
    }
}
