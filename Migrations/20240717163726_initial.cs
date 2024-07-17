using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyWebDbApp.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Workspaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workspaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workspaces_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    WorkspaceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Workspaces_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ChiefId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_ChiefId",
                        column: x => x.ChiefId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Occupancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployeeId = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WorkspaceId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occupancies_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Occupancies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Occupancies_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Occupancies_Workspaces_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspaces",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "239074ba-0164-4b80-8526-17e1d56b892f", null, "Worker", "WORKER" },
                    { "49b478bd-9ee6-42f1-8cbb-0923cba9ac42", null, "Office", "OFFICE" },
                    { "80f41492-3d55-4744-8f7b-61d5c940a9db", null, "Chief", "CHIEF" },
                    { "eb227aa5-658f-4d1b-bcea-d5338d68f9c9", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "29f445e3-c72e-4cd1-950d-961c495095a3", 0, "9f7d29a1-7b1f-45f2-b379-8698bbd72022", null, null, false, false, null, null, "CHIEF@ABC.COM", "AQAAAAIAAYagAAAAEDEQdpwpUK+zwo7EIZfWCB9ZXtGdO1fVenBukkttMT6EVrWBgGZx8wkhxZUXnV/nAA==", null, false, "7d87362f-6c95-41d9-a539-05e9e47ccb6e", false, "chief@abc.com" },
                    { "77fc46c1-383d-44ee-8a31-c85acf20c811", 0, "3f55fd4e-49ef-4f23-baed-2a77e937c426", null, null, false, false, null, null, "ADMIN@ABC.COM", "AQAAAAIAAYagAAAAEOdp0X5ua0wJxECYQqtOD/m75tcItsNW4YuHnKiewhZvdVfibnRouVIFpl63BkavWw==", null, false, "fb20e840-c639-415f-a389-57824416c590", false, "admin@abc.com" },
                    { "af086b82-923f-450d-b20b-7bb21b164f34", 0, "23bf58b9-9150-4b43-acd7-d1e0076b3e09", null, null, false, false, null, null, "OFFICE2@ABC.COM", "AQAAAAIAAYagAAAAEPJo/Wsd6ww2c4OCl0gf8h4lyKlgHleEQT6yn6RoktYDIMyohuFKvpu5JDICODTAWw==", null, false, "68561ea9-96b6-4e57-813d-b9066d7f2acd", false, "office2@abc.com" },
                    { "d28e32a2-e920-4667-829e-c3af3b5c2669", 0, "dfebbde6-96e1-44b1-99e6-c33d9bc07b5a", null, null, false, false, null, null, "OFFICE1@ABC.COM", "AQAAAAIAAYagAAAAEF8eus+P25LMHy+9UW3YIujHQViBHs0M/sBPt+VJdQJ6bmXWBmz8zgU6AP0AiLLFWQ==", null, false, "9fb64a2c-3bf8-4d5f-a010-8746d4df16b7", false, "office1@abc.com" },
                    { "d6f5a6eb-c19a-472e-88e6-7c68d2d6eb72", 0, "3c3ba316-6e42-47bc-bf1b-748a55b5e029", null, null, false, false, null, null, "WORKER@ABC.COM", "AQAAAAIAAYagAAAAEN9byP4OeOOCfFJG8vigKUquCYynqQWLKBvxeQSWC4wpx6J8gWBBH3Sl8oZU9js/yw==", null, false, "74767078-3196-4593-a891-8c112ef17d92", false, "worker@abc.com" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Room 1", 0 },
                    { 2, "Room 2", 5 },
                    { 3, "Room 3", 2 },
                    { 4, "Room 4", 3 },
                    { 5, "Room 5", 4 },
                    { 6, "Room 6", 1 },
                    { 7, "Room 7", 0 },
                    { 8, "Room 8", 5 },
                    { 9, "Room 9", 2 },
                    { 10, "Room 10", 3 },
                    { 11, "Homeoffice", 6 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "80f41492-3d55-4744-8f7b-61d5c940a9db", "29f445e3-c72e-4cd1-950d-961c495095a3" },
                    { "eb227aa5-658f-4d1b-bcea-d5338d68f9c9", "77fc46c1-383d-44ee-8a31-c85acf20c811" },
                    { "49b478bd-9ee6-42f1-8cbb-0923cba9ac42", "af086b82-923f-450d-b20b-7bb21b164f34" },
                    { "49b478bd-9ee6-42f1-8cbb-0923cba9ac42", "d28e32a2-e920-4667-829e-c3af3b5c2669" },
                    { "239074ba-0164-4b80-8526-17e1d56b892f", "d6f5a6eb-c19a-472e-88e6-7c68d2d6eb72" }
                });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[,]
                {
                    { 1, "Workspace 1", 2 },
                    { 2, "Workspace 2", 3 },
                    { 3, "Workspace 3", 4 },
                    { 4, "Workspace 4", 5 },
                    { 5, "Workspace 5", 6 },
                    { 6, "Workspace 6", 7 },
                    { 7, "Workspace 7", 8 },
                    { 8, "Workspace 8", 9 },
                    { 9, "Workspace 9", 10 },
                    { 10, "Workspace 10", 1 },
                    { 11, "Workspace 11", 2 },
                    { 12, "Workspace 12", 3 },
                    { 13, "Workspace 13", 4 },
                    { 14, "Workspace 14", 5 },
                    { 15, "Workspace 15", 6 },
                    { 16, "Workspace 16", 7 },
                    { 17, "Workspace 17", 8 },
                    { 18, "Workspace 18", 9 },
                    { 19, "Workspace 19", 10 },
                    { 20, "Workspace 20", 1 },
                    { 21, "Workspace 21", 2 },
                    { 22, "Workspace 22", 3 },
                    { 23, "Workspace 23", 4 },
                    { 24, "Workspace 24", 5 },
                    { 25, "Workspace 25", 6 },
                    { 26, "Workspace 26", 7 },
                    { 27, "Workspace 27", 8 },
                    { 28, "Workspace 28", 9 },
                    { 29, "Workspace 29", 10 },
                    { 30, "Workspace 30", 1 }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[,]
                {
                    { 1, "Desk", 1 },
                    { 2, "Desk", 2 },
                    { 3, "Desk", 3 },
                    { 4, "Desk", 4 },
                    { 5, "Desk", 5 },
                    { 6, "Desk", 6 },
                    { 7, "Desk", 7 },
                    { 8, "Desk", 8 },
                    { 9, "Desk", 9 },
                    { 10, "Desk", 10 },
                    { 11, "Desk", 11 },
                    { 12, "Desk", 12 },
                    { 13, "Desk", 13 },
                    { 14, "Desk", 14 },
                    { 15, "Desk", 15 },
                    { 16, "Desk", 16 },
                    { 17, "Desk", 17 },
                    { 18, "Desk", 18 },
                    { 19, "Desk", 19 },
                    { 20, "Desk", 20 },
                    { 21, "Desk", 21 },
                    { 22, "Desk", 22 },
                    { 23, "Desk", 23 },
                    { 24, "Desk", 24 },
                    { 25, "Desk", 25 },
                    { 26, "Desk", 26 },
                    { 27, "Desk", 27 },
                    { 28, "Desk", 28 },
                    { 29, "Desk", 29 },
                    { 30, "Desk", 30 },
                    { 31, "Chair", 1 },
                    { 32, "Chair", 2 },
                    { 33, "Chair", 3 },
                    { 34, "Chair", 4 },
                    { 35, "Chair", 5 },
                    { 36, "Chair", 6 },
                    { 37, "Chair", 7 },
                    { 38, "Chair", 8 },
                    { 39, "Chair", 9 },
                    { 40, "Chair", 10 },
                    { 41, "Chair", 11 },
                    { 42, "Chair", 12 },
                    { 43, "Chair", 13 },
                    { 44, "Chair", 14 },
                    { 45, "Chair", 15 },
                    { 46, "Chair", 16 },
                    { 47, "Chair", 17 },
                    { 48, "Chair", 18 },
                    { 49, "Chair", 19 },
                    { 50, "Chair", 20 },
                    { 51, "Chair", 21 },
                    { 52, "Chair", 22 },
                    { 53, "Chair", 23 },
                    { 54, "Chair", 24 },
                    { 55, "Chair", 25 },
                    { 56, "Chair", 26 },
                    { 57, "Chair", 27 },
                    { 58, "Chair", 28 },
                    { 59, "Chair", 29 },
                    { 60, "Chair", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ChiefId",
                table: "Departments",
                column: "ChiefId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_WorkspaceId",
                table: "Equipment",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Occupancies_EmployeeId",
                table: "Occupancies",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Occupancies_RoomId",
                table: "Occupancies",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Occupancies_UserId",
                table: "Occupancies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Occupancies_WorkspaceId",
                table: "Occupancies",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Workspaces_RoomId",
                table: "Workspaces",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_ChiefId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Occupancies");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Workspaces");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
