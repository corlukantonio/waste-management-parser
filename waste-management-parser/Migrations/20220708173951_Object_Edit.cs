using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace waste_management_parser.Migrations
{
    public partial class Object_Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Mac",
                table: "WmObjects",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mac",
                table: "WmObjects");
        }
    }
}
