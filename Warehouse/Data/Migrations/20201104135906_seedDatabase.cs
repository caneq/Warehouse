using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Data.Migrations
{
    public partial class seedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, "Китай" },
                    { 2, "Беларусь" },
                    { 3, "Россия" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "OrderStatusId", "OrderStatusString" },
                values: new object[,]
                {
                    { 1, "Ожидание оплаты" },
                    { 2, "Ожидание доставки" },
                    { 3, "Завершен" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "UnitString" },
                values: new object[,]
                {
                    { 1, "шт" },
                    { 2, "л." },
                    { 3, "кг" }
                });

            migrationBuilder.InsertData(
                table: "Uris",
                columns: new[] { "UrlId", "ProductId", "UrlString" },
                values: new object[,]
                {
                    { 1, null, "https://avatars.mds.yandex.net/get-mpic/1365202/img_id7828880432754619849.png/orig" },
                    { 2, null, "https://avatars.mds.yandex.net/get-mpic/1056698/img_id5528712325692372091.png/orig" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CountInStock", "Description", "ManufactureCountryId", "Name", "Price", "ShelfLife", "UnitId", "Weight" },
                values: new object[] { 1, 10, "", 1, "Материнская плата ASRock X370 Pro4", 300f, 2147483647, 1, 0.2f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CountInStock", "Description", "ManufactureCountryId", "Name", "Price", "ShelfLife", "UnitId", "Weight" },
                values: new object[] { 2, 14, "", 1, "Процессор AMD Ryzen 7 2700", 210f, 2147483647, 1, 0.4f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CountInStock", "Description", "ManufactureCountryId", "Name", "Price", "ShelfLife", "UnitId", "Weight" },
                values: new object[] { 3, 30, "", 1, "Твердотельный накопитель Samsung 970 EVO Plus 500 GB", 270f, 2147483647, 1, 0.3f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "OrderStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "OrderStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "OrderStatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Uris",
                keyColumn: "UrlId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Uris",
                keyColumn: "UrlId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 1);
        }
    }
}
