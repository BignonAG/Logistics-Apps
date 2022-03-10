using Microsoft.EntityFrameworkCore.Migrations;

namespace Pyvvo.Logistics.Model.Migrations
{
    public partial class warehouse_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Users_Warehouses_Id",
            //    table: "Users");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Users_Roles_RoleId",
            //    table: "Users");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Warehouses_Users_UserId",
            //    table: "Warehouses");

            //migrationBuilder.DropIndex(
            //    name: "IX_Warehouses_UserId",
            //    table: "Warehouses");

            //migrationBuilder.DropIndex(
            //    name: "IX_Users_RoleId",
            //    table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Warehouses");

            //migrationBuilder.DropColumn(
            //    name: "UserId",
            //    table: "Warehouses");

            //migrationBuilder.DropColumn(
            //    name: "RoleId",
            //    table: "Users");

            //migrationBuilder.AddColumn<long>(
            //    name: "CreatedById",
            //    table: "Warehouses",
            //    nullable: true);

            //migrationBuilder.AddColumn<long>(
            //    name: "LocationId",
            //    table: "Users",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Warehouses_CreatedById",
            //    table: "Warehouses",
            //    column: "CreatedById");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_LocationId",
            //    table: "Users",
            //    column: "LocationId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Users_Roles_Id",
            //    table: "Users",
            //    column: "Id",
            //    principalTable: "Roles",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Users_Warehouses_LocationId",
            //    table: "Users",
            //    column: "LocationId",
            //    principalTable: "Warehouses",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Warehouses_Users_CreatedById",
            //    table: "Warehouses",
            //    column: "CreatedById",
            //    principalTable: "Users",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Users_Roles_Id",
            //    table: "Users");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Users_Warehouses_LocationId",
            //    table: "Users");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Warehouses_Users_CreatedById",
            //    table: "Warehouses");

            //migrationBuilder.DropIndex(
            //    name: "IX_Warehouses_CreatedById",
            //    table: "Warehouses");

            //migrationBuilder.DropIndex(
            //    name: "IX_Users_LocationId",
            //    table: "Users");

            //migrationBuilder.DropColumn(
            //    name: "CreatedById",
            //    table: "Warehouses");

            //migrationBuilder.DropColumn(
            //    name: "LocationId",
            //    table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            //migrationBuilder.AddColumn<long>(
            //    name: "UserId",
            //    table: "Warehouses",
            //    type: "bigint",
            //    nullable: false,
            //    defaultValue: 0L);

            //migrationBuilder.AddColumn<long>(
            //    name: "RoleId",
            //    table: "Users",
            //    type: "bigint",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Warehouses_UserId",
            //    table: "Warehouses",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_RoleId",
            //    table: "Users",
            //    column: "RoleId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Users_Warehouses_Id",
            //    table: "Users",
            //    column: "Id",
            //    principalTable: "Warehouses",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Users_Roles_RoleId",
            //    table: "Users",
            //    column: "RoleId",
            //    principalTable: "Roles",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Warehouses_Users_UserId",
            //    table: "Warehouses",
            //    column: "UserId",
            //    principalTable: "Users",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
