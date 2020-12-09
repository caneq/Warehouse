using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.DataAccessLayer.Migrations
{
    public partial class add_shipment_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepicientName = table.Column<string>(nullable: true),
                    RepicientApplicationUserId = table.Column<string>(nullable: true),
                    RepicientId = table.Column<string>(nullable: true),
                    СonveyedName = table.Column<string>(nullable: true),
                    СonveyedApplicationUserId = table.Column<string>(nullable: true),
                    СonveyedId = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipments_AspNetUsers_RepicientId",
                        column: x => x.RepicientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipments_AspNetUsers_СonveyedId",
                        column: x => x.СonveyedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_OrderId",
                table: "Shipments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_RepicientId",
                table: "Shipments",
                column: "RepicientId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_СonveyedId",
                table: "Shipments",
                column: "СonveyedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shipments");
        }
    }
}
