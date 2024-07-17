using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyWebDbApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    { "54549a05-4a44-4e26-b35a-c721f6449ce7", null, "Office", "OFFICE" },
                    { "defaf00d-ec55-4dbd-b6aa-db0b5f8c21cf", null, "Administrator", "ADMINISTRATOR" },
                    { "e69a50ee-4516-452f-bfc4-56a77857cb79", null, "Worker", "WORKER" },
                    { "f7cbcac9-b72b-4811-b030-f87ce96ccb72", null, "Chief", "CHIEF" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "238d10fb-5797-4740-9daa-ef912edaea71", 0, "41209bab-b50c-4a5c-b781-ccf43e390d44", null, false, false, null, null, "WORKER@ABC.COM", "AQAAAAIAAYagAAAAELV7uxhPCJ1l6nFKxtCbBje22rzQhbVWsYsa8SG/pWm9JTtlqP+4AgOnp2ljOLxPxQ==", null, false, "f4cbe535-1982-42dd-b231-5f0075fe9749", false, "worker@abc.com" },
                    { "3cff055f-7215-41ce-8728-1b6bdeb1d993", 0, "0ca8a13d-fcd9-4925-afaf-ba0e2fb32746", null, false, false, null, null, "CHIEF@ABC.COM", "AQAAAAIAAYagAAAAEJT/T5noTU7+zZO0uZKfZeThOv5bhijlYIPur3lihGcUvFOHmPu09Wnt0Ba2ck7eZQ==", null, false, "dbdeefc8-9772-4e1e-9bb7-f06ab616e8a0", false, "chief@abc.com" },
                    { "5242b050-5828-4745-b328-969580b5297c", 0, "68c921f2-f300-47a3-aa7c-a97ee0908d50", null, false, false, null, null, "ADMIN@ABC.COM", "AQAAAAIAAYagAAAAEJz8EyuR4BRIg+qspgyeDD+nJXAmScm4roOFNUBa19d3OM0OIBcrAorR8+jITRaCFw==", null, false, "4b201c77-0bc4-4ede-8b93-9a4266104602", false, "admin@abc.com" },
                    { "596622ba-fb8a-4562-9da0-279e5038438c", 0, "9120de21-1f9c-494a-b796-d483c0507a45", null, false, false, null, null, "OFFICE2@ABC.COM", "AQAAAAIAAYagAAAAELdG4EC+Yc9B+f/3HXjo5R9cI75q4hBOMQVmAPYNE9DQ3AfoUNKKVJ5p4zmxx6cqIA==", null, false, "465c1c2c-60d9-4250-8af9-031eb6237ede", false, "office2@abc.com" },
                    { "608f8222-bf54-4aff-8e0f-1847436f1b9a", 0, "51592267-b1ff-4033-8597-a5e996004ef0", null, false, false, null, null, "OFFICE1@ABC.COM", "AQAAAAIAAYagAAAAEB9myKhrf3sYrskVQRWz6aNwjqbDuaxvPO3dGAChSop/LuPfp6soBn6w7P4HFqrkhg==", null, false, "9d20ecea-ceb0-4138-a745-00cb858eaa83", false, "office1@abc.com" }
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
                    { "e69a50ee-4516-452f-bfc4-56a77857cb79", "238d10fb-5797-4740-9daa-ef912edaea71" },
                    { "f7cbcac9-b72b-4811-b030-f87ce96ccb72", "3cff055f-7215-41ce-8728-1b6bdeb1d993" },
                    { "defaf00d-ec55-4dbd-b6aa-db0b5f8c21cf", "5242b050-5828-4745-b328-969580b5297c" },
                    { "54549a05-4a44-4e26-b35a-c721f6449ce7", "596622ba-fb8a-4562-9da0-279e5038438c" },
                    { "54549a05-4a44-4e26-b35a-c721f6449ce7", "608f8222-bf54-4aff-8e0f-1847436f1b9a" }
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
