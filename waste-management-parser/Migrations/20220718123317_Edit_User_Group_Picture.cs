using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace waste_management_parser.Migrations
{
    public partial class Edit_User_Group_Picture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PictureData",
                table: "WmGroups",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureName",
                table: "WmGroups",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPasswordResetRequested",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "PictureData",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureData",
                table: "WmGroups");

            migrationBuilder.DropColumn(
                name: "PictureName",
                table: "WmGroups");

            migrationBuilder.DropColumn(
                name: "IsPasswordResetRequested",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PictureData",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PictureName",
                table: "AspNetUsers");
        }
    }
}
