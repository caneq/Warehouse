using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.DataAccessLayer.Migrations
{
    public partial class update_seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartProducts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartProducts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CartProducts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "OrderStatusString" },
                values: new object[] { 4, "Неудачная попытка доставки" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { 1, "647be7d4-a30f-405d-989a-ec098de565b0" });

            migrationBuilder.InsertData(
                table: "CartProducts",
                columns: new[] { "Id", "CartId", "ProductId" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "CartProducts",
                columns: new[] { "Id", "CartId", "ProductId" },
                values: new object[] { 2, 1, 3 });

            migrationBuilder.InsertData(
                table: "CartProducts",
                columns: new[] { "Id", "CartId", "ProductId" },
                values: new object[] { 3, 1, 5 });
        }
    }
}
