using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.DataAccessLayer.Migrations
{
    public partial class add_conversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupplierOrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    String = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierOrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PaymentDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    SupplierId = table.Column<int>(nullable: false),
                    ResultPrice = table.Column<long>(nullable: true),
                    SupplierOrderStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierOrders_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierOrders_SupplierOrderStatuses_SupplierOrderStatusId",
                        column: x => x.SupplierOrderStatusId,
                        principalTable: "SupplierOrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplierOrders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplierOrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierOrderId = table.Column<int>(nullable: false),
                    Price = table.Column<long>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierOrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierOrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierOrderItem_SupplierOrders_SupplierOrderId",
                        column: x => x.SupplierOrderId,
                        principalTable: "SupplierOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierOrderStatusSupplierOrder",
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
                name: "IX_SupplierOrderItem_ProductId",
                table: "SupplierOrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrderItem_SupplierOrderId",
                table: "SupplierOrderItem",
                column: "SupplierOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrders_SupplierId",
                table: "SupplierOrders",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrders_SupplierOrderStatusId",
                table: "SupplierOrders",
                column: "SupplierOrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrders_UserId",
                table: "SupplierOrders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrderStatusSupplierOrder_SupplierOrderId",
                table: "SupplierOrderStatusSupplierOrder",
                column: "SupplierOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrderStatusSupplierOrder_SupplierOrderStatusId",
                table: "SupplierOrderStatusSupplierOrder",
                column: "SupplierOrderStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplierOrderItem");

            migrationBuilder.DropTable(
                name: "SupplierOrderStatusSupplierOrder");

            migrationBuilder.DropTable(
                name: "SupplierOrders");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "SupplierOrderStatuses");
        }
    }
}
