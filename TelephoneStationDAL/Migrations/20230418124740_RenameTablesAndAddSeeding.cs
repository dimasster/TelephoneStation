using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TelephoneStationDAL.Migrations
{
    /// <inheritdoc />
    public partial class RenameTablesAndAddSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_CallerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_TargetId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Receives_Orders_CallId",
                table: "Receives");

            migrationBuilder.DropForeignKey(
                name: "FK_Receives_Subscriptions_SubscriptionId",
                table: "Receives");

            migrationBuilder.DropForeignKey(
                name: "FK_Receives_Users_UserId",
                table: "Receives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receives",
                table: "Receives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Receives",
                newName: "Receiptes");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Calls");

            migrationBuilder.RenameIndex(
                name: "IX_Receives_UserId",
                table: "Receiptes",
                newName: "IX_Receiptes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Receives_SubscriptionId",
                table: "Receiptes",
                newName: "IX_Receiptes_SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Receives_CallId",
                table: "Receiptes",
                newName: "IX_Receiptes_CallId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_TargetId",
                table: "Calls",
                newName: "IX_Calls_TargetId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CallerId",
                table: "Calls",
                newName: "IX_Calls_CallerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receiptes",
                table: "Receiptes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calls",
                table: "Calls",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Calls",
                columns: new[] { "Id", "CallStartDate", "CallTime", "CallerId", "Status", "TargetId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(3881), 191, 3, 2, 1 },
                    { 2, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(3948), 330, 3, 4, 4 },
                    { 3, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(3965), 209, 1, 4, 1 },
                    { 4, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(3979), 219, 1, 1, 4 },
                    { 5, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(3994), 583, 3, 1, 2 },
                    { 6, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4010), 580, 1, 3, 2 },
                    { 7, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4025), 451, 3, 2, 1 },
                    { 8, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4039), 422, 3, 1, 2 },
                    { 9, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4054), 224, 4, 2, 2 },
                    { 10, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4069), 567, 1, 4, 1 },
                    { 11, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4117), 237, 2, 1, 4 },
                    { 12, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4132), 211, 1, 3, 1 },
                    { 13, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4169), 543, 4, 2, 5 },
                    { 14, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4184), 104, 5, 1, 1 },
                    { 15, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4198), 76, 3, 1, 1 },
                    { 16, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4212), 129, 5, 0, 3 },
                    { 17, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4226), 497, 4, 4, 1 },
                    { 18, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4242), 268, 2, 3, 2 },
                    { 19, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4256), 185, 4, 4, 4 },
                    { 20, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4270), 350, 1, 3, 2 },
                    { 21, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4284), 157, 3, 2, 1 },
                    { 22, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4298), 162, 4, 4, 2 },
                    { 23, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4311), 247, 2, 1, 2 },
                    { 24, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4357), 416, 1, 0, 2 },
                    { 25, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4372), 411, 5, 3, 5 },
                    { 26, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4386), 91, 1, 3, 5 },
                    { 27, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4400), 114, 3, 3, 1 },
                    { 28, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4414), 519, 4, 1, 2 },
                    { 29, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4427), 480, 1, 0, 2 },
                    { 30, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4441), 351, 4, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "SavedUsers",
                columns: new[] { "TargetId", "UserId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 1, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "FreeMinutes",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "FreeMinutes",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "FreeMinutes",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "FreeMinutes",
                value: 20);

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CostPerMinute", "FreeMinutes", "SubscriptionCost", "Title" },
                values: new object[] { 6, 0.2m, 30, 39.99m, "Service 6" });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "MinuteOfUsage", "ServiceId", "SubscriptionEndDate", "SubscriptionStartDate", "UserId" },
                values: new object[,]
                {
                    { 1, 386, 1, new DateTime(2023, 5, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4467), new DateTime(2023, 4, 7, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4465), 1 },
                    { 2, 527, 2, new DateTime(2023, 5, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4498), new DateTime(2023, 3, 30, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4496), 2 },
                    { 3, 185, 3, new DateTime(2023, 5, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4519), new DateTime(2023, 4, 6, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4517), 3 },
                    { 4, 199, 4, new DateTime(2023, 5, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4539), new DateTime(2023, 4, 15, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4537), 4 },
                    { 5, 345, 5, new DateTime(2023, 5, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4558), new DateTime(2023, 4, 7, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4557), 5 }
                });

            migrationBuilder.InsertData(
                table: "Receiptes",
                columns: new[] { "Id", "CallId", "Date", "IsBought", "Price", "ReceiptType", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(3933), true, 1.57975460689327m, "CallReceipt", 3 },
                    { 2, 2, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(3956), true, 0.365064297957425m, "CallReceipt", 3 },
                    { 3, 3, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(3971), false, 2.56224327671058m, "CallReceipt", 1 },
                    { 4, 4, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(3986), true, 1.53678529012912m, "CallReceipt", 1 },
                    { 5, 5, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4002), false, 3.31791636264993m, "CallReceipt", 3 },
                    { 6, 6, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4017), false, 3.3850904407395m, "CallReceipt", 1 },
                    { 7, 7, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4032), true, 2.04072152985089m, "CallReceipt", 3 },
                    { 8, 8, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4046), false, 0.146067292706979m, "CallReceipt", 3 },
                    { 9, 9, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4061), false, 3.36130622716839m, "CallReceipt", 4 },
                    { 10, 10, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4108), false, 4.88825540103062m, "CallReceipt", 1 },
                    { 11, 11, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4124), true, 4.34781329255758m, "CallReceipt", 2 },
                    { 12, 12, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4139), false, 3.10180924988691m, "CallReceipt", 1 },
                    { 13, 13, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4176), false, 4.44519293077237m, "CallReceipt", 4 },
                    { 14, 14, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4191), true, 0.610268963115974m, "CallReceipt", 5 },
                    { 15, 15, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4205), false, 1.29788966272998m, "CallReceipt", 3 },
                    { 16, 16, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4219), false, 3.40586159639986m, "CallReceipt", 5 },
                    { 17, 17, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4234), false, 4.376941610318m, "CallReceipt", 4 },
                    { 18, 18, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4249), true, 0.0400632481521951m, "CallReceipt", 2 },
                    { 19, 19, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4262), true, 0.871181149068541m, "CallReceipt", 4 },
                    { 20, 20, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4276), true, 0.0361076648135544m, "CallReceipt", 1 },
                    { 21, 21, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4290), true, 3.42753177319915m, "CallReceipt", 3 },
                    { 22, 22, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4304), true, 0.0830441775564616m, "CallReceipt", 4 },
                    { 23, 23, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4349), false, 2.36635480168276m, "CallReceipt", 2 },
                    { 24, 24, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4364), false, 1.75389224904493m, "CallReceipt", 1 },
                    { 25, 25, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4378), true, 4.83882328435891m, "CallReceipt", 5 },
                    { 26, 26, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4392), false, 0.936151984172547m, "CallReceipt", 1 },
                    { 27, 27, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4406), false, 1.22813040232466m, "CallReceipt", 3 },
                    { 28, 28, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4420), false, 0.974465256231774m, "CallReceipt", 4 },
                    { 29, 29, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4434), false, 0.0726381729581388m, "CallReceipt", 1 },
                    { 30, 30, new DateTime(2023, 4, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4448), true, 1.13592010048533m, "CallReceipt", 4 }
                });

            migrationBuilder.InsertData(
                table: "Receiptes",
                columns: new[] { "Id", "Date", "IsBought", "Price", "ReceiptType", "SubscriptionId", "UserId" },
                values: new object[,]
                {
                    { 31, new DateTime(2023, 3, 27, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4482), true, 596m, "SubscriptionReceipt", 1, 1 },
                    { 32, new DateTime(2023, 3, 29, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4507), false, 290m, "SubscriptionReceipt", 2, 2 },
                    { 33, new DateTime(2023, 3, 31, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4527), false, 951m, "SubscriptionReceipt", 3, 3 },
                    { 34, new DateTime(2023, 3, 22, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4547), true, 466m, "SubscriptionReceipt", 4, 4 },
                    { 35, new DateTime(2023, 4, 7, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4567), true, 222m, "SubscriptionReceipt", 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "MinuteOfUsage", "ServiceId", "SubscriptionEndDate", "SubscriptionStartDate", "UserId" },
                values: new object[] { 6, 488, 6, new DateTime(2023, 5, 18, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4579), new DateTime(2023, 4, 6, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4578), 6 });

            migrationBuilder.InsertData(
                table: "Receiptes",
                columns: new[] { "Id", "Date", "IsBought", "Price", "ReceiptType", "SubscriptionId", "UserId" },
                values: new object[] { 36, new DateTime(2023, 3, 21, 15, 47, 40, 428, DateTimeKind.Local).AddTicks(4619), true, 666m, "SubscriptionReceipt", 6, 6 });

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Users_CallerId",
                table: "Calls",
                column: "CallerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Users_TargetId",
                table: "Calls",
                column: "TargetId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receiptes_Calls_CallId",
                table: "Receiptes",
                column: "CallId",
                principalTable: "Calls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receiptes_Subscriptions_SubscriptionId",
                table: "Receiptes",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receiptes_Users_UserId",
                table: "Receiptes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Users_CallerId",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Users_TargetId",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Receiptes_Calls_CallId",
                table: "Receiptes");

            migrationBuilder.DropForeignKey(
                name: "FK_Receiptes_Subscriptions_SubscriptionId",
                table: "Receiptes");

            migrationBuilder.DropForeignKey(
                name: "FK_Receiptes_Users_UserId",
                table: "Receiptes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receiptes",
                table: "Receiptes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calls",
                table: "Calls");

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Receiptes",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "SavedUsers",
                keyColumns: new[] { "TargetId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "SavedUsers",
                keyColumns: new[] { "TargetId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "SavedUsers",
                keyColumns: new[] { "TargetId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "SavedUsers",
                keyColumns: new[] { "TargetId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "SavedUsers",
                keyColumns: new[] { "TargetId", "UserId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.RenameTable(
                name: "Receiptes",
                newName: "Receives");

            migrationBuilder.RenameTable(
                name: "Calls",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Receiptes_UserId",
                table: "Receives",
                newName: "IX_Receives_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Receiptes_SubscriptionId",
                table: "Receives",
                newName: "IX_Receives_SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Receiptes_CallId",
                table: "Receives",
                newName: "IX_Receives_CallId");

            migrationBuilder.RenameIndex(
                name: "IX_Calls_TargetId",
                table: "Orders",
                newName: "IX_Orders_TargetId");

            migrationBuilder.RenameIndex(
                name: "IX_Calls_CallerId",
                table: "Orders",
                newName: "IX_Orders_CallerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receives",
                table: "Receives",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "FreeMinutes",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "FreeMinutes",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "FreeMinutes",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "FreeMinutes",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_CallerId",
                table: "Orders",
                column: "CallerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_TargetId",
                table: "Orders",
                column: "TargetId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receives_Orders_CallId",
                table: "Receives",
                column: "CallId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receives_Subscriptions_SubscriptionId",
                table: "Receives",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receives_Users_UserId",
                table: "Receives",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
