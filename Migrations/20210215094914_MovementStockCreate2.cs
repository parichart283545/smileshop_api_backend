using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_DotNetCoreAPI.Migrations
{
    public partial class MovementStockCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("038a635d-f9e1-4ebb-ad60-07c53d3d5245"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8da6c8c3-f34b-40aa-8399-da6bb56ca9a4"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a3538679-97d2-48f5-a61b-b8bc2d8ff14d"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("eef5820e-c49f-4244-80e8-ed0a96654664"));

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "MovementStock");

            migrationBuilder.DropColumn(
                name: "LotId",
                table: "MovementStock");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "MovementStock");

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "MovementStock",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredDate",
                table: "MovementStock",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "MovementStock",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("798145a9-c767-41a8-b7d8-79718bdad755"), "user" },
                    { new Guid("eafbdd62-8584-47b9-b645-51b10631dce4"), "Manager" },
                    { new Guid("f6ba2e3c-31ad-41bc-acb9-3cd767b39a2f"), "Admin" },
                    { new Guid("6368a276-a6fc-4410-b2c2-64c348e74cef"), "Developer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("6368a276-a6fc-4410-b2c2-64c348e74cef"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("798145a9-c767-41a8-b7d8-79718bdad755"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("eafbdd62-8584-47b9-b645-51b10631dce4"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f6ba2e3c-31ad-41bc-acb9-3cd767b39a2f"));

            migrationBuilder.DropColumn(
                name: "Code",
                table: "MovementStock");

            migrationBuilder.DropColumn(
                name: "ExpiredDate",
                table: "MovementStock");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "MovementStock");

            migrationBuilder.AddColumn<string>(
                name: "CreateById",
                table: "MovementStock",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LotId",
                table: "MovementStock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "MovementStock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("eef5820e-c49f-4244-80e8-ed0a96654664"), "user" },
                    { new Guid("038a635d-f9e1-4ebb-ad60-07c53d3d5245"), "Manager" },
                    { new Guid("8da6c8c3-f34b-40aa-8399-da6bb56ca9a4"), "Admin" },
                    { new Guid("a3538679-97d2-48f5-a61b-b8bc2d8ff14d"), "Developer" }
                });
        }
    }
}
