using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyWebDbApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Occupancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WorkspaceId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occupancies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Occupancies_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
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
                    { "1611d45f-610e-4097-9ce1-fd95f5b073d6", null, "Office", "OFFICE" },
                    { "b2e8331a-d9a7-44ec-b087-c8a566069173", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "30a7141c-384b-4714-9d27-49ee3360694f", 0, "75c3f0da-697d-46af-9058-f841528b8266", null, false, false, null, null, "ADMIN@ABC.COM", "AQAAAAIAAYagAAAAEKnL1zHma4apRVSeSfZA8KbGv90+OGq4KJI/YUC70bOlK74+EeSL9HEQ/EHUXoMxEQ==", null, false, "4b5a5186-9298-4258-8006-f91699ac0730", false, "admin@abc.com" },
                    { "9674a3d3-4a71-4f83-a9a5-825d9c8e10d0", 0, "4ede312a-76a9-41ef-a07b-7afeabc2a1a5", null, false, false, null, null, "OFFICE2@ABC.COM", "AQAAAAIAAYagAAAAEAv9K+fq/BYPyA8SrFW7/D250FHbPPg4FVu4C24kQyitJU5IP9RtTuokYwx2tr2Tpg==", null, false, "5442d1c6-153c-4129-a51a-ef0ea7ed6402", false, "office2@abc.com" },
                    { "ddb4a216-a555-4ed1-971d-982ab176ef38", 0, "048586fd-87a2-4c0c-8517-f9e1ccca3c6e", null, false, false, null, null, "OFFICE1@ABC.COM", "AQAAAAIAAYagAAAAEKSYqgDJYDgFSc7aGv1TUO3nZDySsAjR6cQLQqQmkn+qbZGvUQQIyTnNYtl1/VUz7Q==", null, false, "c28c6847-bd98-4784-9c7b-7a875a95bea2", false, "office1@abc.com" }
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
                    { 10, "Room 10", 3 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b2e8331a-d9a7-44ec-b087-c8a566069173", "30a7141c-384b-4714-9d27-49ee3360694f" },
                    { "1611d45f-610e-4097-9ce1-fd95f5b073d6", "9674a3d3-4a71-4f83-a9a5-825d9c8e10d0" },
                    { "1611d45f-610e-4097-9ce1-fd95f5b073d6", "ddb4a216-a555-4ed1-971d-982ab176ef38" }
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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ChiefId",
                table: "Departments",
                column: "ChiefId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

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
        }

        /// <inheritdoc />
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
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Occupancies");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Workspaces");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
