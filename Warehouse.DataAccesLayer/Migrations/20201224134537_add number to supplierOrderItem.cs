using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.DataAccessLayer.Migrations
{
    public partial class addnumbertosupplierOrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplierOrderStatusSupplierOrder");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "SupplierOrderItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SupplierOrderSupplierOrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierOrderId = table.Column<int>(nullable: false),
                    SupplierOrderStatusId = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierOrderSupplierOrderStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierOrderSupplierOrderStatus_SupplierOrders_SupplierOrderId",
                        column: x => x.SupplierOrderId,
                        principalTable: "SupplierOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierOrderSupplierOrderStatus_SupplierOrderStatuses_SupplierOrderStatusId",
                        column: x => x.SupplierOrderStatusId,
                        principalTable: "SupplierOrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrderSupplierOrderStatus_SupplierOrderId",
                table: "SupplierOrderSupplierOrderStatus",
                column: "SupplierOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrderSupplierOrderStatus_SupplierOrderStatusId",
                table: "SupplierOrderSupplierOrderStatus",
                column: "SupplierOrderStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplierOrderSupplierOrderStatus");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "SupplierOrderItem");

            migrationBuilder.CreateTable(
                name: "SupplierOrderStatusSupplierOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierOrderId = table.Column<int>(type: "int", nullable: false),
                    SupplierOrderStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierOrderStatusSupplierOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierOrderStatusSupplierOrder_SupplierOrders_SupplierOrderId",
                        column: x => x.SupplierOrderId,
                        principalTable: "SupplierOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierOrderStatusSupplierOrder_SupplierOrderStatuses_SupplierOrderStatusId",
                        column: x => x.SupplierOrderStatusId,
                        principalTable: "SupplierOrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrderStatusSupplierOrder_SupplierOrderId",
                table: "SupplierOrderStatusSupplierOrder",
                column: "SupplierOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrderStatusSupplierOrder_SupplierOrderStatusId",
                table: "SupplierOrderStatusSupplierOrder",
                column: "SupplierOrderStatusId");
        }
    }
}
