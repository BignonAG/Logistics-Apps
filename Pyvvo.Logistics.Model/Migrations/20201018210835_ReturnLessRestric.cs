using Microsoft.EntityFrameworkCore.Migrations;

namespace Pyvvo.Logistics.Model.Migrations
{
    public partial class ReturnLessRestric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnLineItems_Status_StatusId",
                table: "ReturnLineItems");

            migrationBuilder.AlterColumn<long>(
                name: "StatusId",
                table: "ReturnLineItems",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnLineItems_Status_StatusId",
                table: "ReturnLineItems",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnLineItems_Status_StatusId",
                table: "ReturnLineItems");

            migrationBuilder.AlterColumn<long>(
                name: "StatusId",
                table: "ReturnLineItems",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnLineItems_Status_StatusId",
                table: "ReturnLineItems",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
