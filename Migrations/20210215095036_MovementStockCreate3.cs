using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_DotNetCoreAPI.Migrations
{
    public partial class MovementStockCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "CreateById",
                table: "MovementStock",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("16328900-db76-4a0a-a9c8-d086f667aa75"), "user" },
                    { new Guid("ef729557-7030-4f7f-a5ce-a19cc155b790"), "Manager" },
                    { new Guid("0d3cfa06-312b-4fb9-bc03-d46d5fa944d5"), "Admin" },
                    { new Guid("d0afe388-d89f-4fe9-af30-b36366811f65"), "Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovementStock_CreateById",
                table: "MovementStock",
                column: "CreateById");

            migrationBuilder.AddForeignKey(
                name: "FK_MovementStock_User_CreateById",
                table: "MovementStock",
                column: "CreateById",
                principalSchema: "auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovementStock_User_CreateById",
                table: "MovementStock");

            migrationBuilder.DropIndex(
                name: "IX_MovementStock_CreateById",
                table: "MovementStock");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0d3cfa06-312b-4fb9-bc03-d46d5fa944d5"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("16328900-db76-4a0a-a9c8-d086f667aa75"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("d0afe388-d89f-4fe9-af30-b36366811f65"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ef729557-7030-4f7f-a5ce-a19cc155b790"));

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "MovementStock");

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
    }
}
