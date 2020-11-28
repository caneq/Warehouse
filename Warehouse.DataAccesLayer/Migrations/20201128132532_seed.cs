using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.DataAccessLayer.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { 1, "647be7d4-a30f-405d-989a-ec098de565b0" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Китай" },
                    { 2, "Беларусь" },
                    { 3, "Россия" },
                    { 4, "Индия" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "OrderStatusString" },
                values: new object[,]
                {
                    { 1, "Ожидание оплаты" },
                    { 2, "Ожидание доставки" },
                    { 3, "Завершен" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "UnitString" },
                values: new object[,]
                {
                    { 1, "шт" },
                    { 2, "л." },
                    { 3, "кг" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CountInStock", "Description", "ManufactureCountryId", "Name", "Price", "ShelfLife", "UnitId", "Weight" },
                values: new object[,]
                {
                    { 1, 10, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 1, "Материнская плата ASRock X370 Pro4", 300f, 2147483647, 1, 0.2f },
                    { 2, 14, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 1, "Процессор AMD Ryzen 7 2700", 210f, 2147483647, 1, 0.4f },
                    { 3, 30, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 1, "Твердотельный накопитель Samsung 970 EVO Plus 500 GB", 270f, 2147483647, 1, 0.3f },
                    { 4, 23, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 1, "Стиральная машина Beko RSGE 685P2 BSW", 646f, 2147483647, 1, 50f },
                    { 5, 6, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 1, "Смартфон Apple iPhone 12 Pro 128GB", 3960f, 2147483647, 1, 0.187f }
                });

            migrationBuilder.InsertData(
                table: "CartProduct",
                columns: new[] { "Id", "CartId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 3 },
                    { 3, 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "Id", "ProductId", "UrlString" },
                values: new object[,]
                {
                    { 1, 1, "https://avatars.mds.yandex.net/get-mpic/1365202/img_id7828880432754619849.png/orig" },
                    { 2, 1, "https://avatars.mds.yandex.net/get-mpic/1056698/img_id5528712325692372091.png/orig" },
                    { 3, 2, "https://avatars.mds.yandex.net/get-mpic/1332324/img_id4552048093897868354.jpeg/orig" },
                    { 4, 3, "https://avatars.mds.yandex.net/get-mpic/1614201/img_id580048981333677263.jpeg/orig" },
                    { 5, 4, "https://avatars.mds.yandex.net/get-mpic/1909520/img_id8306103419771387034.jpeg/orig" },
                    { 6, 4, "https://avatars.mds.yandex.net/get-mpic/1866164/img_id5608834248530713529.jpeg/orig" },
                    { 7, 5, "https://avatars.mds.yandex.net/get-mpic/1863454/img_id2637791473799097205.jpeg/orig" },
                    { 8, 5, "https://avatars.mds.yandex.net/get-mpic/1927699/img_id4100362096269675431.png/orig" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
