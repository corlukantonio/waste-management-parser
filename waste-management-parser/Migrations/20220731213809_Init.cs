using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace waste_management_parser.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PictureData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsPasswordResetRequested = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WmOrganizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<byte[]>(type: "binary(36)", fixedLength: true, maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WmOrganizations", x => x.Id);
                    table.UniqueConstraint("UXC_WmOrganizations_Guid", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "WmRecords_TriggerWasteBinEmptying",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WmRecords_TriggerWasteBinEmptying", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers_WmOrganizations",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WmOrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers_WmOrganizations", x => new { x.UserId, x.WmOrganizationId });
                    table.ForeignKey(
                        name: "FK_AspNetUsers_WmOrganizations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_WmOrganizations_WmOrganizations_WmOrganizationId",
                        column: x => x.WmOrganizationId,
                        principalTable: "WmOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WmGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<byte[]>(type: "binary(36)", fixedLength: true, maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PictureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PictureData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Settings = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WmOrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WmGroups", x => x.Id);
                    table.UniqueConstraint("UXC_WmGroups_Guid", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_WmGroups_WmOrganizations_WmOrganizationId",
                        column: x => x.WmOrganizationId,
                        principalTable: "WmOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WmObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<byte[]>(type: "binary(36)", fixedLength: true, maxLength: 36, nullable: false),
                    Mac = table.Column<byte[]>(type: "binary(6)", fixedLength: true, maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Longitude = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ActivationCode = table.Column<byte[]>(type: "binary(4)", fixedLength: true, maxLength: 4, nullable: true),
                    Settings = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WmGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WmObjects", x => x.Id);
                    table.UniqueConstraint("UXC_WmObjects_Guid", x => x.Guid);
                    table.UniqueConstraint("UXC_WmObjects_Mac", x => x.Mac);
                    table.ForeignKey(
                        name: "FK_WmObjects_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WmObjects_WmGroups_WmGroupId",
                        column: x => x.WmGroupId,
                        principalTable: "WmGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "WmRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WmOrganizations_WmOrganizationId",
                table: "AspNetUsers_WmOrganizations",
                column: "WmOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_WmGroups_WmOrganizationId",
                table: "WmGroups",
                column: "WmOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_WmObjects_OwnerId",
                table: "WmObjects",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_WmObjects_WmGroupId",
                table: "WmObjects",
                column: "WmGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WmObjects_WasteBinForEmptying_WmObjectId",
                table: "WmObjects_WasteBinForEmptying",
                column: "WmObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WmRecords_WmObjectId",
                table: "WmRecords",
                column: "WmObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WmRecords_TriggerWasteBinEmptying_WmObjects_WmObjectId",
                table: "WmRecords_TriggerWasteBinEmptying_WmObjects",
                column: "WmObjectId");

            migrationBuilder.Sql(
                "CREATE TRIGGER WmGroups_For_Update_UpdatedAt " +
                "ON WmGroups " +
                "FOR UPDATE " +
                "AS BEGIN " +
                "UPDATE WmGroups SET UpdatedAt = GETDATE() " +
                "FROM INSERTED " +
                "WHERE INSERTED.Id = WmGroups.Id " +
                "END");

            migrationBuilder.Sql(
                "CREATE TRIGGER WmObjects_For_Update_UpdatedAt " +
                "ON WmObjects " +
                "FOR UPDATE " +
                "AS BEGIN " +
                "UPDATE WmObjects SET UpdatedAt = GETDATE() " +
                "FROM INSERTED " +
                "WHERE INSERTED.Id = WmObjects.Id " +
                "END");

            migrationBuilder.Sql(
                "CREATE TRIGGER WmOrganizations_For_Update_UpdatedAt " +
                "ON WmOrganizations " +
                "FOR UPDATE " +
                "AS BEGIN " +
                "UPDATE WmOrganizations SET UpdatedAt = GETDATE() " +
                "FROM INSERTED " +
                "WHERE INSERTED.Id = WmOrganizations.Id " +
                "END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers_WmOrganizations");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "WmObjects_WasteBinForEmptying");

            migrationBuilder.DropTable(
                name: "WmRecords");

            migrationBuilder.DropTable(
                name: "WmRecords_TriggerWasteBinEmptying_WmObjects");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "WmObjects");

            migrationBuilder.DropTable(
                name: "WmRecords_TriggerWasteBinEmptying");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WmGroups");

            migrationBuilder.DropTable(
                name: "WmOrganizations");

            migrationBuilder.Sql(
                "DROP TRIGGER WmGroups_For_Update_UpdatedAt;");

            migrationBuilder.Sql(
                "DROP TRIGGER WmObjects_For_Update_UpdatedAt;");

            migrationBuilder.Sql(
                "DROP TRIGGER WmOrganizations_For_Update_UpdatedAt;");
        }
    }
}
