using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Data.Migrations
{
    public partial class seedDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uris_Products_ProductId",
                table: "Uris");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Uris",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Uris",
                keyColumn: "UrlId",
                keyValue: 1,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Uris",
                keyColumn: "UrlId",
                keyValue: 2,
                column: "ProductId",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Uris_Products_ProductId",
                table: "Uris",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uris_Products_ProductId",
                table: "Uris");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Uris",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Uris",
                keyColumn: "UrlId",
                keyValue: 1,
                column: "ProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Uris",
                keyColumn: "UrlId",
                keyValue: 2,
                column: "ProductId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Uris_Products_ProductId",
                table: "Uris",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
