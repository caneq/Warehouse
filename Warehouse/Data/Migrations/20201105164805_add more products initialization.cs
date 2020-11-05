using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Data.Migrations
{
    public partial class addmoreproductsinitialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CountInStock", "Description", "ManufactureCountryId", "Name", "Price", "ShelfLife", "UnitId", "Weight" },
                values: new object[] { 4, 23, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 1, "Стиральная машина Beko RSGE 685P2 BSW", 646f, 2147483647, 1, 50f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CountInStock", "Description", "ManufactureCountryId", "Name", "Price", "ShelfLife", "UnitId", "Weight" },
                values: new object[] { 5, 6, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 1, "Смартфон Apple iPhone 12 Pro 128GB", 3960f, 2147483647, 1, 0.187f });

            migrationBuilder.InsertData(
                table: "Uris",
                columns: new[] { "UrlId", "ProductId", "UrlString" },
                values: new object[,]
                {
                    { 5, 4, "https://avatars.mds.yandex.net/get-mpic/1909520/img_id8306103419771387034.jpeg/orig" },
                    { 6, 4, "https://avatars.mds.yandex.net/get-mpic/1866164/img_id5608834248530713529.jpeg/orig" },
                    { 7, 5, "https://avatars.mds.yandex.net/get-mpic/1863454/img_id2637791473799097205.jpeg/orig" },
                    { 8, 5, "https://avatars.mds.yandex.net/get-mpic/1927699/img_id4100362096269675431.png/orig" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uris",
                keyColumn: "UrlId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Uris",
                keyColumn: "UrlId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Uris",
                keyColumn: "UrlId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Uris",
                keyColumn: "UrlId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);
        }
    }
}
