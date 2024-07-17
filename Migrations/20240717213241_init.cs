using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyWebDbApp.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                    WorkspaceId = table.Column<int>(type: "INTEGER", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "315b548b-a22c-4311-bec5-5fbdfa930fc1", null, "Chief", "CHIEF" },
                    { "6c9a01f7-38c5-43c6-9478-d23a49838d51", null, "Worker", "WORKER" },
                    { "a406977c-27dc-459d-9a85-671338a3b997", null, "Office", "OFFICE" },
                    { "c93eda02-f1b9-4693-b25b-509d4d70080f", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "13961a53-edc5-4cda-a059-4a23cc8d89c9", 0, "7f0b73a1-5da2-4afc-9656-43cc63ab94e8", null, null, false, false, null, null, "CHIEF@ABC.COM", "AQAAAAIAAYagAAAAEDbQX98ysFxxNb4mBY9cB5CxZsiLNbxYggaaKk23RhgVQOOJbs6OGC77n7hXHlVwGg==", null, false, "7cb599b8-a56b-45d8-b188-a278230d6429", false, "chief@abc.com" },
                    { "2347f193-f788-406d-920d-50be54893154", 0, "3c719898-6a3b-485c-86bd-1c20487f7e3b", null, null, false, false, null, null, "OFFICE2@ABC.COM", "AQAAAAIAAYagAAAAEKAM03sLQ/+I1/OBj6oyO699hw97Z6fIOPPsi9HVw/2ldXb+ofCVy+yxFXJWMBBNRw==", null, false, "464d8e4b-2bf6-4601-8ecb-53a9eab75d70", false, "office2@abc.com" },
                    { "a55afed9-27fe-471e-b414-354cb6000ad4", 0, "2bbbb48e-b1ea-48b1-94ab-799736e9e072", null, null, false, false, null, null, "ADMIN@ABC.COM", "AQAAAAIAAYagAAAAELqu4uJ3Ezpwf8/GCpeJjQT5ToQlIcN1PgBf9jj5ZCKuyESwV27y0WLzS5OA4BdzMA==", null, false, "ceea76cc-2ebe-4a2b-ae9f-b00b0094cbf5", false, "admin@abc.com" },
                    { "a707fce9-8fdc-4f43-8026-cd1806b6febd", 0, "093fb70d-1bb0-4077-a76c-51483fd77a2e", null, null, false, false, null, null, "WORKER@ABC.COM", "AQAAAAIAAYagAAAAEPH+iZBh9ouHQXZBxlowu4gm10fliGI3wB/aYxWbD2m4oF9w1R52aNn2umF/AgQ6hQ==", null, false, "4aa98df9-5e97-41f6-9149-992046babdef", false, "worker@abc.com" },
                    { "b6ebf5bc-e950-431e-8f96-767cc4c517cc", 0, "e88ae57f-8b93-4d92-8f5e-3082b83ba537", null, null, false, false, null, null, "OFFICE1@ABC.COM", "AQAAAAIAAYagAAAAELcDdk6SrMwVLr2uUlnt4IPA6U492iUgtFkbc55yu5en6GK5HcVBIE75R5j3mCgZOA==", null, false, "0bb6299b-3a39-4c94-a14d-252bd031d2e3", false, "office1@abc.com" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "HomeOffice-Room", 0 },
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
                    { "315b548b-a22c-4311-bec5-5fbdfa930fc1", "13961a53-edc5-4cda-a059-4a23cc8d89c9" },
                    { "a406977c-27dc-459d-9a85-671338a3b997", "2347f193-f788-406d-920d-50be54893154" },
                    { "c93eda02-f1b9-4693-b25b-509d4d70080f", "a55afed9-27fe-471e-b414-354cb6000ad4" },
                    { "6c9a01f7-38c5-43c6-9478-d23a49838d51", "a707fce9-8fdc-4f43-8026-cd1806b6febd" },
                    { "a406977c-27dc-459d-9a85-671338a3b997", "b6ebf5bc-e950-431e-8f96-767cc4c517cc" }
                });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[,]
                {
                    { -1, "HomeOffice", 1 },
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
