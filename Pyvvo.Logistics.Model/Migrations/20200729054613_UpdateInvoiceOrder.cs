using Microsoft.EntityFrameworkCore.Migrations;

namespace Pyvvo.Logistics.Model.Migrations
{
    public partial class UpdateInvoiceOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "Taxes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalTax",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "TotalTax",
                table: "Orders");
        }
    }
}
