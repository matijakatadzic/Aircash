using Microsoft.EntityFrameworkCore.Migrations;

namespace Aircash.Repository.Migrations
{
    public partial class AdressUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressLine",
                schema: "dbo",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine",
                schema: "dbo",
                table: "Address");
        }
    }
}
