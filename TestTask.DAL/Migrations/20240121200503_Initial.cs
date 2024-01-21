using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestTask.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DATE", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderCost = table.Column<decimal>(type: "MONEY", nullable: false),
                    ItemsDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateOfBirth", "FirstName", "Gender", "LastName", "Login", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "M", "Doe", "user1", "password1" },
                    { 2, new DateTime(1992, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "F", "Smith", "user2", "password2" },
                    { 3, new DateTime(1988, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mike", "M", "Johnson", "user3", "password3" },
                    { 4, new DateTime(1995, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", "F", "Brown", "user4", "password4" },
                    { 5, new DateTime(1990, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "M", "Miller", "user5", "password5" },
                    { 6, new DateTime(1987, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eva", "F", "Davis", "user6", "password6" },
                    { 7, new DateTime(1993, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel", "M", "Clark", "user7", "password7" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "ItemsDescription", "OrderCost", "OrderDate", "ShippingAddress", "UserId" },
                values: new object[,]
                {
                    { 1, "Description 1", 100.0m, new DateTime(2024, 1, 21, 22, 5, 3, 12, DateTimeKind.Local).AddTicks(1483), "Address 1", 1 },
                    { 2, "Description 2", 150.0m, new DateTime(2024, 1, 21, 22, 5, 3, 12, DateTimeKind.Local).AddTicks(1525), "Address 2", 2 },
                    { 3, "Description 3", 120.0m, new DateTime(2024, 1, 21, 22, 5, 3, 12, DateTimeKind.Local).AddTicks(1528), "Address 3", 3 },
                    { 4, "Description 4", 200.0m, new DateTime(2024, 1, 21, 22, 5, 3, 12, DateTimeKind.Local).AddTicks(1530), "Address 4", 4 },
                    { 5, "Description 5", 90.0m, new DateTime(2024, 1, 21, 22, 5, 3, 12, DateTimeKind.Local).AddTicks(1532), "Address 5", 5 },
                    { 6, "Description 6", 180.0m, new DateTime(2024, 1, 21, 22, 5, 3, 12, DateTimeKind.Local).AddTicks(1535), "Address 6", 6 },
                    { 7, "Description 7", 130.0m, new DateTime(2024, 1, 21, 22, 5, 3, 12, DateTimeKind.Local).AddTicks(1537), "Address 7", 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
