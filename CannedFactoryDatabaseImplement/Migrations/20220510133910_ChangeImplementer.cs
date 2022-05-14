using Microsoft.EntityFrameworkCore.Migrations;

namespace CannedFactoryDatabaseImplement.Migrations
{
    public partial class ChangeImplementer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeRest",
                table: "Implementers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeWork",
                table: "Implementers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeRest",
                table: "Implementers");

            migrationBuilder.DropColumn(
                name: "TimeWork",
                table: "Implementers");
        }
    }
}
