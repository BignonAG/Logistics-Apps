using Microsoft.EntityFrameworkCore.Migrations;

namespace Pyvvo.Logistics.Model.Migrations
{
    public partial class WarehouseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ContactId",
                table: "Warehouses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_ContactId",
                table: "Warehouses",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Contacts_ContactId",
                table: "Warehouses",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Contacts_ContactId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_ContactId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Warehouses");
        }
    }
}
