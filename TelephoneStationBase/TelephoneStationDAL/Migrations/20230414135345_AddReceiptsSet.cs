using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelephoneStationDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddReceiptsSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Orders_CallId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Subscriptions_SubscriptionId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Users_UserId",
                table: "Receipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt");

            migrationBuilder.RenameTable(
                name: "Receipt",
                newName: "Receives");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_UserId",
                table: "Receives",
                newName: "IX_Receives_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_SubscriptionId",
                table: "Receives",
                newName: "IX_Receives_SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_CallId",
                table: "Receives",
                newName: "IX_Receives_CallId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receives",
                table: "Receives",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameTable(
                name: "Receives",
                newName: "Receipt");

            migrationBuilder.RenameIndex(
                name: "IX_Receives_UserId",
                table: "Receipt",
                newName: "IX_Receipt_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Receives_SubscriptionId",
                table: "Receipt",
                newName: "IX_Receipt_SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Receives_CallId",
                table: "Receipt",
                newName: "IX_Receipt_CallId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Orders_CallId",
                table: "Receipt",
                column: "CallId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Subscriptions_SubscriptionId",
                table: "Receipt",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Users_UserId",
                table: "Receipt",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
