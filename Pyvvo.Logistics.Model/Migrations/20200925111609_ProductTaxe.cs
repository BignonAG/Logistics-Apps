using Microsoft.EntityFrameworkCore.Migrations;

namespace Pyvvo.Logistics.Model.Migrations
{
    public partial class ProductTaxe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingLineItems_OrderLineItems_OrderLineItemId",
                table: "ProcessingLineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingLineItems_Status_StatusId",
                table: "ProcessingLineItems");

            migrationBuilder.AddColumn<long>(
                name: "TaxeId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ReferenceNumberId",
                table: "Processings",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "StatusId",
                table: "ProcessingLineItems",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "OrderLineItemId",
                table: "ProcessingLineItems",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TaxeId",
                table: "Products",
                column: "TaxeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingLineItems_OrderLineItems_OrderLineItemId",
                table: "ProcessingLineItems",
                column: "OrderLineItemId",
                principalTable: "OrderLineItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingLineItems_Status_StatusId",
                table: "ProcessingLineItems",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Taxes_TaxeId",
                table: "Products",
                column: "TaxeId",
                principalTable: "Taxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingLineItems_OrderLineItems_OrderLineItemId",
                table: "ProcessingLineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingLineItems_Status_StatusId",
                table: "ProcessingLineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Taxes_TaxeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TaxeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TaxeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReferenceNumberId",
                table: "Processings");

            migrationBuilder.AlterColumn<long>(
                name: "StatusId",
                table: "ProcessingLineItems",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "OrderLineItemId",
                table: "ProcessingLineItems",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingLineItems_OrderLineItems_OrderLineItemId",
                table: "ProcessingLineItems",
                column: "OrderLineItemId",
                principalTable: "OrderLineItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingLineItems_Status_StatusId",
                table: "ProcessingLineItems",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
