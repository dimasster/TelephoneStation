using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TelephoneStationDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CostPerMinute", "FreeMinutes", "SubscriptionCost", "Title" },
                values: new object[,]
                {
                    { 1, 0.1m, 0, 9.99m, "Service 1" },
                    { 2, 0.05m, 0, 14.99m, "Service 2" },
                    { 3, 0.2m, 0, 19.99m, "Service 3" },
                    { 4, 0.15m, 0, 24.99m, "Service 4" },
                    { 5, 0.25m, 0, 29.99m, "Service 5" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Ballance", "IsBanned", "LastName", "Name", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, 0.0, false, null, "John", 123456789, 1 },
                    { 2, 0.0, false, "Smith", "Sarah", 234567890, 1 },
                    { 3, 0.0, false, null, "Alex", 345678901, 1 },
                    { 4, 0.0, false, null, "Mike", 456789012, 1 },
                    { 5, 0.0, false, null, "Emily", 567890123, 1 },
                    { 6, 0.0, false, null, "Admin", 678901234, 2 }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Login", "Password", "UserId" },
                values: new object[,]
                {
                    { 1, "user1", "password", 1 },
                    { 2, "user2", "password", 2 },
                    { 3, "user3", "password", 3 },
                    { 4, "user4", "password", 4 },
                    { 5, "user5", "password", 5 },
                    { 6, "admin", "password", 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
