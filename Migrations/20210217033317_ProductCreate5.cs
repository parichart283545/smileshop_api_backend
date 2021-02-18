using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_DotNetCoreAPI.Migrations
{
    public partial class ProductCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3b75e1c4-5c8f-417c-a9a4-873daeed9401"), "user" },
                    { new Guid("e63729df-9f39-4a86-a154-d28407a11a27"), "Manager" },
                    { new Guid("bdee9114-1de1-481c-8515-630093af61e2"), "Admin" },
                    { new Guid("8b9fd96b-1a57-438a-9ebc-7f57b7e089c6"), "Developer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b75e1c4-5c8f-417c-a9a4-873daeed9401"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8b9fd96b-1a57-438a-9ebc-7f57b7e089c6"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("bdee9114-1de1-481c-8515-630093af61e2"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e63729df-9f39-4a86-a154-d28407a11a27"));

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
    }
}
