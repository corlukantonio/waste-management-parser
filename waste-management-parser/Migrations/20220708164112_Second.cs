using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace waste_management_parser.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "WmObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WmObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WmRecords_TriggerWasteBinEmptying",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WmRecords_TriggerWasteBinEmptying", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WmRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WmObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WmRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WmRecords_WmObjects_WmObjectId",
                        column: x => x.WmObjectId,
                        principalTable: "WmObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WmRecords_TriggerWasteBinEmptying_WmObjects",
                columns: table => new
                {
                    WmRecord_TriggerWasteBinEmptyingId = table.Column<int>(type: "int", nullable: false),
                    WmObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WmRecords_TriggerWasteBinEmptying_WmObjects", x => new { x.WmRecord_TriggerWasteBinEmptyingId, x.WmObjectId });
                    table.ForeignKey(
                        name: "FK_WmRecords_TriggerWasteBinEmptying_WmObjects_WmObjects_WmObjectId",
                        column: x => x.WmObjectId,
                        principalTable: "WmObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WmRecords_TriggerWasteBinEmptying_WmObjects_WmRecords_TriggerWasteBinEmptying_WmRecord_TriggerWasteBinEmptyingId",
                        column: x => x.WmRecord_TriggerWasteBinEmptyingId,
                        principalTable: "WmRecords_TriggerWasteBinEmptying",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WmRecords_WmObjectId",
                table: "WmRecords",
                column: "WmObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WmRecords_TriggerWasteBinEmptying_WmObjects_WmObjectId",
                table: "WmRecords_TriggerWasteBinEmptying_WmObjects",
                column: "WmObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WmRecords");

            migrationBuilder.DropTable(
                name: "WmRecords_TriggerWasteBinEmptying_WmObjects");

            migrationBuilder.DropTable(
                name: "WmObjects");

            migrationBuilder.DropTable(
                name: "WmRecords_TriggerWasteBinEmptying");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
