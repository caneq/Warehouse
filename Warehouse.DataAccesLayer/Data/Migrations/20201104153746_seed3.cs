using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.DataAccesLayer.Data.Migrations
{
    public partial class seed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Uris",
                columns: new[] { "UrlId", "ProductId", "UrlString" },
                values: new object[] { 3, 2, "https://avatars.mds.yandex.net/get-mpic/1332324/img_id4552048093897868354.jpeg/orig" });

            migrationBuilder.InsertData(
                table: "Uris",
                columns: new[] { "UrlId", "ProductId", "UrlString" },
                values: new object[] { 4, 3, "https://avatars.mds.yandex.net/get-mpic/1614201/img_id580048981333677263.jpeg/orig" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uris",
                keyColumn: "UrlId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Uris",
                keyColumn: "UrlId",
                keyValue: 4);
        }
    }
}
