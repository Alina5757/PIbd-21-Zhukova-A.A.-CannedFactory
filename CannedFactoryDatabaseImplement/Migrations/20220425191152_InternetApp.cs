using Microsoft.EntityFrameworkCore.Migrations;

namespace CannedFactoryDatabaseImplement.Migrations
{
    public partial class InternetApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Clients",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Clients",
                newName: "Email");
        }
    }
}
