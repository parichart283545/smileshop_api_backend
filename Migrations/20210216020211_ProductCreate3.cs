using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_DotNetCoreAPI.Migrations
{
    public partial class ProductCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2958c31b-d53e-44a8-9809-4132540ee242"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("bda1c2d8-248f-4fa8-ada8-64920f54da2b"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ddcac69d-db5b-4d1c-9753-27f0796b80d3"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("fcb53907-d829-4273-9eeb-5f34b61dab7a"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreateById",
                table: "Products",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreateById",
                table: "ProductGroups",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

                 migrationBuilder.CreateIndex(
                name: "IX_Product_CreateById",
                table: "Products",
                column: "CreateById");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_CreateById",
                table: "Products",
                column: "CreateById",
                principalSchema: "auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "ProductGroups");

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("fcb53907-d829-4273-9eeb-5f34b61dab7a"), "user" },
                    { new Guid("2958c31b-d53e-44a8-9809-4132540ee242"), "Manager" },
                    { new Guid("bda1c2d8-248f-4fa8-ada8-64920f54da2b"), "Admin" },
                    { new Guid("ddcac69d-db5b-4d1c-9753-27f0796b80d3"), "Developer" }
                });
        }
    }
}
