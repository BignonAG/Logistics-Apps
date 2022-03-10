using Microsoft.EntityFrameworkCore.Migrations;

namespace Pyvvo.Logistics.Model.Migrations
{
    public partial class ReferenceNumberId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ReferenceNumberId",
                table: "StockTransfers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ReferenceNumberId",
                table: "StockAdjustements",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ReferenceNumberId",
                table: "Shipments",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ReferenceNumberId",
                table: "Returns",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ReferenceNumberId",
                table: "PurchaseOrders",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ReferenceNumberId",
                table: "PurchaseOrderReceives",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceNumberId",
                table: "StockTransfers");

            migrationBuilder.DropColumn(
                name: "ReferenceNumberId",
                table: "StockAdjustements");

            migrationBuilder.DropColumn(
                name: "ReferenceNumberId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "ReferenceNumberId",
                table: "Returns");

            migrationBuilder.DropColumn(
                name: "ReferenceNumberId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "ReferenceNumberId",
                table: "PurchaseOrderReceives");
        }
    }
}
