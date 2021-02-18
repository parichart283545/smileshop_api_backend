using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_DotNetCoreAPI.Migrations
{
    public partial class MovementStockCreate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "QuantityOld",
                table: "MovementStock",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("22f370c9-99c9-4e30-8cb4-ea1a8ab428c6"), "user" },
                    { new Guid("51166b7d-46a9-4184-ae5d-7d710cc40a12"), "Manager" },
                    { new Guid("eff870f8-20ed-4e4a-80db-3b6519ca1849"), "Admin" },
                    { new Guid("2f1dc784-1590-4cfc-8e51-c3696e646464"), "Developer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("22f370c9-99c9-4e30-8cb4-ea1a8ab428c6"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2f1dc784-1590-4cfc-8e51-c3696e646464"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("51166b7d-46a9-4184-ae5d-7d710cc40a12"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("eff870f8-20ed-4e4a-80db-3b6519ca1849"));

            migrationBuilder.DropColumn(
                name: "QuantityOld",
                table: "MovementStock");

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
        }
    }
}
