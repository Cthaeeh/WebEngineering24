using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebDbApp.Migrations
{
    public partial class InitialCreate : Migration
    {
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
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    EMail = table.Column<string>(type: "TEXT", nullable: false),
                    Birthday = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    ShareStocks = table.Column<int>(type: "INTEGER", nullable: false),
                    ShareBonds = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
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
                    Name = table.Column<string>(type: "TEXT", nullable: true),
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
                    WorkspaceId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployeeId = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occupancies_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Occupancies_Workspaces_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29b40834-77f0-4554-bff8-ff0c8e9519f3", "6b6800ef-2f3b-40e8-80b4-c34133c3c3fa", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e5cf48e-9d46-4c93-8180-aa85892790ce", "4f71a89f-9375-48b3-be47-1fa2084be774", "Office", "OFFICE" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "38315ef1-5489-4cea-9d50-769a032f7833", 0, "58592bd6-759e-4949-9fb8-f6067c2e2889", null, false, false, null, null, "OFFICE2@ABC.COM", "AQAAAAEAACcQAAAAEKe/etxTPlN7IE7ih0nQ9YRH++JrVYajCX2LDpz7FKIVJKHJA8CmZKRNO1fmkVpH0w==", null, false, "3ef42a4b-ae65-4291-a76a-cccb0ec51c1a", false, "office2@abc.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b220d0e4-95c4-4722-baa9-fb977873bab4", 0, "2b309c54-6ead-4bf5-a855-225b4333ea57", null, false, false, null, null, "OFFICE1@ABC.COM", "AQAAAAEAACcQAAAAELVcdhr3jCMPFlEziqc10dzYr26fMs5xeWYTUxYy1e+ieIz7EToB/urKGxkPlDcB0A==", null, false, "9108e9e5-5141-4d36-a4a2-e742add397e1", false, "office1@abc.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ed1720a0-ea2b-423c-919b-84eeaed2d7c4", 0, "ad54ac8a-73f8-43b7-9394-2d94078a45f5", null, false, false, null, null, "ADMIN@ABC.COM", "AQAAAAEAACcQAAAAEBIV65BZN7m5ykoTqAH3YOk6TSIrKnyQlVO9oalynsLsdRLghCkpX3kYr7B2kJ29Dg==", null, false, "837ebc3f-a79d-4faf-851b-2fcb56e194fe", false, "admin@abc.com" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 1, "Room 1", 0 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 2, "Room 2", 5 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 3, "Room 3", 2 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 4, "Room 4", 3 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 5, "Room 5", 4 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 6, "Room 6", 1 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 7, "Room 7", 0 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 8, "Room 8", 5 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 9, "Room 9", 2 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 10, "Room 10", 3 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7e5cf48e-9d46-4c93-8180-aa85892790ce", "38315ef1-5489-4cea-9d50-769a032f7833" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7e5cf48e-9d46-4c93-8180-aa85892790ce", "b220d0e4-95c4-4722-baa9-fb977873bab4" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "29b40834-77f0-4554-bff8-ff0c8e9519f3", "ed1720a0-ea2b-423c-919b-84eeaed2d7c4" });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 1, "Workspace 1", 2 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 2, "Workspace 2", 3 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 3, "Workspace 3", 4 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 4, "Workspace 4", 5 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 5, "Workspace 5", 6 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 6, "Workspace 6", 7 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 7, "Workspace 7", 8 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 8, "Workspace 8", 9 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 9, "Workspace 9", 10 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 10, "Workspace 10", 1 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 11, "Workspace 11", 2 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 12, "Workspace 12", 3 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 13, "Workspace 13", 4 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 14, "Workspace 14", 5 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 15, "Workspace 15", 6 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 16, "Workspace 16", 7 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 17, "Workspace 17", 8 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 18, "Workspace 18", 9 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 19, "Workspace 19", 10 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 20, "Workspace 20", 1 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 21, "Workspace 21", 2 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 22, "Workspace 22", 3 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 23, "Workspace 23", 4 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 24, "Workspace 24", 5 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 25, "Workspace 25", 6 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 26, "Workspace 26", 7 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 27, "Workspace 27", 8 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 28, "Workspace 28", 9 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 29, "Workspace 29", 10 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[] { 30, "Workspace 30", 1 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 1, "Desk", 1 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 2, "Desk", 2 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 3, "Desk", 3 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 4, "Desk", 4 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 5, "Desk", 5 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 6, "Desk", 6 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 7, "Desk", 7 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 8, "Desk", 8 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 9, "Desk", 9 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 10, "Desk", 10 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 11, "Desk", 11 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 12, "Desk", 12 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 13, "Desk", 13 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 14, "Desk", 14 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 15, "Desk", 15 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 16, "Desk", 16 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 17, "Desk", 17 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 18, "Desk", 18 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 19, "Desk", 19 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 20, "Desk", 20 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 21, "Desk", 21 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 22, "Desk", 22 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 23, "Desk", 23 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 24, "Desk", 24 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 25, "Desk", 25 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 26, "Desk", 26 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 27, "Desk", 27 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 28, "Desk", 28 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 29, "Desk", 29 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 30, "Desk", 30 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 31, "Chair", 1 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 32, "Chair", 2 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 33, "Chair", 3 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 34, "Chair", 4 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 35, "Chair", 5 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 36, "Chair", 6 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 37, "Chair", 7 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 38, "Chair", 8 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 39, "Chair", 9 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 40, "Chair", 10 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 41, "Chair", 11 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 42, "Chair", 12 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 43, "Chair", 13 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 44, "Chair", 14 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 45, "Chair", 15 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 46, "Chair", 16 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 47, "Chair", 17 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 48, "Chair", 18 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 49, "Chair", 19 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 50, "Chair", 20 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 51, "Chair", 21 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 52, "Chair", 22 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 53, "Chair", 23 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 54, "Chair", 24 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 55, "Chair", 25 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 56, "Chair", 26 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 57, "Chair", 27 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 58, "Chair", 28 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 59, "Chair", 29 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkspaceId" },
                values: new object[] { 60, "Chair", 30 });

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
                name: "IX_Occupancies_WorkspaceId",
                table: "Occupancies",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Workspaces_RoomId",
                table: "Workspaces",
                column: "RoomId");
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
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Occupancies");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Workspaces");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
