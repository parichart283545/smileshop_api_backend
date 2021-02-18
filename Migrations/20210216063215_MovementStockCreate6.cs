using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_DotNetCoreAPI.Migrations
{
    public partial class MovementStockCreate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("7d9b82f5-54ef-436c-8a5e-f3428f1e8ae2"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("82165d5a-105f-4233-a328-f90706201807"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("c56dac04-58b8-43ac-9566-b6c9153cbc3e"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("d0dd675a-3b62-45e3-81cc-160af46f6ba8"));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b7854943-cd18-4d0f-898f-6adf37fffd90"), "user" },
                    { new Guid("c4f70202-e823-4145-8091-3f4650da4b64"), "Manager" },
                    { new Guid("85534d04-7687-41cb-9b52-40d15e39a9a6"), "Admin" },
                    { new Guid("4d0efc2c-1881-4b00-825a-166a85cc568c"), "Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovementStock_MovementTypeId",
                table: "MovementStock",
                column: "MovementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementStock_ProductId",
                table: "MovementStock",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovementStock_MovementType_MovementTypeId",
                table: "MovementStock",
                column: "MovementTypeId",
                principalTable: "MovementType",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MovementStock_Products_ProductId",
                table: "MovementStock",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovementStock_MovementType_MovementTypeId",
                table: "MovementStock");

            migrationBuilder.DropForeignKey(
                name: "FK_MovementStock_Products_ProductId",
                table: "MovementStock");

            migrationBuilder.DropIndex(
                name: "IX_MovementStock_MovementTypeId",
                table: "MovementStock");

            migrationBuilder.DropIndex(
                name: "IX_MovementStock_ProductId",
                table: "MovementStock");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4d0efc2c-1881-4b00-825a-166a85cc568c"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("85534d04-7687-41cb-9b52-40d15e39a9a6"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b7854943-cd18-4d0f-898f-6adf37fffd90"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("c4f70202-e823-4145-8091-3f4650da4b64"));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d0dd675a-3b62-45e3-81cc-160af46f6ba8"), "user" },
                    { new Guid("7d9b82f5-54ef-436c-8a5e-f3428f1e8ae2"), "Manager" },
                    { new Guid("82165d5a-105f-4233-a328-f90706201807"), "Admin" },
                    { new Guid("c56dac04-58b8-43ac-9566-b6c9153cbc3e"), "Developer" }
                });
        }
    }
}
