using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_DotNetCoreAPI.Migrations
{
    public partial class MovementStockCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("218f3aa5-abfb-4092-adec-cc2a37c890ac"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("60d6c98d-c069-4877-867a-37c1d6899840"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("66291336-d977-469e-8128-07ab5e7f354c"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("bd0fbdd7-6e3d-44b4-9d36-55d00541562e"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("218f3aa5-abfb-4092-adec-cc2a37c890ac"), "user" },
                    { new Guid("bd0fbdd7-6e3d-44b4-9d36-55d00541562e"), "Manager" },
                    { new Guid("66291336-d977-469e-8128-07ab5e7f354c"), "Admin" },
                    { new Guid("60d6c98d-c069-4877-867a-37c1d6899840"), "Developer" }
                });
        }
    }
}
