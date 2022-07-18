using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace waste_management_parser.Migrations
{
    public partial class Edit_WmObject_WasteBinForEmptying : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WmObjects_WasteBinForEmptying",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WmObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WmObjects_WasteBinForEmptying", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WmObjects_WasteBinForEmptying_WmObjects_WmObjectId",
                        column: x => x.WmObjectId,
                        principalTable: "WmObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WmObjects_WasteBinForEmptying_WmObjectId",
                table: "WmObjects_WasteBinForEmptying",
                column: "WmObjectId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WmObjects_WasteBinForEmptying");
        }
    }
}
