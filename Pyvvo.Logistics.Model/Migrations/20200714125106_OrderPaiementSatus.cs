using Microsoft.EntityFrameworkCore.Migrations;

namespace Pyvvo.Logistics.Model.Migrations
{
    public partial class OrderPaiementSatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayementStatus",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "PayementStatusId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PayementStatusId",
                table: "Orders",
                column: "PayementStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Status_PayementStatusId",
                table: "Orders",
                column: "PayementStatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Status_PayementStatusId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PayementStatusId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PayementStatusId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "PayementStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
