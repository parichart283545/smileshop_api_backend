using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_DotNetCoreAPI.Migrations
{
    public partial class ProductCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0bfc5958-101a-4daa-8f18-7b6fa5ba4820"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("49d63c1f-0f38-4f05-af3e-b71391c00c74"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("7a9881de-a3aa-4e84-82ab-9f15e975f88f"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("cffe465c-b39e-4d85-8549-2e7340f43cb1"));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2f69d7e3-713e-409b-8ae2-e468642512be"), "user" },
                    { new Guid("b3e5b1e4-d6ea-4b10-b164-e82e211bf09b"), "Manager" },
                    { new Guid("94e6eaeb-f4b1-4510-bd01-825a693d8149"), "Admin" },
                    { new Guid("3eeed86b-e7cb-4469-8712-1ccadba510bb"), "Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreateById",
                table: "Products",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroups_CreateById",
                table: "ProductGroups",
                column: "CreateById");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroups_User_CreateById",
                table: "ProductGroups",
                column: "CreateById",
                principalSchema: "auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_User_CreateById",
                table: "Products",
                column: "CreateById",
                principalSchema: "auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroups_User_CreateById",
                table: "ProductGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_User_CreateById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreateById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductGroups_CreateById",
                table: "ProductGroups");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2f69d7e3-713e-409b-8ae2-e468642512be"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3eeed86b-e7cb-4469-8712-1ccadba510bb"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("94e6eaeb-f4b1-4510-bd01-825a693d8149"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b3e5b1e4-d6ea-4b10-b164-e82e211bf09b"));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0bfc5958-101a-4daa-8f18-7b6fa5ba4820"), "user" },
                    { new Guid("49d63c1f-0f38-4f05-af3e-b71391c00c74"), "Manager" },
                    { new Guid("7a9881de-a3aa-4e84-82ab-9f15e975f88f"), "Admin" },
                    { new Guid("cffe465c-b39e-4d85-8549-2e7340f43cb1"), "Developer" }
                });
        }
    }
}
