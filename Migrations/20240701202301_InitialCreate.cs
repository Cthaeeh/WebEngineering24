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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ccf2f1b-d712-4765-a56b-2772006b52fc", "e3a21904-611d-4011-82f0-ae3128c9e419", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a3e66bc6-42c3-4544-a004-05d3924b7d57", 0, "1eed9dc1-78c4-4662-9e10-ae0856404f2d", null, false, false, null, null, "ADMIN@ABC.COM", "AQAAAAEAACcQAAAAEHwkKLU7i8bHhxr3gH8GQepYgNbWpl2w7EWaE6eWVv6ywJscVvQH4TajLnVq3ka0lg==", null, false, "652fdc7e-3d8c-4e75-9852-b3c90676c32d", false, "admin@abc.com" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 1, new DateTime(1966, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.beta@uni-wuerzburg.de", 0, "Anton Beta", 68, 32 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 2, new DateTime(1994, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.omega@uni-wuerzburg.de", 1, "Christian Omega", 4, 96 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 3, new DateTime(1980, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.epsilon@uni-wuerzburg.de", 0, "Franziska Epsilon", 63, 37 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 4, new DateTime(1954, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.alpha@uni-wuerzburg.de", 1, "Berta Alpha", 39, 61 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 5, new DateTime(1957, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.epsilon@uni-wuerzburg.de", 0, "Daniela Epsilon", 7, 93 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 6, new DateTime(1956, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.epsilon@uni-wuerzburg.de", 1, "Daniela Epsilon", 62, 38 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 7, new DateTime(1956, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.delta@uni-wuerzburg.de", 0, "Christian Delta", 58, 42 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 8, new DateTime(1987, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "egon.gamma@uni-wuerzburg.de", 1, "Egon Gamma", 27, 73 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 9, new DateTime(1958, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.epsilon@uni-wuerzburg.de", 0, "Daniela Epsilon", 2, 98 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 10, new DateTime(1988, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "egon.omega@uni-wuerzburg.de", 1, "Egon Omega", 91, 9 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 11, new DateTime(1995, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.delta@uni-wuerzburg.de", 0, "Berta Delta", 9, 91 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 12, new DateTime(1968, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.beta@uni-wuerzburg.de", 1, "Berta Beta", 54, 46 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 13, new DateTime(1955, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.omega@uni-wuerzburg.de", 0, "Daniela Omega", 22, 78 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 14, new DateTime(1972, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.beta@uni-wuerzburg.de", 1, "Christian Beta", 42, 58 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 15, new DateTime(1952, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.omega@uni-wuerzburg.de", 0, "Daniela Omega", 27, 73 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 16, new DateTime(1996, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.omega@uni-wuerzburg.de", 1, "Berta Omega", 59, 41 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 17, new DateTime(1995, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.gamma@uni-wuerzburg.de", 0, "Anton Gamma", 80, 20 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 18, new DateTime(1972, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.epsilon@uni-wuerzburg.de", 1, "Christian Epsilon", 42, 58 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 19, new DateTime(1973, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.alpha@uni-wuerzburg.de", 0, "Franziska Alpha", 88, 12 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 20, new DateTime(1962, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "egon.alpha@uni-wuerzburg.de", 1, "Egon Alpha", 69, 31 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 21, new DateTime(1954, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.gamma@uni-wuerzburg.de", 0, "Franziska Gamma", 12, 88 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 22, new DateTime(1986, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.omega@uni-wuerzburg.de", 1, "Berta Omega", 39, 61 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 23, new DateTime(1982, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.alpha@uni-wuerzburg.de", 0, "Franziska Alpha", 29, 71 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 24, new DateTime(1998, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.epsilon@uni-wuerzburg.de", 1, "Daniela Epsilon", 15, 85 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 25, new DateTime(1985, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.beta@uni-wuerzburg.de", 0, "Anton Beta", 73, 27 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 26, new DateTime(1965, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.beta@uni-wuerzburg.de", 1, "Christian Beta", 18, 82 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 27, new DateTime(1992, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.delta@uni-wuerzburg.de", 0, "Berta Delta", 89, 11 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 28, new DateTime(1993, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.alpha@uni-wuerzburg.de", 1, "Franziska Alpha", 45, 55 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 29, new DateTime(1956, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "egon.delta@uni-wuerzburg.de", 0, "Egon Delta", 46, 54 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 30, new DateTime(1970, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.gamma@uni-wuerzburg.de", 1, "Berta Gamma", 48, 52 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 31, new DateTime(1974, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.gamma@uni-wuerzburg.de", 0, "Berta Gamma", 33, 67 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 32, new DateTime(1969, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.epsilon@uni-wuerzburg.de", 1, "Christian Epsilon", 34, 66 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 33, new DateTime(1977, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.gamma@uni-wuerzburg.de", 0, "Anton Gamma", 35, 65 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 34, new DateTime(1966, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.gamma@uni-wuerzburg.de", 1, "Daniela Gamma", 80, 20 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 35, new DateTime(1951, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.alpha@uni-wuerzburg.de", 0, "Franziska Alpha", 3, 97 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 36, new DateTime(1968, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.beta@uni-wuerzburg.de", 1, "Daniela Beta", 36, 64 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 37, new DateTime(1986, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.omega@uni-wuerzburg.de", 0, "Daniela Omega", 71, 29 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 38, new DateTime(1966, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.delta@uni-wuerzburg.de", 1, "Berta Delta", 60, 40 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 39, new DateTime(1976, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.omega@uni-wuerzburg.de", 0, "Christian Omega", 38, 62 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 40, new DateTime(1998, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.beta@uni-wuerzburg.de", 1, "Daniela Beta", 39, 61 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 41, new DateTime(1986, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "egon.epsilon@uni-wuerzburg.de", 0, "Egon Epsilon", 74, 26 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 42, new DateTime(1979, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.alpha@uni-wuerzburg.de", 1, "Anton Alpha", 1, 99 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 43, new DateTime(1972, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.delta@uni-wuerzburg.de", 0, "Berta Delta", 63, 37 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 44, new DateTime(1990, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.gamma@uni-wuerzburg.de", 1, "Berta Gamma", 65, 35 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 45, new DateTime(1950, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.omega@uni-wuerzburg.de", 0, "Daniela Omega", 94, 6 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 46, new DateTime(1984, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.gamma@uni-wuerzburg.de", 1, "Daniela Gamma", 76, 24 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 47, new DateTime(1990, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.epsilon@uni-wuerzburg.de", 0, "Christian Epsilon", 41, 59 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 48, new DateTime(1997, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.omega@uni-wuerzburg.de", 1, "Christian Omega", 29, 71 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 49, new DateTime(1964, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.beta@uni-wuerzburg.de", 0, "Christian Beta", 89, 11 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 50, new DateTime(1984, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.alpha@uni-wuerzburg.de", 1, "Franziska Alpha", 84, 16 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 51, new DateTime(1963, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.gamma@uni-wuerzburg.de", 0, "Anton Gamma", 12, 88 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 52, new DateTime(1984, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.omega@uni-wuerzburg.de", 1, "Christian Omega", 2, 98 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 53, new DateTime(1955, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.alpha@uni-wuerzburg.de", 0, "Franziska Alpha", 17, 83 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 54, new DateTime(1996, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.alpha@uni-wuerzburg.de", 1, "Daniela Alpha", 46, 54 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 55, new DateTime(1959, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.beta@uni-wuerzburg.de", 0, "Anton Beta", 55, 45 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 56, new DateTime(1967, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.gamma@uni-wuerzburg.de", 1, "Franziska Gamma", 36, 64 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 57, new DateTime(1963, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.gamma@uni-wuerzburg.de", 0, "Christian Gamma", 20, 80 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 58, new DateTime(1975, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.omega@uni-wuerzburg.de", 1, "Christian Omega", 76, 24 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 59, new DateTime(1993, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "egon.alpha@uni-wuerzburg.de", 0, "Egon Alpha", 51, 49 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 60, new DateTime(1970, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.omega@uni-wuerzburg.de", 1, "Christian Omega", 95, 5 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 61, new DateTime(1989, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.delta@uni-wuerzburg.de", 0, "Anton Delta", 95, 5 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 62, new DateTime(1974, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.alpha@uni-wuerzburg.de", 1, "Anton Alpha", 2, 98 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 63, new DateTime(1950, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.alpha@uni-wuerzburg.de", 0, "Christian Alpha", 73, 27 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 64, new DateTime(1956, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.epsilon@uni-wuerzburg.de", 1, "Berta Epsilon", 82, 18 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 65, new DateTime(1956, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.omega@uni-wuerzburg.de", 0, "Berta Omega", 29, 71 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 66, new DateTime(1958, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.epsilon@uni-wuerzburg.de", 1, "Franziska Epsilon", 65, 35 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 67, new DateTime(1975, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.delta@uni-wuerzburg.de", 0, "Daniela Delta", 36, 64 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 68, new DateTime(1954, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.epsilon@uni-wuerzburg.de", 1, "Berta Epsilon", 96, 4 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 69, new DateTime(1970, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.alpha@uni-wuerzburg.de", 0, "Anton Alpha", 83, 17 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 70, new DateTime(1953, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.beta@uni-wuerzburg.de", 1, "Berta Beta", 29, 71 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 71, new DateTime(1953, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.delta@uni-wuerzburg.de", 0, "Christian Delta", 67, 33 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 72, new DateTime(1954, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.epsilon@uni-wuerzburg.de", 1, "Christian Epsilon", 57, 43 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 73, new DateTime(1980, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.gamma@uni-wuerzburg.de", 0, "Berta Gamma", 89, 11 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 74, new DateTime(1998, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.epsilon@uni-wuerzburg.de", 1, "Christian Epsilon", 11, 89 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 75, new DateTime(1964, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.alpha@uni-wuerzburg.de", 0, "Franziska Alpha", 39, 61 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 76, new DateTime(1965, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.beta@uni-wuerzburg.de", 1, "Franziska Beta", 12, 88 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 77, new DateTime(1970, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.delta@uni-wuerzburg.de", 0, "Anton Delta", 65, 35 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 78, new DateTime(1982, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.omega@uni-wuerzburg.de", 1, "Christian Omega", 31, 69 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 79, new DateTime(1991, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.epsilon@uni-wuerzburg.de", 0, "Berta Epsilon", 64, 36 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 80, new DateTime(1958, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.beta@uni-wuerzburg.de", 1, "Franziska Beta", 35, 65 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 81, new DateTime(1968, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.epsilon@uni-wuerzburg.de", 0, "Christian Epsilon", 27, 73 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 82, new DateTime(1962, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.epsilon@uni-wuerzburg.de", 1, "Anton Epsilon", 6, 94 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 83, new DateTime(1995, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "egon.beta@uni-wuerzburg.de", 0, "Egon Beta", 80, 20 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 84, new DateTime(1993, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.beta@uni-wuerzburg.de", 1, "Anton Beta", 30, 70 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 85, new DateTime(1951, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.omega@uni-wuerzburg.de", 0, "Daniela Omega", 91, 9 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 86, new DateTime(1995, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.gamma@uni-wuerzburg.de", 1, "Daniela Gamma", 7, 93 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 87, new DateTime(1952, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.epsilon@uni-wuerzburg.de", 0, "Berta Epsilon", 33, 67 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 88, new DateTime(1956, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "egon.gamma@uni-wuerzburg.de", 1, "Egon Gamma", 55, 45 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 89, new DateTime(1984, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.delta@uni-wuerzburg.de", 0, "Daniela Delta", 42, 58 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 90, new DateTime(1962, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.alpha@uni-wuerzburg.de", 1, "Berta Alpha", 33, 67 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 91, new DateTime(1957, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.delta@uni-wuerzburg.de", 0, "Anton Delta", 98, 2 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 92, new DateTime(1975, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.omega@uni-wuerzburg.de", 1, "Franziska Omega", 42, 58 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 93, new DateTime(1962, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.gamma@uni-wuerzburg.de", 0, "Franziska Gamma", 59, 41 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 94, new DateTime(1950, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.epsilon@uni-wuerzburg.de", 1, "Berta Epsilon", 42, 58 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 95, new DateTime(1963, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "egon.delta@uni-wuerzburg.de", 0, "Egon Delta", 33, 67 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 96, new DateTime(1991, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "egon.epsilon@uni-wuerzburg.de", 1, "Egon Epsilon", 64, 36 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 97, new DateTime(1950, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.epsilon@uni-wuerzburg.de", 0, "Daniela Epsilon", 64, 36 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 98, new DateTime(1952, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.gamma@uni-wuerzburg.de", 1, "Christian Gamma", 52, 48 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 99, new DateTime(1967, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "egon.delta@uni-wuerzburg.de", 0, "Egon Delta", 86, 14 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 100, new DateTime(1968, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.omega@uni-wuerzburg.de", 1, "Christian Omega", 8, 92 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 101, new DateTime(1989, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.beta@uni-wuerzburg.de", 0, "Berta Beta", 71, 29 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 102, new DateTime(1969, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.alpha@uni-wuerzburg.de", 1, "Daniela Alpha", 50, 50 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 103, new DateTime(1984, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.gamma@uni-wuerzburg.de", 0, "Anton Gamma", 93, 7 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 104, new DateTime(1967, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.delta@uni-wuerzburg.de", 1, "Berta Delta", 42, 58 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 105, new DateTime(1973, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.epsilon@uni-wuerzburg.de", 0, "Anton Epsilon", 6, 94 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 106, new DateTime(1999, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.epsilon@uni-wuerzburg.de", 1, "Berta Epsilon", 67, 33 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 107, new DateTime(1968, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.delta@uni-wuerzburg.de", 0, "Anton Delta", 63, 37 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 108, new DateTime(1999, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.epsilon@uni-wuerzburg.de", 1, "Christian Epsilon", 87, 13 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 109, new DateTime(1964, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "egon.beta@uni-wuerzburg.de", 0, "Egon Beta", 10, 90 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 110, new DateTime(1970, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.omega@uni-wuerzburg.de", 1, "Franziska Omega", 1, 99 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 111, new DateTime(1964, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.delta@uni-wuerzburg.de", 0, "Berta Delta", 6, 94 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 112, new DateTime(1976, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.omega@uni-wuerzburg.de", 1, "Anton Omega", 41, 59 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 113, new DateTime(1983, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.delta@uni-wuerzburg.de", 0, "Anton Delta", 16, 84 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 114, new DateTime(1979, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.omega@uni-wuerzburg.de", 1, "Daniela Omega", 28, 72 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 115, new DateTime(1983, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.beta@uni-wuerzburg.de", 0, "Franziska Beta", 29, 71 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 116, new DateTime(1971, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.gamma@uni-wuerzburg.de", 1, "Christian Gamma", 58, 42 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 117, new DateTime(1995, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "christian.omega@uni-wuerzburg.de", 0, "Christian Omega", 15, 85 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 118, new DateTime(1986, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniela.delta@uni-wuerzburg.de", 1, "Daniela Delta", 12, 88 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 119, new DateTime(1962, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "egon.beta@uni-wuerzburg.de", 0, "Egon Beta", 65, 35 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 120, new DateTime(1998, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.omega@uni-wuerzburg.de", 1, "Anton Omega", 79, 21 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 121, new DateTime(1979, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton.beta@uni-wuerzburg.de", 0, "Anton Beta", 93, 7 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 122, new DateTime(1986, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "franziska.delta@uni-wuerzburg.de", 1, "Franziska Delta", 50, 50 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthday", "EMail", "Gender", "Name", "ShareBonds", "ShareStocks" },
                values: new object[] { 123, new DateTime(1998, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "berta.alpha@uni-wuerzburg.de", 0, "Berta Alpha", 26, 74 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6ccf2f1b-d712-4765-a56b-2772006b52fc", "a3e66bc6-42c3-4544-a004-05d3924b7d57" });

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
