using Microsoft.EntityFrameworkCore.Migrations;

namespace Pyvvo.Logistics.Model.Migrations
{
    public partial class UpdateVariant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variants_Status_StatusId",
                table: "Variants");

            migrationBuilder.AlterColumn<long>(
                name: "StatusId",
                table: "Variants",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Variants_Status_StatusId",
                table: "Variants",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variants_Status_StatusId",
                table: "Variants");

            migrationBuilder.AlterColumn<long>(
                name: "StatusId",
                table: "Variants",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Variants_Status_StatusId",
                table: "Variants",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
