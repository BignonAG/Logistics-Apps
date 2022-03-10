using Microsoft.EntityFrameworkCore.Migrations;

namespace Pyvvo.Logistics.Model.Migrations
{
    public partial class UpdateRefundLineItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefundLineItems_Status_StatusId",
                table: "RefundLineItems");

            migrationBuilder.AlterColumn<long>(
                name: "StatusId",
                table: "RefundLineItems",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_RefundLineItems_Status_StatusId",
                table: "RefundLineItems",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefundLineItems_Status_StatusId",
                table: "RefundLineItems");

            migrationBuilder.AlterColumn<long>(
                name: "StatusId",
                table: "RefundLineItems",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RefundLineItems_Status_StatusId",
                table: "RefundLineItems",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
