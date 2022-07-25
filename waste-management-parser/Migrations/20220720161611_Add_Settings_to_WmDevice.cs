using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace waste_management_parser.Migrations
{
    public partial class Add_Settings_to_WmDevice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Settings",
                table: "WmObjects",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Settings",
                table: "WmObjects");
        }
    }
}
