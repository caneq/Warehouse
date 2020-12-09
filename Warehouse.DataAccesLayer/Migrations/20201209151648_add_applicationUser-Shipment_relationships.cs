using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.DataAccessLayer.Migrations
{
    public partial class add_applicationUserShipment_relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_AspNetUsers_RepicientId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_AspNetUsers_СonveyedId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_RepicientId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_СonveyedId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "RepicientId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "СonveyedApplicationUserId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "СonveyedId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "СonveyedName",
                table: "Shipments");

            migrationBuilder.AlterColumn<string>(
                name: "RepicientApplicationUserId",
                table: "Shipments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConveyedApplicationUserId",
                table: "Shipments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConveyedName",
                table: "Shipments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ConveyedApplicationUserId",
                table: "Shipments",
                column: "ConveyedApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_RepicientApplicationUserId",
                table: "Shipments",
                column: "RepicientApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_AspNetUsers_ConveyedApplicationUserId",
                table: "Shipments",
                column: "ConveyedApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_AspNetUsers_RepicientApplicationUserId",
                table: "Shipments",
                column: "RepicientApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_AspNetUsers_ConveyedApplicationUserId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_AspNetUsers_RepicientApplicationUserId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_ConveyedApplicationUserId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_RepicientApplicationUserId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "ConveyedApplicationUserId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "ConveyedName",
                table: "Shipments");

            migrationBuilder.AlterColumn<string>(
                name: "RepicientApplicationUserId",
                table: "Shipments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepicientId",
                table: "Shipments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "СonveyedApplicationUserId",
                table: "Shipments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "СonveyedId",
                table: "Shipments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "СonveyedName",
                table: "Shipments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_RepicientId",
                table: "Shipments",
                column: "RepicientId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_СonveyedId",
                table: "Shipments",
                column: "СonveyedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_AspNetUsers_RepicientId",
                table: "Shipments",
                column: "RepicientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_AspNetUsers_СonveyedId",
                table: "Shipments",
                column: "СonveyedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
